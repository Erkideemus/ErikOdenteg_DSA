using System;
using System.Linq;

namespace DSA.Lab01
{
    public static class SearchAlgorithms
    {
        public static int LinearSearch(int[] values, int target)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            for (int i = 0; i < values.Length; ++i)
            {
                if (values[i] == target)
                {
                    return i;
                }
            }

            return -1;
        }

        public static int BinarySearch(int[] sortedValues, int target)
        {
            if (sortedValues == null)
            {
                throw new ArgumentNullException(nameof(sortedValues));
            }

            int point = sortedValues.Length / 2;

            for (int i = 0; i < sortedValues.Length; i++)
            {
                int val = sortedValues[point];

                if (val == target)
                {
                    return point;
                }

                if (val < target)
                {
                    target = target / 2; 
                }
                else
                {
                    target += target / 2;
                }
            }

            /*int lowerHalf = 0;
            int HighestHalf = sortedValues.Length - 1;

            while (lowerHalf <= HighestHalf)
            {
                int point = lowerHalf + ((HighestHalf - lowerHalf) / 2);
                int val = sortedValues[point];

                if (val == target)
                {
                    return point;
                }

                if (val < target)
                {
                    lowerHalf = point + 1;
                }
                else
                {
                    HighestHalf = point - 1;
                }
            }*/

            // TODO: Implement binary search.
            // The input to this method is guaranteed to be sorted in ascending order.
            //
            // Suggested plan:
            // 1. Keep track of a low and high index.
            // 2. Inspect the middle value.
            // 3. Return the index if it matches.
            // 4. Otherwise discard either the lower or upper half.
            // 5. Repeat while there is still a valid search range.
            return -1;
        }
    }
}
