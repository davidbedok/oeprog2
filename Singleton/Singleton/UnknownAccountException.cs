using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class UnknownAccountExceotion : ApplicationException
    {

        public UnknownAccountExceotion(String accountNumber)
            : base("Unknown account (number: " + accountNumber + ")")
        {
        }

    }
}
