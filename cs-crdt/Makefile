build:
	@cd Rewrite/; dotnet build
	@cd Rewrite/; dotnet run
	@cd Rewrite/; mv main.cs ../
	@mcs main.cs GCounter.cs PNCounter.cs Wrapper.cs
run:
	@mono main.exe
clean:
	@rm -rf *.exe main*