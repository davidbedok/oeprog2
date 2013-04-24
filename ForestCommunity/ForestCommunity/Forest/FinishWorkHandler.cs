using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ForestCommunity.Api;
using ForestCommunity.Animals;

namespace ForestCommunity.Forest
{
    public class FinishWorkHandler : FinishWorkEvent
    {

        public Plantation plantation;

        public FinishWorkHandler(Plantation plantation)
        {
            this.plantation = plantation;
        }

        public void finish(AbstractAnimal animal)
        {
            Console.WriteLine("Finish work! " + animal);
            
        }

    }
}
