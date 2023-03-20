build:
	@go build Rewrite.go
	@./Rewrite < counter.go > counter1.go
	@go build counter1.go wrapper.go

run:
	@./counter1

clean:
	@rm -f counter1* Rewrite