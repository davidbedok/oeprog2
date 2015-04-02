using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicLists.entity
{
    public class Identifier
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

        public Identifier(int serialNumber, String code)
        {
            this.serialNumber = serialNumber;
            this.code = code;
        }

        public override string ToString()
        {
            return this.code + "-" + this.serialNumber;
        }



    }
}
