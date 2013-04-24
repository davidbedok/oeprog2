using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ForestCommunity.Api;
using ForestCommunity.Forest;

namespace ForestCommunity.Animals
{
    public class Mole : AbstractAnimal, CanDig, CanStomp
    {

        public Mole(String name)
            : base(name)
        {

        }

        public override int restTime()
        {
            return 6;
        }

        public void dig(SeedBed seed)
        {
            this.startWork(seed, this.digTime());
        }

        public int digTime()
        {
            return 5;
        }

        public void stomp(SeedBed seed)
        {
            this.startWork(seed, this.stompTime());
        }

        public int stompTime()
        {
            return 3;
        }


    }
}
