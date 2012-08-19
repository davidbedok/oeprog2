using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecursionAlg
{
    public class SequentialSearch
    {

        public static int process(int[] arr, int x)
        {     
            return (arr != null ? SequentialSearch.process(arr, 0, arr.Length, x) : -1);
        }

        //  If x is in L between indexes i and j, then output its index, else output -1
        private static int process(int[] arr, int i, int j, int x)
        {
            if (i < j)
            {
                if (arr[i++] == x)
                {
                    return --i;
                }
                else if (arr[--j] == x)
                {
                    return j;
                }
                else
                {
                    return SequentialSearch.process(arr, i, j, x);
                }
            }
            return -1;
        }

    }
}
