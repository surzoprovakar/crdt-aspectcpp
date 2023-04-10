using System;
using System.Threading;
namespace cs_crdt {
    public static class Wrapper {

        public static GCounter gc;
        public static PNCounter pnc;

        public static int g_val;
        public static int pn_val;
        public static GCounter CreateWrapGC(string n) {
            gc = new GCounter(n);
            Console.WriteLine("G Counter " + n + " is created");
            new Thread(delegate () {
                check();
            }).Start();
            return gc;
        }

        public static void GCIncrement() {
            Console.WriteLine("Before Inc");
            gc.Increment();
            g_val = gc.GetVal();
            Console.WriteLine("After Inc");
            Console.WriteLine("Current val of " + gc.GetName() + " is " + gc.GetVal());
            Thread.Sleep(1000);
        }

        public static void GCIncrement(int val) {
            Console.WriteLine("Before Inc by " + val);
            gc.Increment(val);
            g_val = gc.GetVal();
            Console.WriteLine("After Inc by " + val);
            Console.WriteLine("Current val of " + gc.GetName() + " is " + gc.GetVal());
            Thread.Sleep(1000);
        }

        public static PNCounter CreateWrapPN(string n) {
            pnc = new PNCounter(n);
            Console.WriteLine("PN Counter " + n + " is created");
            return pnc;
        }

        public static void PNIncrement() {
            Console.WriteLine("Before Inc");
            pnc.Increment();
            pn_val = pnc.GetVal();
            Console.WriteLine("After Inc");
            Console.WriteLine("Current val of " + pnc.GetName() + " is " + pnc.GetVal());
            Thread.Sleep(1000);
        }

        public static void PNIncrement(int val) {
            Console.WriteLine("Before Inc by " + val);
            pnc.Increment(val);
            pn_val = pnc.GetVal();
            Console.WriteLine("After Inc by" + val);
            Console.WriteLine("Current val of " + pnc.GetName() + " is " + pnc.GetVal());
            Thread.Sleep(1000);
        }

        public static void PNDecrement() {
            Console.WriteLine("Before Dec");
            pnc.Decrement();
            pn_val = pnc.GetVal();
            Console.WriteLine("After Dec");
            Console.WriteLine("Current val of " + pnc.GetName() + " is " + pnc.GetVal());
            Thread.Sleep(1000);        
        }

        public static void PNDecrement(int val) {
            Console.WriteLine("Before Dec by " + val);
            pnc.Decrement(val);
            pn_val = pnc.GetVal();
            Console.WriteLine("After Dec by" + val);
            Console.WriteLine("Current val of " + pnc.GetName() + " is " + pnc.GetVal());
            Thread.Sleep(1000);
        }
        
        public static void check() {
            for(;;) {
                if (g_val >= 7) {
                    GCIncrement(-2);
                }

                if (pn_val == 1) {
                    PNIncrement(6);
                }
                Thread.Sleep(1000);
            }
        }
    }
}