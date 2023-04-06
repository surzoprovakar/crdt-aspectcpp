using System;
namespace cs_crdt {
    public class GCounter {
        private string name;

        private int value;

        public GCounter(string n) {
            this.name = n;
            this.value = 0;
            Console.WriteLine("G Counter " + this.name + " is created");
        }

        public void Increment() {
            this.value++;
        }

        public void Increment(int val) {
            this.value += val;
        }

        public int GetVal() {
            return this.value;
        }
    }
}