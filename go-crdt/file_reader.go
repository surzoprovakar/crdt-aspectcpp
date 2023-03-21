package main

import (
	"bufio"
	"fmt"
	"log"
	"os"
	"strings"
)

func ReadFile(fileName string) []string {

	buf, err := os.Open(fileName)
	if err != nil {
		log.Fatal(err)
	}

	defer func() {
		if err = buf.Close(); err != nil {
			log.Fatal(err)
		}
	}()

	var lines []string
	snl := bufio.NewScanner(buf)
	for snl.Scan() {
		lines = append(lines, snl.Text())
	}
	err = snl.Err()
	if err != nil {
		log.Fatal(err)
	}
	return lines
}

func ReadFile_TrustGradient(fileName string) ([]string, map[string]float64) {
	buf, err := os.Open(fileName)
	if err != nil {
		log.Fatal(err)
	}

	defer func() {
		if err = buf.Close(); err != nil {
			log.Fatal(err)
		}
	}()

	addr2Trust := map[string]float64{}
	var lines []string
	snl := bufio.NewScanner(buf)
	for snl.Scan() {
		var addr string
		var trust float64

		lines = append(lines, snl.Text())

		r := strings.NewReader(snl.Text())
		_, err := fmt.Fscanf(r, "%s %f", addr, trust)
		addr2Trust[addr] = trust
		if err != nil {
			fmt.Fprintf(os.Stderr, "Fscanf: %v\n", err)
		}
	}
	err = snl.Err()
	if err != nil {
		log.Fatal(err)
	}
	return lines, addr2Trust
}
