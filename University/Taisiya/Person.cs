using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Taisiya
{
    class Person: IReadOnlyPerson
    {
        private string FirstName;
        private string MiddleName;
        private string LastName;
        private DateTime Birthday;

        public Person(string FirstName, string MiddleName, string LastName, DateTime Birthday)
        {
            this.FirstName = FirstName;
            this.MiddleName = MiddleName;
            this.LastName = LastName;
            this.Birthday = Birthday;
        }


        public string FullName
        {
            get { return FirstName + " " + MiddleName + " " + LastName; }
        }

        public int Age
        {
            get
            {
                int FullAge = DateTime.Now.Year - Birthday.Year;
                if (DateTime.Now.Month < Birthday.Month || (DateTime.Now.Month == Birthday.Month && DateTime.Now.Day < Birthday.Day))
                {
                    FullAge--;
                }
                return FullAge;
            }
        }
    }
}
