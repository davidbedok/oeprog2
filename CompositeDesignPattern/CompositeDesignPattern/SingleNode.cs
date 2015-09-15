using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeDesignPattern
{
    public class SingleNode : HtmlElement
    {

        private readonly String value;

        public SingleNode(String name, String value) : base(name)
        {
            this.value = value;
        }

        protected override String GetContent()
        {
            return this.value;
        }
    }
}
