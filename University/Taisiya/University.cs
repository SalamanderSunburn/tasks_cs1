using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Taisiya
{
    class University: IUniversity
    {
        private string Title;
        private Schedule schedule;

        public University(string Title)
        {
            this.Title = Title;
        }

        public ISchedule CurrentSchedule
        {
            get { return new Schedule(); }
        }

        public IReadOnlyList<string> RoomsNames
        {
            get { throw new NotImplementedException(); }
        }

        public IReadOnlyList<string> TeachersNames
        {
            get { throw new NotImplementedException(); }
        }

        public IReadOnlyList<string> GroupsNames
        {
            get { throw new NotImplementedException(); }
        }

        public IReadOnlyList<string> GetStudentsNames(string groupName)
        {
            throw new NotImplementedException();
        }
    }
}
