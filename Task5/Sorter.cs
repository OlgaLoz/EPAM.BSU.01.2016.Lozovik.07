using System;
using System.Collections.Generic;

namespace Task5
{
    public static class Sorter<T> 
    {
       private class AdapterComparision : IComparer<T>
        {
            private readonly Comparison<T> comparator;

            public AdapterComparision(Comparison<T> comparison)
            {
                comparator = comparison;
            }
            public int Compare(T x, T y)
            {
                return comparator(x, y);
            }
        }

        public static void Sort(T[] arrayToSort, IComparer<T> comparator)
        {
            if (arrayToSort == null)
            {
                throw new ArgumentNullException(nameof(arrayToSort));
            }
            
            if (comparator == null)
            {
                if (typeof(T).GetInterface("IComparable") != null)
                {
                    comparator = Comparer<T>.Default;
                }
                else
                {
                    throw new ArgumentNullException(nameof(comparator));
                }               
            }

            for (int i = 0; i < arrayToSort.Length - 1; i++)
            {
                for (int j = 0; j < arrayToSort.Length - i - 1; j++)
                {
                    if (comparator.Compare(arrayToSort[j], arrayToSort[j + 1]) > 0)
                    {
                        Swap(ref arrayToSort[j], ref arrayToSort[j + 1]);
                    }
                }
            }
        }

        public static void Sort(T[]arrayToSort, Comparison<T> comparator)
        {
            if (comparator == null)
            {
                if (typeof(T).GetInterface("IComparable") != null)
                {
                    IComparer<T> comparer = Comparer<T>.Default;
                    Sort(arrayToSort, comparer);
                }
                else
                {
                    throw new ArgumentNullException(nameof(comparator));
                }
            }
            else
            {
                AdapterComparision adapterComparision = new AdapterComparision(comparator);
                Sort(arrayToSort, adapterComparision);
            }
        }

        private static void Swap(ref T array1, ref T array2)
        {
            T tempArray = array1;
            array1 = array2;
            array2 = tempArray;
        }
    }
}
