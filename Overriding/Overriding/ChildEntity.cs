using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Overriding
{
    public class ChildEntity : BaseEntity
    {

        public string publicFieldInBaseEntity; // hiding (can be different type and visibility [access modifiers])
        protected new int protectedFieldInBaseEntity; // intended hiding
        private int privateFieldInBaseEntity;

        public string PublicFieldInChildEntity
        {
            get { return publicFieldInBaseEntity; }
            set { publicFieldInBaseEntity = value; }
        }

        public int ProtectedFieldInChildEntity
        {
            get { return protectedFieldInBaseEntity; }
            set { protectedFieldInBaseEntity = value; }
        }

        public int PrivateFieldInChildEntity
        {
            get { return privateFieldInBaseEntity; }
            set { privateFieldInBaseEntity = value; }
        }

        public ChildEntity()
        {
            this.publicFieldInBaseEntity = "20";
            this.protectedFieldInBaseEntity = 20;
            this.privateFieldInBaseEntity = 20;
            /*
            base.publicFieldInBaseEntity = 15;
            base.protectedFieldInBaseEntity = 15;
            base.PrivateFieldInBaseEntity = 15;
            */
        }

        public void publicMethodInBaseEntity() // hiding
        {
            System.Console.WriteLine("Inside child: publicMethodInBaseEntity");
            // base.publicMethodInBaseEntity();
        }

        protected new void protectedMethodInBaseEntity() // intended hiding
        {
            System.Console.WriteLine("Inside child: protectedMethodInBaseEntity");
        }

        private void privateMethodInBaseEntity()
        {
            System.Console.WriteLine("Inside child: privateMethodInBaseEntity");
        }

        public override int publicOverrideTest(int param) // cannot change access modifiers
        {
            return param * 2;
        }

        protected override int protectedOverrideTest(int param)
        {
            return param * 2;
        }

        public override DummyMiddle overrideDummy(DummyMiddle param)
        {
            return param;
        }


        public DummyMiddle overrideDummy(DummyBase param) // overloading!
        { 
            return (DummyMiddle)param;
        }

        public DummyMiddle overrideDummy(DummyChild param) // overloading!
        {
            return param;
        }

    }
}
