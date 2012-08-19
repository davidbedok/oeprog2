using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Overriding
{
    public class BaseEntity : Object
    {
        public int publicFieldInBaseEntity;
        protected int protectedFieldInBaseEntity;
        private int privateFieldInBaseEntity;

        public int PublicFieldInBaseEntity
        {
            get { return publicFieldInBaseEntity; }
            set { publicFieldInBaseEntity = value; }
        }

        public int ProtectedFieldInBaseEntity
        {
            get { return protectedFieldInBaseEntity; }
            set { protectedFieldInBaseEntity = value; }
        }

        public int PrivateFieldInBaseEntity
        {
            get { return privateFieldInBaseEntity; }
            set { privateFieldInBaseEntity = value; }
        }

        public BaseEntity() : base()
        {
            this.publicFieldInBaseEntity = 10;
            this.protectedFieldInBaseEntity = 10;
            this.privateFieldInBaseEntity = 10;
        }

        public void publicMethodInBaseEntity()
        {
            System.Console.WriteLine("publicMethodInBaseEntity");
        }

        protected void protectedMethodInBaseEntity()
        {
            System.Console.WriteLine("protectedMethodInBaseEntity");
        }

        private void privateMethodInBaseEntity()
        {
            System.Console.WriteLine("privateMethodInBaseEntity");
        }

        // virtual or abstract method cannot be private
        public virtual int publicOverrideTest(int param)
        {
            return param * 2;
        }

        protected virtual int protectedOverrideTest(int param)
        {
            return param * 2;
        }

        public virtual DummyMiddle overrideDummy(DummyMiddle param)
        {
            return param;
        }

    }
}
