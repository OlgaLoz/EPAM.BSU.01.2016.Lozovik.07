using System;
using System.Collections.Generic;

namespace Task4
{
    public class BinarySearchLib<T>
    {
        public static int BinarySearch(T[] array, T value, IComparer<T> comparer )
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (comparer == null)
            {
                if (typeof(T).GetInterface("IComparable") != null)
                {
                    comparer = Comparer<T>.Default;
                }
                else
                {
                    throw new ArgumentNullException(nameof(comparer));
                }
            }

            return BinarySearchSafe(array, value, comparer);
        }

        private static int BinarySearchSafe(T[] array, T value, IComparer<T> comparer)
        {
            int result = -1;
            int first = 0;
            int last = array.Length;

            while (first < last)
            {
                int middle = first + (last - first) / 2;

                if (comparer.Compare(value, array[middle]) == 0)
                {
                    result = middle;
                    break;
                }

                if (comparer.Compare(value, array[middle]) == 1)
                {
                    first = middle + 1;
                }
                else
                {
                    if (comparer.Compare(value, array[middle]) == -1)
                    {
                        last = middle;
                    }
                }
            }
            return result;
        }
    }
}
