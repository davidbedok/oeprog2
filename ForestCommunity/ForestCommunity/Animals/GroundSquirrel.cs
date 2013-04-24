using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ForestCommunity.Api;
using ForestCommunity.Forest;

namespace ForestCommunity.Animals
{
    public class GroundSquirrel : AbstractAnimal, CanDig, CanIrrigate
    {

        public GroundSquirrel(String name)
            : base(name)
        {

        }

        public override int restTime()
        {
            return 3;
        }

        public void dig(SeedBed seed)
        {
            this.startWork(seed, this.digTime());
        }

        public int digTime() {
            return 7;
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
