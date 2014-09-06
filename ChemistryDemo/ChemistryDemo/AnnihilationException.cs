using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChemistryDemo
{
    public class AnnihilationException : ApplicationException
    {

        public AnnihilationException(String message)
            : base(message)
        {

        } 

    }
}
