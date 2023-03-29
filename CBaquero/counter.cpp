#include <iostream>
using namespace std;

class counter {
	public:
		const char* name;
		int val;

		counter(const char* n) {
			name = n;
			cout << "created " << name << endl;
		}

		void setValue(int v) {
			val = v;
			cout << "setting counter to " << val << endl;	
		}
};
// void create(const char* name) {
// 	cout << "created " << name << endl;	
// }

// void setValue(int val) {
// 	cout << "setting counter to " << val << endl;	
// 	cnt = val;
// }