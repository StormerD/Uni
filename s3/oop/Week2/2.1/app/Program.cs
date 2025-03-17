using System;
namespace CounterTask {
    public class Program {
        // defines PrintCounters method
        private static void PrintCounters(Counter[] counters) {
            foreach(Counter c in counters) {
                // Console.WriteLine(c.Name + " is " c.Ticks)
                Console.WriteLine("{0} is {1}", c.Name, c.Ticks);
            }
        }

        // defines main method
        static void Main(string[] args) {
            // Task 2.1
            // Counter[] myCounters = new Counter[3];
            // myCounters[0] = new Counter("Counter 1");
            // myCounters[1] = new Counter("Counter 2");
            // myCounters[2] = myCounters[0];
            // for(int i = 1; i <= 9; i++) {
            //     myCounters[0].Increment();
            // }
            // for(int i = 1; i <= 14; i++) {
            //     myCounters[1].Increment();
            // }
            // PrintCounters(myCounters);
            // myCounters[2].Reset();
            // PrintCounters(myCounters);

            // Task 2.1 Option 2
            Counter[] myCounters = new Counter[19];
            // defines created counters
            for(int i = 0; i < 19; i++) {
                Random random = new Random();
                int newLimit = random.Next(0, 101);
                myCounters[i] = new Counter("Counter " + i, newLimit);
                Console.WriteLine(myCounters[i].Name + ", Limit: " + myCounters[i].Limit);
            }
            // loop
            for(int i = 0; i <= 100; i++) {
                foreach(Counter c in myCounters) {
                    c.Increment();
                    if (c.Ticks >= c.Limit) {
                        c.Reset();
                        Console.WriteLine(c.Name + " reset on loop " + i);
                    }
                }
            }
        }
    }
}