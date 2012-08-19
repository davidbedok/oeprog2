using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LancoltListaEpam
{
    public class Program
    {

        public static int GetWindowSum(Node[] window)
        {
            int ret = 0;
            for (int i = 0; i < window.Length; i++)
            {
                ret += window[i].Value;
                System.Console.Write(window[i].Value+ "+");
            }
            System.Console.WriteLine("=" + ret);
            return ret;
        }

        // windowSize min 2 (kort nem kezeli)
        public static int MaxWindowValue(Node item, int windowSize)
        {
            int max = 0;
            if ((item != null) && (windowSize > 1))
            {
                Node[] window = new Node[windowSize];
                Node actNode = item;
                int num = 0;
                for (int i = 0; i < windowSize; i++)
                {
                    if (actNode.HasNode())
                    {
                        window[i] = actNode;
                        actNode = actNode.Next;
                        num++;
                    }
                }
                if (num == windowSize)
                {
                    max = Program.GetWindowSum(window);
                    while (actNode.HasNode())
                    {

                        for (int i = 0; i < (windowSize - 1); i++)
                        {
                            window[i] = window[i + 1];
                        }
                        window[windowSize - 1] = actNode;
                        int tmpMax = Program.GetWindowSum(window);
                        if (max < tmpMax)
                        {
                            max = tmpMax;
                        }
                        actNode = actNode.Next;
                    }
                }
            }
            return max;
        }

        public static void Main(string[] args)
        {
            Node item0 = new Node(10);
            Node item1 = new Node(15,item0);
            Node item2 = new Node(4,item1);
            Node item3 = new Node(7,item2);
            Node item4 = new Node(9,item3);
            Node item5 = new Node(12,item4);
            Node item6 = new Node(16,item5);
            Node item7 = new Node(-5,item6);

            System.Console.WriteLine(item7.ToString());
            System.Console.WriteLine("MaxWindowValue:"+Program.MaxWindowValue(item7,3));

        }
    }
}
