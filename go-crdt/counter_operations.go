package main

import (
	"encoding/binary"
	"fmt"
	"sync"
	"time"
)

var mu sync.Mutex

type CounterIface interface {
	Inc()
	Dec()
	Value() int
}

type Counter struct {
	id       int
	value    int
	opt_time time.Time
}

func NewCounter(id int) *Counter {
	return &Counter{id: id, value: 0}
}

func (c *Counter) SetVal(new_val int) {
	c.value = new_val
	c.opt_time = time.Now()
}

func (c *Counter) Inc() {
	mu.Lock()
	new_val := c.value + 1
	c.SetVal(new_val)
	mu.Unlock()
}

func (c *Counter) Dec() {
	mu.Lock()
	new_val := c.value - 1
	c.SetVal(new_val)
	mu.Unlock()
}

func (c *Counter) Id() int {
	return c.id
}

func (c *Counter) Value() int {
	return c.value
}

func (c *Counter) Merge(rid int, rval int, rtime time.Time) {
	mu.Lock()
	res := fmt.Sprintf("%s%d:%d", "Counter_", rid, rval)
	fmt.Println("Starting to merge: " + c.Print() + ", " + res)
	if c.opt_time.After(rtime) {
		new_val := rval
		fmt.Println("Need to Merge")
		c.SetVal(new_val)
	}
	fmt.Println("Merged " + c.Print())
	mu.Unlock()
}

func (c *Counter) Print() string {
	res := fmt.Sprintf("%s%d:%d", "Counter_", c.Id(), c.Value())
	return res
}

func (c *Counter) ToByteArray() []byte {

	a1 := make([]byte, 64)
	a2 := make([]byte, 64)
	a3 := make([]byte, 64)

	binary.LittleEndian.PutUint64(a1, uint64(c.Id()))
	binary.LittleEndian.PutUint64(a2, uint64(c.Value()))
	binary.LittleEndian.PutUint64(a3, uint64(c.opt_time.Unix()))
	a1 = append(a1, a2...)
	return append(a1, a3...)
}

func FromByteArray(bytes []byte) (int, int, time.Time) {

	var r1 = binary.LittleEndian.Uint64(bytes[0 : len(bytes)/3])
	var r2 = binary.LittleEndian.Uint64(bytes[len(bytes)/3 : 2*(len(bytes)/3)])
	var r3 = binary.LittleEndian.Uint64(bytes[2*(len(bytes)/3):])

	rid := int(r1)
	rval := int(r2)
	rtime := time.Unix(int64(r3), 0)
	return rid, rval, rtime
}
