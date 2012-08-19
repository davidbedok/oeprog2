using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryBookPerson
{
    public interface IPerson
    {
        Int32 ID { get; }
        String Name { get; }
        DateTime EnrollmentDate { get; }

        void regenerateEnrollment(DateTime newEnrollmentDate);
    }
}
