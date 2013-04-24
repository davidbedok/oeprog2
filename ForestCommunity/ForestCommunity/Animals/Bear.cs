using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ForestCommunity.Api;
using ForestCommunity.Forest;

namespace ForestCommunity.Animals
{
    public class Bear : AbstractAnimal, CanPlant, CanStomp
    {

        public Bear(String name)
            : base(name)
        {

        }

        public override int restTime()
        {
            return 6;
        }

        public void plant(SeedBed seed)
        {
            this.startWork(seed, this.plantTime());
        }

        public int plantTime()
        {
            return 2;
        }

        public void stomp(SeedBed seed)
        {
            this.startWork(seed, this.stompTime());
        }

        public int stompTime()
        {
            return 2;
        }



    }
}
