using System;
using System.Threading.Tasks;

namespace PrimeChainFinder
{
    public static class ChainFinder
    {

        #region Fields
        private static ulong[] dataArray;
        private static int progress;
        public static bool IsAborted { get; set; }
        #endregion
        
        #region Public methods

        #region Check all number in array for being prime
        public static void StartCheckForPrime(ulong[] data)
        {
            dataArray = data;
            progress = 0;
            Console.WriteLine("\nSearch is in process... Press Q to abort");
            Task[] tasks = new Task[dataArray.Length];
            for (int i = 0; i < dataArray.Length; i++)
            {
                int indexCache = i;
                tasks[indexCache] = Task.Run(() => IsPrime(dataArray[indexCache], indexCache));
            }
            Task.WaitAll(tasks);
            if (!IsAborted) FindChain();
        }
        #endregion

        #region Find best match in chains
        public static void FindChain()
        {
            Chain etalonChain = null;
            Chain currentChain = null;
            for (ulong i = 0; i < (ulong)dataArray.Length; i++)
            {
                if (dataArray[i] != 0)
                {
                    ulong displacement = i;
                    if (currentChain == null)
                    {
                        currentChain = new Chain(dataArray[i], displacement);
                    }
                    else if (dataArray[i] > currentChain.LastElement.GetValueOrDefault())
                    {
                        currentChain.AddElement(dataArray[i], displacement);
                    }
                    else
                    {
                        if (CompareChains(currentChain, etalonChain))
                        {
                            etalonChain = currentChain;
                        }
                        currentChain = new Chain(dataArray[i], displacement);
                    }
                }
            }
            if (currentChain != null)
            {
                if (CompareChains(currentChain, etalonChain))
                    etalonChain = currentChain;
            }
            Console.Write("\rProgress: 100%  ");
            if (etalonChain != null)
                RecieveChainHelper.RecieveTheChain(etalonChain);
            else RecieveChainHelper.RecieveTheChain(null);
        }
        #endregion

        #endregion

        #region Private methods

        #region Check if number is prime and replace not prime numbers with 0
        private static void IsPrime(ulong number, int index)
        {
            if (number == 1 || !IsOddOrTwo(number)) dataArray[index] = 0;
            else
            {
                for (ulong i = 3; (i * i) <= number; i += 2)
                    if ((number % i) == 0) dataArray[index] = 0;
            }
            progress++;
            if (!IsAborted) Console.Write("\rProgress: " + (progress * 100 / dataArray.Length) + "%  ");
        }
        #endregion

        #region Check if numbet is odd or 2
        private static bool IsOddOrTwo(ulong number)
        {
            if ((number & 1) == 0)
            {
                if (number == 2) return true;
                return false;
            }
            return true;
        }
        #endregion

        #region Compare 2 Chains. Function return true if chain 1 match better then chain 2 to condition of the problem
        private static bool CompareChains(Chain chain1, Chain chain2)
        {
            if ((chain1 == null) && (chain2 == null)) return false;
            if ((chain1 != null) && (chain2 == null)) return true;
            if ((chain1 == null) && (chain2 != null)) return false;
            if (chain1.Length > chain2.Length) return true;
            if (chain1.Length < chain2.Length) return false;
            if (chain1.FirstElement > chain2.FirstElement) return true;
            if (chain1.FirstElement < chain2.FirstElement) return false;
            if (chain1.FirstElementDisplacement < chain2.FirstElementDisplacement) return true;
            return false;
        }
        #endregion

        #endregion
    }
}
