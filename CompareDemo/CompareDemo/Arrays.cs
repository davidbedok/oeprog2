using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompareDemo
{
    public class Arrays
    {

        public static string toString<T>(String header, T[] data)
        {
            StringBuilder sb = new StringBuilder(50);
            sb.Append(header).AppendLine();
            foreach (T item in data)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }

    }
}
