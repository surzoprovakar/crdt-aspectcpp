#include <iostream>
#include <map>
using namespace std;

template <typename V=int, typename K=string>

class counter {
	private:
  		map<K,V> m;
  		K name;
	
	public:
		counter() {} 
  		counter(K a) : name(a) {
			cout << "created " << name << endl;
		}

		counter inc(V tosum={1}) {
    		counter<V,K> res;
    		m[name]+=tosum;
    		res.m[name]=m[name];
    		return res;
  		}

		V local() {
    		V res=0;
    		res += m[name];
    		return res;
  		}
};