using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Taisiya
{
    class Student: Person
    {
        public Student(string FirstName, string MiddleName, string LastName, DateTime Birthday) :
            base(FirstName, MiddleName, LastName, Birthday)
        { }
    }
}
