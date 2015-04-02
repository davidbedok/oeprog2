using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicLists.entity
{
    public class IdentifierEquals
    {

        private readonly int serialNumber;
        private readonly String code;

        public int SerialNumber
        {
            get { return this.serialNumber; }
        }

        public String Code
        {
            get { return this.code; }
        }

        public IdentifierEquals(int serialNumber, String code)
        {
            this.serialNumber = serialNumber;
            this.code = code;
        }

        public override bool Equals(Object othat)
        {
            if (othat == null)
            {
                return false;
            }
            if (othat is IdentifierEquals)
            {
                IdentifierEquals that = othat as IdentifierEquals;
                return this.Equals(that);
            }
            return false;
        }

        public bool Equals(IdentifierEquals that)
        {
            if ((object)that == null)
            {
                return false;
            }
            if (that.serialNumber == this.serialNumber && that.code.Equals(this.code))
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return 13 * serialNumber;
        }

        public override string ToString()
        {
            return this.code + "-" + this.serialNumber;
        }



    }
}
