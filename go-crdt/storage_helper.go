package main

import (
	"encoding/json"
	"os"
	"strconv"
)

var verson_count = 0

type Node struct {
	Version int
	Value   int
}

func Create_File(id int) {
	fileName := "Counter_" + strconv.Itoa(id) + ".json"

	if _, err := os.Stat(fileName); os.IsNotExist(err) {
		os.Create(fileName)
	}
}

func Record(id int, val int) {
	var N Node
	verson_count++
	N.Version = verson_count
	N.Value = val

	fileName := "Counter_" + strconv.Itoa(id) + ".json"
	file, _ := os.OpenFile(fileName, os.O_APPEND|os.O_WRONLY, 0644)

	data, _ := json.MarshalIndent(N, "\t", "")
	file.Write(data)
	file.Write([]byte("\n"))
}
