using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForestCommunity.Api
{
    public class NoMoreWorkSeedBedException : ApplicationException
    {

        public NoMoreWorkSeedBedException( String message ) : base(message)
        {

        }

    }
}
