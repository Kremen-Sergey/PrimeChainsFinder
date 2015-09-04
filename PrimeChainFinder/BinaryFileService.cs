using System;
using System.IO;

namespace PrimeChainFinder
{
    public static class BinaryFileService
    {
        #region Public methods

        #region Check if file Exists
        public static bool CheckForPath(string path)
        {
            return File.Exists(path);
        }
        #endregion

        #region Read data from binary file to array
        public static ulong[] ReadDataToArray(string path)
        {
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                int index = 0;
                long length = reader.BaseStream.Length;
                if (length % 6 != 0) length = length - (length % 6);
                ulong[] data = new ulong[length / 6 + 1];
                while (index <= length)
                {
                    byte[] buffer = new byte[6];
                    reader.Read(buffer, 0, 6);
                    data[index / 6] += ConvertToUlong(buffer);
                    index += 6;
                }
                Console.WriteLine("\nSource file at " + path + " has been loaded.");
                return data;
            }
        }
        #endregion

        #region Convert 6 byte numder to 8 byte ulong
        private static ulong ConvertToUlong(byte[] buffer)
        {
            ulong number = 0;
            for (int i = 0; i < 6; i++)
                number = (number << 8) + buffer[i];
            return number;
        }
        #endregion

        #region Create random binary file
        public static void GenerateRandomBinaryFile(string path)
        {
            Console.WriteLine("\nGenerating random binary file...");
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                Random random = new Random();
                for (int i = 0; i < 6005; i++)
                {
                    byte b=(byte)random.Next(255);
                    stream.Write(new byte[1]{b},0,1);
                }

                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 2 }, 0, 6);
                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 3 }, 0, 6);
                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 5 }, 0, 6);
                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 3 }, 0, 6);
                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 5 }, 0, 6);
                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 7 }, 0, 6);
                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 11 }, 0, 6);

                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 2 }, 0, 6);
                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 3 }, 0, 6);
                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 4 }, 0, 6);
                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 5 }, 0, 6);
                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 6 }, 0, 6);
                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 7 }, 0, 6);
                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 3 }, 0, 6);
                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 5 }, 0, 6);
                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 7 }, 0, 6);

                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 2 }, 0, 6);
                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 3 }, 0, 6);
                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 10 }, 0, 6);
                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 5 }, 0, 6);
                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 6 }, 0, 6);
                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 7 }, 0, 6);
                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 3 }, 0, 6);
                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 5 }, 0, 6);
                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 7 }, 0, 6);

                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 2 }, 0, 6);
                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 3 }, 0, 6);
                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 3 }, 0, 6);
                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 5 }, 0, 6);
                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 6 }, 0, 6);
                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 7 }, 0, 6);
                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 3 }, 0, 6);
                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 5 }, 0, 6);
                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 7 }, 0, 6);

                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 2 }, 0, 6);
                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 3 }, 0, 6);
                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 5 }, 0, 6);
                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 3 }, 0, 6);
                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 5 }, 0, 6);
                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 11 }, 0, 6);


                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 2 }, 0, 6);
                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 3 }, 0, 6);
                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 5 }, 0, 6);
                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 2 }, 0, 6);
                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 5 }, 0, 6);
                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 11 }, 0, 6);

                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 2 }, 0, 6);
                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 3 }, 0, 6);
                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 5 }, 0, 6);
                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 7 }, 0, 6);
                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 3 }, 0, 6);
                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 11 }, 0, 6);
                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 13 }, 0, 6);
                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 17 }, 0, 6);

                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 2 }, 0, 6);
                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 3 }, 0, 6);
                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 5 }, 0, 6);
                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 7 }, 0, 6);
                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 3 }, 0, 6);
                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 11 }, 0, 6);
                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 13 }, 0, 6);
                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 17 }, 0, 6);
                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 3 }, 0, 6);
                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 11 }, 0, 6);
                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 13 }, 0, 6);
                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 19 }, 0, 6);

                //stream.Write(new byte[5] { 0, 0, 0, 0, 1 }, 0, 5);

                //stream.Write(new byte[7] { 0, 0, 0, 0, 0, 3, 5 }, 0, 7);

                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 11 }, 0, 6);
                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 7 }, 0, 6);
                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 5 }, 0, 6);
                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 3 }, 0, 6);
                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 2 }, 0, 6);
                //stream.Write(new byte[6] { 0, 0, 0, 0, 0, 1 }, 0, 6);           
            }
            Console.WriteLine("Binary file successfully created at: " + path);
        }
        #endregion

        #endregion
    }
}
