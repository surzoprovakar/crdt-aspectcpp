// #include "hello.h"
#include<iostream>
#include <unistd.h>
#include "counter.h"
using namespace std;

int main() {
  create("counter 1");
  for (int i = 0; i < 10; i++) {
    setValue(i + 1);
  }
}
