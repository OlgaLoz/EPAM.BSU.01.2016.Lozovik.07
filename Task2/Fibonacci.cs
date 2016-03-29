using System;
using System.Collections.Generic;

namespace Task2
{
    public static class Fibonacci
    {
        public static IEnumerable<int> CountFibonacci(int position)
        {
            if (position <= 0)
            {
                throw new ArgumentException("Fibonacci number position must be above zero!");
            }

            int number = 0;
            int lastNumber = 1;

            for (int i = 0; i < position; i++)
            {
                int tempNumber = number;
                number += lastNumber;
                lastNumber = tempNumber;

                yield return number;
            }
        }
    }
}
