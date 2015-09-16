using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeDesignPattern
{
    public class Title : SingleNode
    {

        public Title(String value) : base("title", value) { }

    }
}
