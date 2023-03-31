#include<iostream>
#include <unistd.h>
#include "counter.cpp"
using namespace std;

typedef counter<int,string> GC;
void * constructCounter(const char* s) {
	 return new GC(string(s));
}

void counterInc(void * pThis) {
	GC *pRealThis = (GC*)pThis;
	pRealThis->inc();
}

int main() {
	//counter<int, string> c("counter 1");
	GC * p = (GC*)constructCounter("counter 1");
	for (int i = 0; i < 10; i++) {
		//c.inc();
		counterInc(p);	
		cout << "setting counter to " << p->local() << endl;
	}
	delete p; 
}