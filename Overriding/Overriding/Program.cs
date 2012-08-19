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
            ChildEntity child = new ChildEntity();
            System.Console.WriteLine("PublicFieldInBaseEntity: " + child.PublicFieldInBaseEntity);
            System.Console.WriteLine("PublicFieldInChildEntity: " + child.PublicFieldInChildEntity);

            System.Console.WriteLine("ProtectedFieldInBaseEntity: " + child.ProtectedFieldInBaseEntity);
            System.Console.WriteLine("ProtectedFieldInChildEntity: " + child.ProtectedFieldInChildEntity);

            System.Console.WriteLine("PrivateFieldInBaseEntity: " + child.PrivateFieldInBaseEntity);
            System.Console.WriteLine("PrivateFieldInChildEntity: " + child.PrivateFieldInChildEntity);

            child.publicMethodInBaseEntity();
            System.Console.WriteLine("publicOverloadTest(42): " + child.publicOverrideTest(42));

            child.overrideDummy(new DummyMiddle());
            // child.overrideDummy(new DummyBase()); // invalid cast ('cos bad implementation..)
            child.overrideDummy(new DummyChild());

        }
    }
}
