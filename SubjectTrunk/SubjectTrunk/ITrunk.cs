using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SubjectTrunk
{
    public interface ITrunk
    {
        void addSubject(string subject, string teacherName, string teacherNeptunCode);
        void addStudentToSubject(string subject, string studentName, string studentNeptunCode);
        void addSubjectMarkToStudent(string subject, string studentNeptunCode, Mark mark);
        string getPersonNameByNeptunCode(string neptunCode);
        Mark getTheBestMarkBySubject(string subject);
    }
}
