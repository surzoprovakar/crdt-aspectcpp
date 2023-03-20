package main
import "fmt"

func setValueWrap(v int) {
	fmt.Println("Before setValue:", v);
	setValue(v)
	fmt.Println("After setValue");
}

func createWrap(name string) {
	create(name)
	fmt.Println("after creating ", name)
	fmt.Println("starting a monitoring thread")
}
