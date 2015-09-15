using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeDesignPattern
{
    public abstract class HtmlElement
    {

        private readonly String name;

        private String Begin
        {
            get { return "<" + this.name + ">"; }
        }

        private String End
        {
            get { return "</" + this.name + ">"; }
        }

        public HtmlElement(String name)
        {
            this.name = name;
        }

        public String GetValue()
        {
            return this.Begin + this.GetContent() + this.End;
        }

        protected abstract String GetContent();

        public override String ToString()
        {
            return this.GetValue();
        }

    }
}
