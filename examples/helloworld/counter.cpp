#include <iostream>
using namespace std;

int counter = 0;
void create(const char* name) {
	cout << "created " << name << endl;	
}

void setValue(int val) {
	cout << "setting counter to " << val << endl;	
	counter = val;
}