using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SubjectTrunk
{
    public class Program
    {
        public static void addStudentToSubject(ITrunk trunk)
        {
            trunk.addStudentToSubject("Matematika", "Andras", "A12345");
            trunk.addStudentToSubject("Matematika", "Bela", "B12345");
            trunk.addStudentToSubject("Matematika", "Cecilia", "C12345");

            trunk.addStudentToSubject("Fizika", "Bela", "B12345");
            trunk.addStudentToSubject("Fizika", "Cecilia", "C12345");

            trunk.addStudentToSubject("Tortenelem", "Cecilia", "C12345");
            trunk.addStudentToSubject("Tortenelem", "Denes", "D12345");
        }

        public static void addSubjectMarkToStudent(ITrunk trunk)
        {
            trunk.addSubjectMarkToStudent("Matematika", "A12345", Mark.INSUFFICIENT);
            trunk.addSubjectMarkToStudent("Matematika", "A12345", Mark.MEDIUM);
            trunk.addSubjectMarkToStudent("Matematika", "B12345", Mark.GOOD);
            trunk.addSubjectMarkToStudent("Matematika", "C12345", Mark.EXCELLENT);
            trunk.addSubjectMarkToStudent("Matematika", "C12345", Mark.MEDIUM);

            trunk.addSubjectMarkToStudent("Fizika", "B12345", Mark.INSUFFICIENT);
            trunk.addSubjectMarkToStudent("Fizika", "C12345", Mark.MEDIUM);
            trunk.addSubjectMarkToStudent("Fizika", "C12345", Mark.GOOD);

            trunk.addSubjectMarkToStudent("Tortenelem", "D12345", Mark.MEDIUM);
        }

        public static void addSubjectMarkToStudentExpert(ITrunk trunk)
        {
            trunk.addSubjectMarkToStudent("Matematika", "A12345", Mark.INSUFFICIENT);
            trunk.addSubjectMarkToStudent("Matematika", "A12345", Mark.MEDIUM);
            trunk.addSubjectMarkToStudent("Matematika", "B12345", Mark.GOOD);
            trunk.addSubjectMarkToStudent("Matematika", "C12345", Mark.SUFFICIENT);
            trunk.addSubjectMarkToStudent("Matematika", "C12345", Mark.MEDIUM);

            trunk.addSubjectMarkToStudent("Fizika", "B12345", Mark.INSUFFICIENT);
            trunk.addSubjectMarkToStudent("Fizika", "C12345", Mark.MEDIUM);
            trunk.addSubjectMarkToStudent("Fizika", "C12345", Mark.GOOD);

            trunk.addSubjectMarkToStudent("Tortenelem", "D12345", Mark.MEDIUM);
        }

        public static void addOneSubjectMarkToOneStudent(ITrunk trunk)
        {
            trunk.addSubjectMarkToStudent("Matematika", "A12345", Mark.INSUFFICIENT);
            trunk.addSubjectMarkToStudent("Matematika", "A12345", Mark.MEDIUM);
            trunk.addSubjectMarkToStudent("Matematika", "A12345", Mark.GOOD);
            trunk.addSubjectMarkToStudent("Matematika", "A12345", Mark.MEDIUM);
        }

        public static void addOneSubjectMarkToStudent(ITrunk trunk)
        {
            trunk.addSubjectMarkToStudent("Matematika", "A12345", Mark.INSUFFICIENT);
            trunk.addSubjectMarkToStudent("Matematika", "A12345", Mark.MEDIUM);
            trunk.addSubjectMarkToStudent("Matematika", "B12345", Mark.GOOD);
            trunk.addSubjectMarkToStudent("Matematika", "C12345", Mark.EXCELLENT);
            trunk.addSubjectMarkToStudent("Matematika", "C12345", Mark.MEDIUM);
        }

        // out: Arnhoffer
        public static string Test001(ITrunk trunk)
        {
            return trunk.getPersonNameByNeptunCode("ARN100");
        }

        // out: Denes
        public static string Test002(ITrunk trunk)
        {
            Program.addStudentToSubject(trunk);
            return trunk.getPersonNameByNeptunCode("D12345");
        }

        // out: Cecilia
        public static string Test003(ITrunk trunk)
        {
            Program.addStudentToSubject(trunk);
            Program.addSubjectMarkToStudent(trunk);
            return trunk.getPersonNameByNeptunCode("C12345");
        }

        // out: INSUFFICIENT
        public static Mark Test004(ITrunk trunk)
        {
            Program.addStudentToSubject(trunk);
            return trunk.getTheBestMarkBySubject("Matematika");
        }

        // out: GOOD
        public static Mark Test005(ITrunk trunk)
        {
            Program.addStudentToSubject(trunk);
            Program.addOneSubjectMarkToOneStudent(trunk);
            return trunk.getTheBestMarkBySubject("Matematika");
        }

        // out: EXCELLENT
        public static Mark Test006(ITrunk trunk)
        {
            Program.addStudentToSubject(trunk);
            Program.addOneSubjectMarkToStudent(trunk);
            return trunk.getTheBestMarkBySubject("Matematika");
        }

        // out: EXCELLENT
        public static Mark Test007(ITrunk trunk)
        {
            Program.addStudentToSubject(trunk);
            Program.addSubjectMarkToStudent(trunk);
            return trunk.getTheBestMarkBySubject("Matematika");
        }

        // out: GOOD
        public static Mark Test008(ITrunk trunk)
        {
            Program.addStudentToSubject(trunk);
            Program.addSubjectMarkToStudentExpert(trunk);
            return trunk.getTheBestMarkBySubject("Matematika");
        }

        public static void Main(string[] args)
        {
            SubjectTrunk trunk = new SubjectTrunk();
            trunk.addSubject("Matematika", "NemecsekErno", "NE4312");
            trunk.addSubject("Fizika", "Arnhoffer", "ARN100");
            trunk.addSubject("Tortenelem", "Havasi", "HAV433");

            // System.Console.WriteLine(Program.Test001(trunk));
            // System.Console.WriteLine(Program.Test002(trunk));
            // System.Console.WriteLine(Program.Test003(trunk));
            // System.Console.WriteLine(Program.Test004(trunk));
            // System.Console.WriteLine(Program.Test005(trunk));
            // System.Console.WriteLine(Program.Test006(trunk));
            // System.Console.WriteLine(Program.Test007(trunk));
            System.Console.WriteLine(Program.Test008(trunk));
        }
    }
}
