using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SubjectTrunk
{
    public class Teacher : Person
    {
        private List<Student> students;

        public Teacher(string name, string neptunCode)
            : base(name, neptunCode)
        {
            this.students = new List<Student>();
        }

        private void addStudent(Student student)
        {
            if (!this.students.Contains(student))
            {
                this.students.Add(student);
            }
        }

        public void addStudent(string name, string neptunCode)
        {
            Student student = this.findStudent(neptunCode);
            if (student == null)
            {
                this.addStudent(new Student(name, neptunCode));
            }
        }

        private Student findStudent(string neptunCode)
        {
            Student ret = null;
            IEnumerator<Student> iterator = this.students.GetEnumerator();
            bool find = false;
            while (iterator.MoveNext() && !find)
            {
                Student student = iterator.Current;
                if (student.NeptunCode.Equals(neptunCode))
                {
                    ret = student;
                    find = true;
                }
            }
            return ret;
        }

        public string getStudentNameByNeptunCode(string neptunCode)
        {
            string ret = null;
            Student student = this.findStudent(neptunCode);
            if (student != null)
            {
                ret = student.Name;
            }
            return ret;
        }

        public void addMarkToStudent(string neptunCode, Mark mark)
        {
            Student student = this.findStudent(neptunCode);
            if (student != null)
            {
                student.addMark(mark);
            }
        }

        public Mark getTheBestMark()
        {
            Mark ret = Mark.INSUFFICIENT;
            foreach (Student student in this.students) 
            {
                Mark bestStudentMark = student.getTheBestMark();
                if ((int)bestStudentMark > (int)ret)
                {
                    ret = bestStudentMark;
                }
            }
            return ret;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            foreach (Student student in this.students)
            {
                sb.AppendLine("- " + student + " ");
            }
            return sb.ToString();
        }

    }
}
