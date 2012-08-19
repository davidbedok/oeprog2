using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SubjectTrunk
{
    public class Student : Person
    {

        private List<Mark> marks;

        public Student(string name, string neptunCode)
            : base(name, neptunCode)
        {
            this.marks = new List<Mark>();
        }

        public void addMark(Mark mark)
        {
            this.marks.Add(mark);
        }

        public Mark getTheBestMark()
        {
            Mark ret = Mark.INSUFFICIENT;
            foreach (Mark mark in this.marks)
            {
                if ((int)mark > (int)ret)
                {
                    ret = mark;
                }
            }
            return ret;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString()+ " ( ");
            foreach (Mark mark in this.marks)
            {
                sb.Append(mark+" ");
            }
            sb.Append(")");
            return sb.ToString();
        }

    }
}
