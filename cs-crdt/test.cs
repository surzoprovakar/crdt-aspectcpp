using System;
namespace cs_crdt {
    class Test {
        static void Main(string[] args) {
            GCounter gc = new GCounter("C1");
        
            gc.Increment();
            gc.Increment();
            gc.Increment();
            gc.Increment();
            gc.Increment(3);

            Console.WriteLine("Final Value: " + gc.GetVal());
            Console.WriteLine("############");

            PNCounter pnc = new PNCounter("C2");
            
            pnc.Increment(4);
            pnc.Increment();
            pnc.Decrement();
            pnc.Decrement();
            pnc.Decrement(2);

            Console.WriteLine("Final Value: " + pnc.GetVal());
        }
    }
}