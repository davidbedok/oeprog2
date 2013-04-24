using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ForestCommunity.Api;

namespace ForestCommunity.Forest
{
    public class SeedBed
    {

        private readonly String id;
        private BedStatus status;
        private bool onWork;

        public bool IsWork
        {
            get { return this.onWork; }
        }

        public BedStatus Status
        {
            get { return this.status; }
        }

        public SeedBed( String id )
        {
            this.id = id;
            this.status = BedStatus.E0;
            this.onWork = false;
        }

        public void stepStatus()
        {
            if (status != BedStatus.I4)
            {
                this.status = (BedStatus)(((int)this.status) + 1);
            }
            this.onWork = false;
        }

        public void work()
        {
            this.onWork = true;
        }

        public override string ToString()
        {
            return this.status.ToString();
        }

    }
}
