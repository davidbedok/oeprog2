using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorkManager
{
    public abstract class AbstractWork<E> : Work<E>
    {

        protected readonly String workId;
        private readonly E[] items;
        private readonly List<E> checkList;

        public AbstractWork(String workId, params E[] items)
        {
            this.workId = workId;
            this.items = items;
            this.checkList = new List<E>();
            foreach (E item in items)
            {
                this.checkList.Add(item);
            }
        }

        public void updateProgress(E item)
        {
            if (this.checkList.Contains(item))
            {
                this.checkList.Remove(item);
                this.updateProgressDetails(item);
            }
            else
            {
                if (((IList<E>)items).Contains(item))
                {
                    throw new InvalidUpdateParameterException("You cannot update a parameter twice (" + item + ") (workId:" + this.workId + ")");
                }
                throw new InvalidUpdateParameterException("Parameter '" + item + "' is not valid for this work (workId:" + this.workId + ")");
            }
        }

        public abstract void updateProgressDetails(E item);

        public int getProgress()
        {
            return Convert.ToInt32(100 - (double)checkList.Count / (double)items.Length * 100);
        }

        public String getWorkId()
        {
            return this.workId;
        }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder(100);
            info.AppendLine(">>>> Work ID: " + this.workId + " <<<<");
            info.AppendLine("Progress: " + this.getProgress() + "%");
            info.AppendLine("Items: " + String.Join(", ", this.items));
            info.AppendLine("Checklist: " + String.Join(", ", this.checkList));
            return info.ToString();
        }

    }
}
