using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Taisiya
{
    class Teacher: Person
    {
        private PositionType position;

        public Teacher(string FirstName, string MiddleName, string LastName, DateTime Birthday) :
            base(FirstName, MiddleName, LastName, Birthday)
        { }

        public PositionType Position
        {
            get { return position; }
            protected set { position = value; }
        }
    }
}
