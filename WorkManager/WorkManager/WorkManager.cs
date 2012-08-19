using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorkManager
{
    public class WorkManager
    {

        private Dictionary<String, Object> works;

        public WorkManager()
        {
            this.works = new Dictionary<String, Object>();
        }

        public String createWork<T>(params T[] items)
        {
            String workId = System.Guid.NewGuid().ToString();
            if (typeof(T) == typeof(String))
            {
                String[] parameters = (String[])Convert.ChangeType(items, typeof(String[]));
                StringWork work = new StringWork(workId, parameters);
                System.Console.WriteLine("Create StringWork: " + work.ToString());
                this.works.Add(workId, work);
            }
            else if (typeof(T) == typeof(Int32))
            {
                Int32[] parameters = (Int32[])Convert.ChangeType(items, typeof(Int32[]));
                IntegerWork work = new IntegerWork(workId, parameters);
                System.Console.WriteLine("Create IntegerWork: " + work.ToString());
                this.works.Add(workId, work);
            }
            return workId;
        }

        public int getWorkProgress(String workId)
        {
            int progress = 0;
            if (this.works.ContainsKey(workId))
            {
                if (this.works[workId] is StringWork)
                {
                    progress = ((StringWork)this.works[workId]).getProgress();
                }
                else if (this.works[workId] is IntegerWork)
                {
                    progress = ((IntegerWork)this.works[workId]).getProgress();
                }
            }
            else
            {
                throw new WorkManagerException("Work with id " + workId + " doesn't exists.");
            }
            return progress;
        }

        public void updateWorkProgress<T>(String workId, T item)
        {
            if (this.works.ContainsKey(workId))
            {
                if (this.works[workId] is Work<T>)
                {
                    ((Work<T>)this.works[workId]).updateProgress(item);
                }
                else
                {
                    throw new WorkManagerException("Cast exception. Work with id " + workId + " and parameter with type " + typeof(T) + " (value: '" + item + "').");
                }
            }
            else
            {
                throw new WorkManagerException("Work with id " + workId + " doesn't exists.");
            }
        }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder(200);
            info.AppendLine("========= WORK MANAGER =========");
            foreach (KeyValuePair<String, Object> entry in this.works)
            {
                info.Append(entry.Value.ToString());
            }
            info.AppendLine("====================================");
            return info.ToString();
        }


    }
}
