# include ../Makefile.generic

CXX ?= g++
ACXX ?= $(PWD)/../../ag++

PROG:=$(shell basename $$PWD)
SOURCES := $(wildcard *.cpp)

JUNK    := Junk
OBJECTS := $(addprefix $(JUNK)/,$(patsubst %.cpp,%.o,$(SOURCES)))


all: $(PROG)

run: all
	@./counter

$(PROG): $(OBJECTS)
	@#echo Linking counter
	@$(CXX) $(CXXFLAGS) -o counter $(OBJECTS) $(LDFLAGS) -lpthread

clean:
	@rm -rf *.o $(JUNK) counter

$(JUNK)/%.o : %.cpp
	@echo Compiling $<
	@mkdir -p $(JUNK)
	@$(ACXX) $(CXXFLAGS) -x c++ -c $< -o $@