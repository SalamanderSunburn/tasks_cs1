using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Taisiya
{
    class Student : IStudent
    {
        private string FirstName;
        private string LastName;
        private DateOfBirth Birthday;
        private Group GroupName;
        private Dictionary<Subject, Mark> MarksList;

        public Student(string firstName, string lastName, DateOfBirth birthday , Group groupName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Birthday = birthday;
            this.GroupName = groupName;
            this.MarksList = new Dictionary<Subject, Mark>();
        }

        public int Age
        {
            get
            {
                int FullAge = DateTime.Now.Year - Birthday.YearOfBirth;
                if (DateTime.Now.Month < Birthday.MonthOfBirth || (DateTime.Now.Month == Birthday.MonthOfBirth && DateTime.Now.Day < Birthday.DayOfBirth))
                {
                    FullAge--;
                }
                return FullAge; 
            }
        }

        public string FullName
        {
            get 
            { 
                return this.FirstName + " " + this.LastName; 
            }
        }

        public Mark GetMark(Subject subject)
        {
            foreach (var m in MarksList)
                if (m.Key == subject)
                    return m.Value;
            return 0;
        }

        public void SetMark(Subject subject, Mark mark)
        {
            MarksList.Add(subject, mark);                
        }

        public Group CurrentGroup
        {
            get { return this.GroupName; }
            set { this.GroupName = value; }
        }

        public IReadOnlyDictionary<Subject, Mark> GetAllMarks()
        {
            return MarksList;
        }
    }

    struct DateOfBirth
    {
        public int DayOfBirth;
        public int MonthOfBirth;
        public int YearOfBirth;
        public string PlaceOfBirth;

        public DateOfBirth(int DayOfBirth, int MonthOfBirth, int YearOfBirth, string PlaceOfBirth)
        {
            this.DayOfBirth = DayOfBirth;
            this.MonthOfBirth = MonthOfBirth;
            this.YearOfBirth = YearOfBirth;
            this.PlaceOfBirth = PlaceOfBirth;
        }


    }
}
