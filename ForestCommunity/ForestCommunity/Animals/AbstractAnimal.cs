using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ForestCommunity.Api;
using ForestCommunity.Forest;

namespace ForestCommunity.Animals
{
    public abstract class AbstractAnimal
    {
        private String name;
        protected AnimalStatus status;
        protected int progressTime;
        private FinishWorkEvent finishEvent;
        protected SeedBed seed;

        public AnimalStatus Status
        {
            get { return this.status; }
        }

        public FinishWorkEvent FinishEvent
        {
            set { this.finishEvent = value; }
        }

        public AbstractAnimal(String name)
        {
            this.name = name;
            this.progressTime = 0;
            this.status = AnimalStatus.Wait;
            this.seed = null;
        }

        public abstract int restTime();

        public void tick()
        {
            if (this.progressTime > 0)
            {
                this.progressTime--;
                if (this.progressTime == 0 && this.status == AnimalStatus.Work && this.finishEvent != null)
                {
                    this.finishEvent.finish(this);
                    this.seed.stepStatus();
                    this.status = AnimalStatus.Rest;
                    this.progressTime = this.restTime();
                }
                else if (this.progressTime == 0 && this.status == AnimalStatus.Rest && this.finishEvent != null)
                {
                    this.finishEvent.finish(this);
                    this.status = AnimalStatus.Wait;
                }
            }
        }

        protected void startWork(SeedBed seed, int time)
        {
            this.progressTime = time;
            this.status = AnimalStatus.Work;
            this.seed = seed;
        }

        public override string ToString()
        {
            return this.name + " - " + this.status + " time: " + this.progressTime + " seed: " + this.seed;
        }

    }
}
