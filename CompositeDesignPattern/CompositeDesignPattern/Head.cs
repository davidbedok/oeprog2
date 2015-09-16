using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeDesignPattern
{
    public class Head : CompositeNode
    {

        public Head() : base("head")
        {

        }

        public static Head Create()
        {
            return new Head();
        }

    }
}
