using System;
using System.Threading.Tasks;
using System.Diagnostics;

namespace PrimeChainFinder
{
    public class Program
    {
        private static void Main(string[] args)
        {
            string binFilePath="";
            Console.WriteLine("Program started.");
            ConsoleKeyInfo cki;
            if (args.Length == 0 || !BinaryFileService.CheckForPath(args[0]))
            {
                Console.WriteLine("\nSource file was not found. Do you want to auto-generate a random one in the current directory? y/n");
                cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.Y)
                {
                    binFilePath = Environment.CurrentDirectory + @"\randomFile.bin";
                    BinaryFileService.GenerateRandomBinaryFile(binFilePath);
                }
                else Environment.Exit(0);
            }
            else 
            binFilePath = args[0];
            RecieveChainHelper.Timer = new Stopwatch();
            RecieveChainHelper.Timer.Start();
            Task.Run(() => ChainFinder.StartCheckForPrime(BinaryFileService.ReadDataToArray(binFilePath)));
            cki = Console.ReadKey(true);
            if (cki.Key == ConsoleKey.Q)
            {
                ChainFinder.IsAborted = true;
                ChainFinder.FindChain();               
            }
        }
    }
}
