build:
	@go build Rewrite.go
	@./Rewrite < counter_operations.go > counter_ast_operations.go
	@./Rewrite < counter_socket_server.go > counter_ast_socket_server.go
	@go build counter_ast_socket_server.go counter_socket_client.go counter_ast_operations.go file_reader.go wrapper.go storage_helper.go

clean:
	@rm -f counter_ast* Rewrite *.json