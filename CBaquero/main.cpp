// #include "hello.h"
#include<iostream>
#include <unistd.h>
#include "counter.cpp"
using namespace std;

int main() {
  counter c;
  c.create("counter 1");
  for (int i = 0; i < 10; i++) {
    c.setValue(i + 1);
  }
}