using System;
namespace cs_crdt {
    public static class Wrapper {

        public static GCounter gc;
        public static PNCounter pnc;
        public static GCounter CreateWrapGC(string n) {
            gc = new GCounter(n);
            Console.WriteLine("G Counter " + n + " is created");
            return gc;
        }

        public static void GCIncrement() {
            Console.WriteLine("Before Inc");
            gc.Increment();
            Console.WriteLine("After Inc");
            Console.WriteLine("Current val of " + gc.GetName() + " is " + gc.GetVal());
        }

        public static void GCIncrement(int val) {
            Console.WriteLine("Before Inc by " + val);
            gc.Increment(val);
            Console.WriteLine("After Inc by" + val);
            Console.WriteLine("Current val of " + gc.GetName() + " is " + gc.GetVal());
        }

        public static PNCounter CreateWrapPN(string n) {
            pnc = new PNCounter(n);
            Console.WriteLine("PN Counter " + n + " is created");
            return pnc;
        }

        public static void PNIncrement() {
            Console.WriteLine("Before Inc");
            pnc.Increment();
            Console.WriteLine("After Inc");
            Console.WriteLine("Current val of " + pnc.GetName() + " is " + pnc.GetVal());
        }

        public static void PNIncrement(int val) {
            Console.WriteLine("Before Inc by " + val);
            pnc.Increment(val);
            Console.WriteLine("After Inc by" + val);
            Console.WriteLine("Current val of " + pnc.GetName() + " is " + pnc.GetVal());
        }

        public static void PNDecrement() {
            Console.WriteLine("Before Dec");
            pnc.Decrement();
            Console.WriteLine("After Dec");
            Console.WriteLine("Current val of " + pnc.GetName() + " is " + pnc.GetVal());
        }

        public static void PNDecrement(int val) {
            Console.WriteLine("Before Dec by " + val);
            pnc.Decrement(val);
            Console.WriteLine("After Dec by" + val);
            Console.WriteLine("Current val of " + pnc.GetName() + " is " + pnc.GetVal());
        }
    }
}