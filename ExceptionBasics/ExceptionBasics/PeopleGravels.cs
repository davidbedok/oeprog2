using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExceptionBasics
{
    // emberek kavicsai
    public class PeopleGravels : AbstractHolder
    {
        // instance holds people's gravels
        // element of the set is represented the number of gravels
        // a set can be empty (number of gravels is zero)
        // each set contains at least 0 gravel

        public PeopleGravels() : base()
        {
            for (int i = 0; i < this.data.Length; i++)
            {
                this.data[i] = -1;
            }
        }

        protected override void checkWhileAdd(int content)
        {
            if (content < 0)
            {
                throw new System.ArgumentException("Number of gravels cannot be less than zero. (numberOfGravels: " + content + ")");
            }
        }

        protected override void checkWhileRead() { }

    }
}
