using Overriding.Argument;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Overriding
{
    public class ChildEntity : BaseEntity
    {

        public string publicField; // hiding (can be different type and visibility [access modifiers])
        protected new int protectedField; // intended hiding
        private int privateField;

        public string PublicFieldInChildEntity
        {
            get { return publicField; }
            set { publicField = value; }
        }

        public int ProtectedFieldInChildEntity
        {
            get { return protectedField; }
            set { protectedField = value; }
        }

        public int PrivateFieldInChildEntity
        {
            get { return privateField; }
            set { privateField = value; }
        }

        public ChildEntity() : base()
        {
            this.publicField = "20";
            this.protectedField = 20;
            this.privateField = 20;
            
            base.publicField = 15;
            base.protectedField = 15;
            base.PrivateFieldInBaseEntity = 15;
        }

        public void publicMethod() // hiding
        {
            Console.WriteLine("[CHILD] Public Method");
            base.publicMethod();
        }

        protected new void protectedMethod() // intended hiding
        {
            Console.WriteLine("[CHILD] Protected Method");
        }

        private void privateMethod()
        {
            System.Console.WriteLine("[CHILD] Private Method");
        }

        // cannot change access modifiers
        public override Animal publicDummyMethod(Animal animal)
        {
            Console.WriteLine("[CHILD] Public Dummy Method");
            animal.doItCreature();
            animal.doItAnimal();
            return animal;
        }

        // C# does not support return type covariance (workaround: call a hided method with 'covariance' return type)
        // public override Crocodile publicDummyMethod(Animal animal)...

        // return type contravariant is non-sense in implementation
        // public override Creature publicDummyMethod(Animal animal)...

        // C# does not support formal parameter type contravariance
        // public override Animal publicDummyMethod(Creature animal)

        // formal parameter type covariance is non-sense in implementation
        // public override Animal publicDummyMethod(Crocodile animal)

    }
}
