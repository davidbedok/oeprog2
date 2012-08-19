using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Initblocks
{
    public abstract class Parent : System.Object
    {
        protected static int test;

        private readonly int foo;
        private readonly char bar;

        public int Foo
        {
            get { return this.foo; }
        }

        public char Bar
        {
            get { return this.bar; }
        }

        // statikus inicializalo blokk, az osztaly eleteben egyszer fut le
        // parametere nem lehet
        static Parent() {
            System.Console.WriteLine("initialization code");
            Parent.test = 42;
        }

        public Parent(int foo, char bar)
        {
            this.foo = foo;
            this.bar = bar;
        }

        public override string ToString()
        {
            return this.foo + " " + this.bar;
        }

    }
}
