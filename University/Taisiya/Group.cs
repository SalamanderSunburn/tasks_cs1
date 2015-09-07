using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Taisiya
{
    class Group: IReadOnlyGroup
    {
        private string id;
        private FacultyType faculty;
        private IEnumerable<IReadOnlyPerson> students;
        private int year;
        private static Dictionary<Tuple<int, string>, int> existingGroupsCount; // wtf?????

        public Group(string id, FacultyType faculty)
        {
            this.id = id;
            this.faculty = faculty;            
        }

        public string ID
        {
            get 
            {
                string name = id + Faculty.ToString()[0] + Faculty.ToString()[1] + "-" + year.ToString()[0] + year.ToString()[1];
                return name;
            }
        }

        public FacultyType Faculty
        {
            get { return faculty; }
        }

        public IEnumerable<IReadOnlyPerson> Students
        {
            get { return students; }
        }

        public void Add(Student s)
        {
            students.ToList().Add((IReadOnlyPerson)s);
        }
    }
}
