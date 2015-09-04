using System;
using System.Diagnostics;

namespace PrimeChainFinder
{
    public static class RecieveChainHelper
    {
        public static Stopwatch Timer { get; set; }
        public static void RecieveTheChain(Chain theChain)
        {
            if (ChainFinder.IsAborted) Console.WriteLine("\n\nProcess was aborted. Here is what was currently found:");

            if (theChain != null)
            {
                Console.WriteLine("\n\nWas found next chain:");
                Console.WriteLine(theChain.ToString());
            }
            else Console.WriteLine("\nNo chains were found");
            Timer.Stop();
            Console.WriteLine("\nElapsed time, ms: " + Timer.ElapsedMilliseconds);
            Console.ReadLine();
        }
    }
}
