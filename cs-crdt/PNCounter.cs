using System;
namespace cs_crdt {
      public class PNCounter {
        private string name;

        private int value;

        public PNCounter(string n) {
            this.name = n;
            this.value = 0;
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

        public string GetName() {
            return this.name;
        }
    }
}