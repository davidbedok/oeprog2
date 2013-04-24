using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ForestCommunity.Api;
using ForestCommunity.Forest;

namespace ForestCommunity.Animals
{
    public class Rabbit : AbstractAnimal, CanPlant, CanIrrigate
    {

        public Rabbit(String name)
            : base(name)
        {

        }


        public override int restTime()
        {
            return 3;
        }

        public void plant(SeedBed seed)
        {
            this.startWork(seed, this.plantTime());
        }

        public int plantTime()
        {
            return 4;
        }

        public void irrigate(SeedBed seed)
        {
            this.startWork(seed, this.irrigateTime());
        }

        public int irrigateTime()
        {
            return 4;
        }

    }
}
