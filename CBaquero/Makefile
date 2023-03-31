# include ../Makefile.generic

CXX ?= g++
ACXX ?= $(PWD)/../ag++

PROG:=$(shell basename $$PWD)
SOURCES := $(wildcard *.cpp)

JUNK    := Junk
OBJECTS := $(addprefix $(JUNK)/,$(patsubst %.cpp,%.o,$(SOURCES)))


all: $(PROG)

run: all
	@./CBaquero-crdts

$(PROG): $(OBJECTS)
	@echo Linking CBaquero-crdts
	@$(CXX) $(CXXFLAGS) -o CBaquero-crdts $(OBJECTS) $(LDFLAGS) -lpthread

clean:
	@rm -rf *.o $(JUNK) CBaquero-crdts

$(JUNK)/%.o : %.cpp
	@echo Compiling $<
	@mkdir -p $(JUNK)
	@$(ACXX) $(CXXFLAGS) -x c++ -c $< -o $@