using Overriding.Argument;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Overriding
{
    public class BaseEntity : Object
    {
        public int publicField;
        protected int protectedField;
        private int privateField;

        public int PublicFieldInBaseEntity
        {
            get { return publicField; }
            set { publicField = value; }
        }

        public int ProtectedFieldInBaseEntity
        {
            get { return protectedField; }
            set { protectedField = value; }
        }

        public int PrivateFieldInBaseEntity
        {
            get { return privateField; }
            set { privateField = value; }
        }

        public BaseEntity() : base()
        {
            this.publicField = 10;
            this.protectedField = 10;
            this.privateField = 10;
        }

        public void publicMethod()
        {
            Console.WriteLine("[BASE] Public Method");
        }

        protected void protectedMethod()
        {
            Console.WriteLine("[BASE] Protected Method");
        }

        private void privateMethod()
        {    
            Console.WriteLine("[BASE] Private Method");
        }

        // virtual or abstract method cannot be private
        public virtual Animal publicDummyMethod(Animal animal)
        {
            Console.WriteLine("[BASE] Public Dummy Method");
            animal.doItCreature();
            animal.doItAnimal();
            return animal;
        }

    }
}
