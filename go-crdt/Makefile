build:
	@go build Rewrite.go
	@./Rewrite < counter_operations.go > counter1_operations.go
	@go build counter_socket_server.go counter_socket_client.go counter1_operations.go file_reader.go wrapper.go

clean:
	@rm -f counter1* Rewrite counter_socket_server