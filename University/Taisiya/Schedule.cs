using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Taisiya
{
    class Schedule: ISchedule
    {
        private Dictionary<DateTime, List<ScheduleItem>> items;

        private Dictionary<LessonsOrder, TimeSpan> lessonsTime = new Dictionary<LessonsOrder, TimeSpan>
        {
            { LessonsOrder.ZeroLesson, new TimeSpan(6, 30, 0) },
            { LessonsOrder.FirstLesson, new TimeSpan(8, 00, 0) },
            { LessonsOrder.SecondLesson, new TimeSpan(9, 35, 0) },
            { LessonsOrder.ThirdLesson, new TimeSpan(11, 20, 0) },
            { LessonsOrder.FourthLesson, new TimeSpan(12, 55, 0) },
            { LessonsOrder.FirstLesson, new TimeSpan(14, 30, 0) },
            { LessonsOrder.SixthLesson, new TimeSpan(16, 00, 0) },
            { LessonsOrder.SeventhLesson, new TimeSpan(17, 30, 0) },
            { LessonsOrder.EighthLesson, new TimeSpan(19, 00, 0) }
    };

 


        public IReadOnlyDictionary<string, IReadOnlyList<Tuple<DateTime, IReadOnlyList<string>, IReadOnlyList<string>>>> GetByDay(DateTime day)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyDictionary<DateTime, IReadOnlyDictionary<string, IReadOnlyList<Tuple<DateTime, IReadOnlyList<string>, IReadOnlyList<string>>>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyDictionary<DateTime, IReadOnlyList<Tuple<DateTime, IReadOnlyList<string>, IReadOnlyList<string>>>> GetByRoom(string roomName)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyDictionary<DateTime, IReadOnlyList<Tuple<DateTime, IReadOnlyList<string>, bool>>> GetByGroup(string groupName)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyDictionary<DateTime, IReadOnlyList<Tuple<DateTime, string, IReadOnlyList<string>>>> GetByTeacher(string teacherName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DateTime> AllExistingDates
        {
            get { throw new NotImplementedException(); }
        }

        public IReadOnlyDictionary<Tuple<DateTime, LessonsOrder>, IReadOnlyList<Tuple<IRoom, IReadOnlyList<IReadOnlyTeacher>, IReadOnlyList<IReadOnlyGroup>>>> GetWeekData(DateTime dateAtThisWeek)
        {
            throw new NotImplementedException();
        }


        private sealed class ScheduleItem : Schedule
        {
            private LessonsOrder lesson;
            private IEnumerable<Teacher> teachers;
            private IEnumerable<Group> groups;
            private Room room;

            public ScheduleItem(LessonsOrder lo, IEnumerable<Teacher> t, IEnumerable<Group> g, Room r)
            {
                lesson = lo;
                teachers = t;
                groups = g;
                room = r;
            }

        }
    }
}
