using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeDesignPattern
{
    public class ParentNode : HtmlElement
    {

        private readonly List<HtmlElement> children;

        public ParentNode(String name)
            : base(name)
        {
            this.children = new List<HtmlElement>();
        }

        public ParentNode Append(HtmlElement child)
        {
            this.children.Add(child);
            return this;
        }

        protected override String GetContent()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine();
            foreach (HtmlElement element in this.children)
            {
                builder.AppendLine(element.GetValue());
            }
            return builder.ToString();
        }
    }
}
