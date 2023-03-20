package main

import "fmt"

var counter = 0

func create(name string) {
	fmt.Println("created ", name)
}

func setValue(val int) {
	fmt.Println("setting counter to ", val)
	counter = val
}

func main() {
	create("counter 1")
	for i := 0; i < 10; i++ {
		setValue(i + 1)
	}
}
