using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecursionAlg
{
    public class StringTransform
    {

        private static int check(string s)
        {
            int ret = -1;
            int i = 0;
            bool find = false;
            while ((i < (s.Length - 1)) && (!find))
            {
                if (s[i] == s[i + 1])
                {
                    find = true;
                    ret = i;
                }
                else
                {
                    i++;
                }
            }
            return ret;
        }

        private static string transform(string s, int index)
        {
            int tmp = Int32.Parse(s.Substring(index, 1));
            return s.Substring(0, index) + (tmp * 2).ToString() + s.Substring(index + 2);
        }

        public static string process(string s)
        {
            int index = StringTransform.check(s);
            if (index != -1)
            {
                return StringTransform.process(StringTransform.transform(s, index));
            }
            return s;
        }


    }
}
