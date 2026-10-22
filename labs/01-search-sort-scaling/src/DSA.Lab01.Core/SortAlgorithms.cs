using System;

namespace DSA.Lab01
{
    public static class SortAlgorithms
    {
        public static void InsertionSort(int[] values)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            int savedNum = 1;
            bool descending = false;

            for (int i = 0; i < values.Length; i = i)
            {
                if (i == 0)
                {
                    descending = false;
                    i = savedNum;
                }
                else
                {
                    if (values[i] < values[i - 1])
                    {
                        int val = values[i];
                        values[i] = values[i - 1];
                        values[i - 1] = val;
                        if (!descending)
                        {
                            savedNum = i;
                            descending = true;
                        }
                        i--;
                    }
                    else if (values[i] >= values[i - 1])
                    {
                        if (descending == true)
                        {
                            i = savedNum;
                            descending = false;
                        }
                        else
                        {
                            i++;
                        }
                    }
                }
            }
            // TODO: Sort the array in ascending order using insertion sort.
            //
            // Think of values[0..i-1] as the already-sorted part.
            // For each next value:
            // 1. Store the value you want to insert.
            // 2. Shift larger values one position to the right.
            // 3. Put the stored value into the gap.
        }
    }
}
