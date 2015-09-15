using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeDesignPattern
{
    public class Program
    {
        private static void Main(string[] args)
        {
            TestContent();
        }

        private static void TestContent()
        {
            ParentNode head = new ParentNode("head").Append(new SingleNode("title", "UNI-OBUDA"));
            ParentNode body = new ParentNode("body").Append(new SingleNode("h1", "Hello World"));
            ParentNode root = new ParentNode("html").Append(head).Append(body);

            Console.WriteLine(root);
        }
    }
}
