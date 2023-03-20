package main

import "fmt"

var val_check = -1

func setValueWrap(v int) {
	fmt.Println("Before setValue:", v)
	setValue(v)
	val_check = v
	check()
	fmt.Println("After setValue")
}

func createWrap(name string) {
	create(name)
	fmt.Println("after creating ", name)
	fmt.Println("starting a monitoring thread")
}

func check() {
	//fmt.Println("value of check ", val_check)
	if val_check == 10 {
		fmt.Println("enters here")
		setValue(5)
	}
}
