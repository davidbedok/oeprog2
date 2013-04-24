using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ForestCommunity.Animals;

namespace ForestCommunity.Api
{
    public interface FinishWorkEvent
    {

        void finish(AbstractAnimal animal);

    }
}
