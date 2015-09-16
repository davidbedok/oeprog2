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
            TestContent2();
        }

        private static void TestContent()
        {
            CompositeNode head = new CompositeNode("head").Append(new SingleNode("title", "UNI-OBUDA"));
            CompositeNode body = new CompositeNode("body").Append(new SingleNode("h1", "Hello World"));
            CompositeNode html = new CompositeNode("html").Append(head).Append(body);

            Console.WriteLine(html);
        }

        private static void TestContent2()
        {
            Head head = (Head) new Head().Append(new Title("UNI-OBUDA"));
            Body body = (Body) new Body().Append(new H1("Hello World"));
            Html html = (Html) new Html().Append(head).Append(body);

            Console.WriteLine(html);

            Html html2 = (Html) new Html().Append(new Head().Append(new Title("UNI-OBUDA"))).Append(new Body().Append(new H1("Hello World")));
            Console.WriteLine(html2);
        }

    }
}
