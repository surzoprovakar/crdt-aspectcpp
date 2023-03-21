package main

type Counter struct {
	id    int
	value int
}

func NewCounter(id int) *Counter {
	return &Counter{id: id, value: 0}
}

func (c *Counter) GetVal() int {
	return c.value
}

func (c *Counter) SetVal(new_val int) {
	c.value = new_val
}

func main() {
	c := NewCounter(11)
	for i := 0; i < 15; i++ {
		c.SetVal(i + 1)
	}
}
