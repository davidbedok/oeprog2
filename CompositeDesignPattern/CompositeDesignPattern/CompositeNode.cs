using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeDesignPattern
{
    public class CompositeNode : Node
    {

        private readonly List<Node> children;

        public CompositeNode(String name)
            : base(name)
        {
            this.children = new List<Node>();
        }

        public CompositeNode Append(Node child)
        {
            this.children.Add(child);
            return this;
        }

        protected override String GetContent()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine();
            foreach (Node element in this.children)
            {
                builder.AppendLine(element.ToString());
            }
            return builder.ToString();
        }
    }
}
