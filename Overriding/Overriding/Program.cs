using Overriding.Argument;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Overriding
{
    class Program
    {
        public static void Main(string[] args)
        {
            BaseEntity baseEntity = new BaseEntity();
            BaseEntity childEntityA = new ChildEntity();
            ChildEntity childEntityB = new ChildEntity();

            baseEntity.publicMethod(); // base
            childEntityA.publicMethod(); // base --> hiding
            childEntityB.publicMethod(); // child --> overriding

            Console.WriteLine("Overriding test A:");
            Animal animal1 = childEntityA.publicDummyMethod(new Animal());
            Console.WriteLine("Overriding test B:");
            Animal animal2 = childEntityB.publicDummyMethod(new Animal());

            // formal parameter type can be covariant (any Crocodile can be an Animal --> auto cast)
            // return type can be contravariant in usage (any Animal can be Creature --> auto cast)
            Creature creature = childEntityA.publicDummyMethod(new Crocodile());
        }
    }
}
