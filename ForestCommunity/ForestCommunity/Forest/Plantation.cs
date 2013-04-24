using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ForestCommunity.Animals;
using ForestCommunity.Api;

namespace ForestCommunity.Forest
{
    public class Plantation
    {

        private List<SeedBed> seeds;
        private List<AbstractAnimal> animals;
        private FinishWorkHandler handler;

        public Plantation( int numOfSeeds, int numOfAnimals )
        {
            this.handler = new FinishWorkHandler(this);
            this.seeds = new List<SeedBed>();
            for (int i = 0; i < numOfSeeds; i++)
            {
                this.seeds.Add(new SeedBed("S" + i));
            }
            this.animals = new List<AbstractAnimal>();
            for (int i = 0; i < numOfAnimals; i++)
            {
                this.animals.Add(new Bear("B" + i));
                this.animals.Add(new GroundSquirrel("G" + i));
                this.animals.Add(new Mole("M" + i));
                this.animals.Add(new Rabbit("R" + i));
            }
        }

        public void tick()
        {
            this.dig();
            this.plant();
            this.stomp();
            this.irrigate();
            foreach (AbstractAnimal animal in this.animals)
            {
                animal.tick();
            }
            if (this.allWorkDone())
            {
                throw new NoMoreWorkSeedBedException("");
            }
        }

        public bool allWorkDone()
        {
            bool ret = true;
            foreach (SeedBed seed in this.seeds)
            {
                if (seed.Status != BedStatus.I4)
                {
                    ret = false;
                    break;
                }
            }
            return ret;
        }

        public void dig()
        {
            List<CanDig> canDigAnimals = this.canDigAnimals();
            foreach (CanDig canDigAnimal in canDigAnimals)
            {
                SeedBed seed = this.nextSeed(BedStatus.E0);
                if (seed != null)
                {
                    canDigAnimal.dig(seed);
                    (canDigAnimal as AbstractAnimal).FinishEvent = this.handler;
                }
            }
        }

        public List<CanDig> canDigAnimals()
        {
            List<CanDig> ret = new List<CanDig>();
            foreach (AbstractAnimal animal in this.animals)
            {
                if ( animal is CanDig && animal.Status == AnimalStatus.Wait )
                {
                    ret.Add(animal as CanDig);
                }
            }
            return ret;
        }

        public void plant()
        {
            List<CanPlant> canDigAnimals = this.canPlantAnimals();
            foreach (CanPlant canDigAnimal in canDigAnimals)
            {
                SeedBed seed = this.nextSeed(BedStatus.D1);
                if (seed != null)
                {
                    canDigAnimal.plant(seed);
                    (canDigAnimal as AbstractAnimal).FinishEvent = this.handler;
                }
            }
        }

        public List<CanPlant> canPlantAnimals()
        {
            List<CanPlant> ret = new List<CanPlant>();
            foreach (AbstractAnimal animal in this.animals)
            {
                if (animal is CanPlant && animal.Status == AnimalStatus.Wait)
                {
                    ret.Add(animal as CanPlant);
                }
            }
            return ret;
        }

        public void stomp()
        {
            List<CanStomp> canDigAnimals = this.canStompAnimals();
            foreach (CanStomp canDigAnimal in canDigAnimals)
            {
                SeedBed seed = this.nextSeed(BedStatus.P2);
                if (seed != null)
                {
                    canDigAnimal.stomp(seed);
                    (canDigAnimal as AbstractAnimal).FinishEvent = this.handler;
                }
            }
        }

        public List<CanStomp> canStompAnimals()
        {
            List<CanStomp> ret = new List<CanStomp>();
            foreach (AbstractAnimal animal in this.animals)
            {
                if (animal is CanStomp && animal.Status == AnimalStatus.Wait)
                {
                    ret.Add(animal as CanStomp);
                }
            }
            return ret;
        }

        public void irrigate()
        {
            List<CanIrrigate> canDigAnimals = this.canIrrigateAnimals();
            foreach (CanIrrigate canDigAnimal in canDigAnimals)
            {
                SeedBed seed = this.nextSeed(BedStatus.S3);
                if (seed != null)
                {
                    canDigAnimal.irrigate(seed);
                    (canDigAnimal as AbstractAnimal).FinishEvent = this.handler;
                }
            }
        }

        public List<CanIrrigate> canIrrigateAnimals()
        {
            List<CanIrrigate> ret = new List<CanIrrigate>();
            foreach (AbstractAnimal animal in this.animals)
            {
                if (animal is CanIrrigate && animal.Status == AnimalStatus.Wait)
                {
                    ret.Add(animal as CanIrrigate);
                }
            }
            return ret;
        }

        public SeedBed nextSeed( BedStatus status )
        {
            SeedBed ret = null;
            foreach (SeedBed seed in this.seeds)
            {
                if (seed.Status == status && !seed.IsWork ) 
                {
                    seed.work();
                    ret = seed;
                    break;
                }
            }
            return ret;
        }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder(50);
            foreach (SeedBed seed in this.seeds)
            {
                info.Append(seed).Append(" ");
            }
            info.AppendLine();
            foreach (AbstractAnimal animal in this.animals)
            {
                info.AppendLine(animal.ToString());
            }
            return info.ToString();
        }


    }
}
