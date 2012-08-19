using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SubjectTrunk
{
    public class SubjectTrunk : ITrunk
    {
        private Dictionary<string,Teacher> trunk;

        public SubjectTrunk()
        {
            this.trunk = new Dictionary<string, Teacher>();
        }

        public void addSubject(string subject, string teacherName, string teacherNeptunCode )
        {
            if (!this.trunk.ContainsKey(subject))
            {
                this.trunk.Add(subject, new Teacher(teacherName,teacherNeptunCode) );
            }
        }

        public void addStudentToSubject(string subject, string studentName, string studentNeptunCode)
        {
            if (this.trunk.ContainsKey(subject))
            {
                this.trunk[subject].addStudent(studentName, studentNeptunCode);
            }
        }

        public void addSubjectMarkToStudent(string subject, string studentNeptunCode, Mark mark)
        {
            if (this.trunk.ContainsKey(subject))
            {
                this.trunk[subject].addMarkToStudent(studentNeptunCode, mark);
            }
        }

        public string getPersonNameByNeptunCode(string neptunCode)
        {
            foreach (KeyValuePair<string, Teacher> entry in this.trunk)
            {
                string subject = entry.Key;
                Teacher teacher = entry.Value;
                if (teacher.NeptunCode.Equals(neptunCode))
                {
                    return teacher.Name;
                }
                else
                {
                    string studentName = teacher.getStudentNameByNeptunCode(neptunCode);
                    if (studentName != null)
                    {
                        return studentName;
                    }
                }
            }
            return "-1";
        }

        public Mark getTheBestMarkBySubject(string subject)
        {
            Mark ret = Mark.INSUFFICIENT;
            if (this.trunk.ContainsKey(subject))
            {
                ret = this.trunk[subject].getTheBestMark();
            }
            return ret;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<string, Teacher> entry in this.trunk)
            {
                string subject = entry.Key;
                Teacher teacher = entry.Value;
                sb.AppendLine("# " + subject + ":");
                sb.AppendLine(teacher.ToString());
            }
            return sb.ToString();
        }

    }
}
