using System;
namespace cs_crdt {
      public class PNCounter {
        private string name;

        private int value;

        public PNCounter(string n) {
            this.name = n;
            this.value = 0;
            Console.WriteLine("PN Counter " + this.name + " is created");
        }

        public void Increment() {
            this.value++;
        }

        public void Increment(int val) {
            this.value += val;
        }

        public void Decrement() {
            this.value--;
        }

        public void Decrement(int val) {
            this.value -= val;
        }

        public int GetVal() {
            return this.value;
        }
    }
}