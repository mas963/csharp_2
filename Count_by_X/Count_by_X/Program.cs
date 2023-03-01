using System;

namespace Count_by_X
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // https://www.codewars.com/kata/5513795bd3fafb56c200049e/train/csharp
            CountBy(3, 5); // {3,6,9,12,15}
            Console.ReadKey();
        }

        public static int[] CountBy(int x, int n)
        {
            int[] z = new int[n];

            int arrayIndex = 0;
            int lastNumber = n * x;
            for (int i = x; i <= lastNumber; i += x)
            {
                z[arrayIndex] = i;
                arrayIndex++;
            }

            return z;
        }
    }
}
