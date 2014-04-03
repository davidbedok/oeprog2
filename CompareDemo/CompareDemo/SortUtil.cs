using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompareDemo
{
    public class SortUtil
    {

        public static void minimumSelectionSort(IComparable[] data)
        {
            if (data.Length > 0)
            {
                IComparable min;
                int minPos;
                for (int i = 0; i < data.Length - 1; i++)
                {
                    min = data[i];
                    minPos = i;
                    for (int j = i; j < data.Length; j++)
                    {
                        if (min.CompareTo(data[j]) > 0)
                        {
                            min = data[j];
                            minPos = j;
                        }
                    }
                    SortUtil.switchItems(data, i, minPos);
                }
            }
        }

        private static void switchItems(IComparable[] data, int aPos, int bPos)
        {
            IComparable tmp = data[aPos];
            data[aPos] = data[bPos];
            data[bPos] = tmp;
        }

    }
}
