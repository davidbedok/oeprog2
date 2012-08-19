using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorkManager
{
    public class StringWork : AbstractWork<String>
    {

        public StringWork(String workId, params String[] items) : base(workId, items)
        {
           
        }

        public override void updateProgressDetails(String item)
        {
            System.Console.WriteLine("Update StringWork with '" + item + "' (workId: " + this.workId + ").\n");
        }

    }
}
