package main

import (
	"encoding/binary"
	"fmt"
	"sync"
)

var mu sync.Mutex

type CounterIface interface {
	Inc()
	Dec()
	Value() int
}

type Counter struct {
	id    int
	value int
}

func NewCounter(id int) *Counter {
	return &Counter{id: id, value: 0}
}

func (c *Counter) SetVal(new_val int) {
	c.value = new_val
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

func (c *Counter) Merge(o *Counter) {
	mu.Lock()
	fmt.Println("Starting to merge: " + c.Print() + ", " + o.Print())
	if c.value < o.value {
		new_val := o.value
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

	binary.LittleEndian.PutUint64(a1, uint64(c.Id()))
	binary.LittleEndian.PutUint64(a2, uint64(c.Value()))
	return append(a1, a2...)
}

func FromByteArray(bytes []byte) *Counter {

	var r1 = binary.LittleEndian.Uint64(bytes[0:(len(bytes) / 2)])
	var r2 = binary.LittleEndian.Uint64(bytes[len(bytes)/2:])
	id := int64(r1)
	c := NewCounter(int(id))
	c.value = int(int64(r2))
	return c
}
