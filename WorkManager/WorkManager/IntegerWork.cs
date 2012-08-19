using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorkManager
{
    public class IntegerWork : AbstractWork<Int32>
    {

        public IntegerWork(String workId, params Int32[] items)
            : base(workId, items)
        {
           
        }

        public override void updateProgressDetails(Int32 item)
        {
            System.Console.WriteLine("Update IntegerWork with '" + item + "' (workId: " + this.workId + ").\n");
        }

    }
}
