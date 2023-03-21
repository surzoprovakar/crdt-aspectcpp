package main

import (
	"fmt"
	"time"
)

var val_check = -1

func (c *Counter) setValueWrap(v int) {
	fmt.Println("Before setValue:", v)
	c.SetVal(v)
	val_check = v
	fmt.Println("After setValue", c.GetVal())
	time.Sleep(100 * time.Millisecond)
}

func createWrap(id int) *Counter {
	c := NewCounter(id)
	fmt.Println("after creating ", id)
	go c.check()
	return c
}

func (c *Counter) check() {
	for {
		if val_check == 10 {
			c.setValueWrap(5)
		}
		time.Sleep(100 * time.Millisecond)
	}
}
