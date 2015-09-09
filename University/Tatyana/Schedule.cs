﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Tatyana
{


    class Schedule : ISchedule
    {
        class ScheduleItem
        {
            public LessonsOrder Lesson { get; set; }
            public Room Room { get; set; }
            public IEnumerable<Teacher> Teachsrs { get; set; }
            public IEnumerable<Group> Groups { get; set; }

        }
        Dictionary<DateTime, List<ScheduleItem>> items;
        TimeSpan[] timeOfStart = new TimeSpan[9] { new TimeSpan(6, 30, 0), new TimeSpan(8,0,0),
               new TimeSpan(9,30,0), new TimeSpan(11,10,0), new TimeSpan(12,30,0),
               new TimeSpan(14,10,0), new TimeSpan(15,40,0), new TimeSpan(16,10,0) ,
                new TimeSpan(17,30,0) };

        public Schedule()
        {
        }

        //public Schedule(Dictionary<DateTime, List<ScheduleItem>> items1)
        //{
        //    items = items1;
        //}

        private TimeSpan TimeOfStart(LessonsOrder lesson)
        {
            return timeOfStart[(int)lesson];
        }

        public bool IsLessonRoom(DateTime date, LessonsOrder lesson, Room room)
        {
            bool b = true;
            foreach (ScheduleItem s in items[date])
            {
                if (s.Lesson==lesson && object.Equals(s.Room, room))
                {
                    b = false;
                }
            }
            return b;
        }

        public bool AddLesson(DateTime date, LessonsOrder lesson, Room room, IEnumerable<Teacher> teachers, IEnumerable<Group> groups)
        {
            bool b = false;
            if (!IsLessonRoom(date, lesson, room))
            {
                items[date].Add(new ScheduleItem(){Lesson= lesson, Room= room, Teachsrs= teachers, Groups= groups });
                b = true;

            }
            return b;
        }
           


        public IReadOnlyDictionary<string, IReadOnlyList<Tuple<DateTime, IReadOnlyList<string>, IReadOnlyList<string>>>> GetByDay(DateTime day)
        {
            Dictionary<string, List<Tuple<DateTime, IReadOnlyList<string>, IReadOnlyList<string>>>> a =
                new Dictionary<string, List<Tuple<DateTime, IReadOnlyList<string>, IReadOnlyList<string>>>>();
            Dictionary<string, IReadOnlyList<Tuple<DateTime, IReadOnlyList<string>, IReadOnlyList<string>>>> b =
                new Dictionary<string, IReadOnlyList<Tuple<DateTime, IReadOnlyList<string>, IReadOnlyList<string>>>>();

//            Сразу передать return a  не получается, выдаётся ошибка 
            //Error	1	Cannot implicitly convert type 
            //'System.Collections.Generic.Dictionary<string,System.Collections.Generic.List<System.Tuple<System.DateTime,
            //System.Collections.Generic.IReadOnlyList<string>,System.Collections.Generic.IReadOnlyList<string>>>>'
            //to 'System.Collections.Generic.IReadOnlyDictionary<string,System.Collections.Generic.
            //IReadOnlyList<System.Tuple<System.DateTime,System.Collections.Generic.IReadOnlyList<string>,
            //System.Collections.Generic.IReadOnlyList<string>>>>'. An explicit conversion exists (are you missing a cast?)
            //C:\Users\admin\Desktop\Занятие 1\tasks_cs1\University\Tatyana\Schedule.cs	81	20	University
           // то есть внутри Dictionary заменить IReadOnlyList на List не получается .

            if (items.ContainsKey(day))
            {
                foreach (ScheduleItem s in items[day])
                {
                    if (!a.ContainsKey(s.Room.Id))
                    {
                        a[s.Room.Id] = new List<Tuple<DateTime, IReadOnlyList<string>, IReadOnlyList<string>>>();
                    }
                    TimeSpan t = TimeOfStart(s.Lesson);
                    DateTime date = new DateTime(day.Year, day.Month, day.Day, t.Hours, t.Minutes, t.Seconds);
                    List<string> group = new List<string>();
                    List<string> teacher = new List<string>();
                    foreach (Teacher t1 in s.Teachsrs)
                    {
                        teacher.Add(t1.FullName);
                    }
                    foreach (Group g in s.Groups)
                    {
                        group.Add(g.ID);
                    }

                    Tuple<DateTime, IReadOnlyList<string>, IReadOnlyList<string>> timeTeacherGroups =
                        new Tuple<DateTime, IReadOnlyList<string>, IReadOnlyList<string>>(date, teacher, group);
                    a[s.Room.Id].Add(timeTeacherGroups);
                }
                foreach (var t in a.Keys)
                {
                    b[t] = a[t];
                }
            }
            return b;
        }

        public IReadOnlyDictionary<DateTime, IReadOnlyDictionary<string, IReadOnlyList<Tuple<DateTime, IReadOnlyList<string>, IReadOnlyList<string>>>>> GetAll()
        {
            Dictionary<DateTime, Dictionary<string, List<Tuple<DateTime, IReadOnlyList<string>, IReadOnlyList<string>>>>> a=
                new Dictionary<DateTime, Dictionary<string,List<Tuple<DateTime,IReadOnlyList<string>,IReadOnlyList<string>>>>>();
            Dictionary<DateTime, Dictionary<string, IReadOnlyList<Tuple<DateTime, IReadOnlyList<string>, IReadOnlyList<string>>>>> a1 =
                new Dictionary<DateTime, Dictionary<string, IReadOnlyList<Tuple<DateTime, IReadOnlyList<string>, IReadOnlyList<string>>>>>();
            Dictionary<DateTime, IReadOnlyDictionary<string, IReadOnlyList<Tuple<DateTime, IReadOnlyList<string>, IReadOnlyList<string>>>>> b =
                new Dictionary<DateTime, IReadOnlyDictionary<string, IReadOnlyList<Tuple<DateTime, IReadOnlyList<string>, IReadOnlyList<string>>>>>();
                            foreach (DateTime d in items.Keys )
            {
                a[d] = new Dictionary<string, List<Tuple<DateTime, IReadOnlyList<string>, IReadOnlyList<string>>>>();
               foreach (ScheduleItem s in items[d])
                {
                    if (!a[d].ContainsKey(s.Room.Id))

                    {
                        a[d][s.Room.Id] = new List<Tuple<DateTime, IReadOnlyList<string>, IReadOnlyList<string>>>();
                    }
                    TimeSpan t = TimeOfStart(s.Lesson);
                    DateTime date = new DateTime(d.Year, d.Month, d.Day, t.Hours, t.Minutes, t.Seconds);
                    List<string> group = new List<string>();
                    List<string> teacher = new List<string>();
                    foreach (Teacher t1 in s.Teachsrs)
                    {
                        teacher.Add(t1.FullName);
                    }
                    foreach (Group g in s.Groups)
                    {
                        group.Add(g.ID);
                    }

                    Tuple<DateTime, IReadOnlyList<string>, IReadOnlyList<string>> timeTeacherGroups =
                        new Tuple<DateTime, IReadOnlyList<string>, IReadOnlyList<string>>(date, teacher, group);
                    a[d][s.Room.Id].Add(timeTeacherGroups);
                   
                  }
               foreach (ScheduleItem s in items[d])
               {
                   a1[d][s.Room.Id] = a[d][s.Room.Id];
               }

               //a1[d] = a[d];
            }
                            foreach (DateTime d in items.Keys)
                            {
                                b[d] = a1[d];
                            }
                            return b;        
        }

        public IReadOnlyDictionary<DateTime, IReadOnlyList<Tuple<DateTime, IReadOnlyList<string>, IReadOnlyList<string>>>> GetByRoom(string roomName)
        {
            Dictionary<DateTime, List<Tuple<DateTime, IReadOnlyList<string>, IReadOnlyList<string>>>> a =
                new Dictionary<DateTime, List<Tuple<DateTime, IReadOnlyList<string>, IReadOnlyList<string>>>>();
            Dictionary<DateTime, IReadOnlyList<Tuple<DateTime, IReadOnlyList<string>, IReadOnlyList<string>>>> b =
                new Dictionary<DateTime, IReadOnlyList<Tuple<DateTime, IReadOnlyList<string>, IReadOnlyList<string>>>>();
            foreach (DateTime d in items.Keys)
            {
                foreach (ScheduleItem s in items[d])
                {
                    if (object.Equals(s.Room.Id, roomName ))
                    {
                        if (!a.ContainsKey(d))
                        {
                            a[d]= new List<Tuple<DateTime, IReadOnlyList<string>, IReadOnlyList<string>>>();
                        }
                        TimeSpan t = TimeOfStart(s.Lesson);
                        DateTime date = new DateTime(d.Year, d.Month, d.Day, t.Hours, t.Minutes, t.Seconds);
                        List<string> group = new List<string>();
                        List<string> teacher = new List<string>();
                        foreach (Teacher t1 in s.Teachsrs)
                            {
                              teacher.Add(t1.FullName);
                              }
                               foreach (Group g in s.Groups)
                            {
                                group.Add(g.ID);
                            }


                    Tuple<DateTime, IReadOnlyList<string>, IReadOnlyList<string>> timeTeacherGroups =
                        new Tuple<DateTime, IReadOnlyList<string>, IReadOnlyList<string>>(date, teacher, group);
                    a[d].Add(timeTeacherGroups);
                    }
                }
                
            }

            foreach (DateTime d in items.Keys)
            {
                b[d] = a[d];
            }

            return b;
        }

        public IReadOnlyDictionary<DateTime, IReadOnlyList<Tuple<DateTime, IReadOnlyList<string>, bool>>> GetByGroup(string groupName)
        {
            Dictionary<DateTime, List<Tuple<DateTime, IReadOnlyList<string>, bool>>> a =
                  new Dictionary<DateTime, List<Tuple<DateTime, IReadOnlyList<string>, bool>>>();
            Dictionary<DateTime, IReadOnlyList<Tuple<DateTime, IReadOnlyList<string>, bool>>> b =
                new Dictionary<DateTime, IReadOnlyList<Tuple<DateTime, IReadOnlyList<string>, bool>>>();
            foreach (DateTime d in items.Keys)
            {
                foreach (ScheduleItem s in items[d])
                {
                    foreach (Group g in s.Groups )
                    {
                        if (object.Equals(g.ID, groupName))
                        {
                            if (!a.ContainsKey(d))
                            {
                                a[d] = new List<Tuple<DateTime, IReadOnlyList<string>, bool>>();
                            }
                            TimeSpan t = TimeOfStart(s.Lesson);
                            DateTime date = new DateTime(d.Year, d.Month, d.Day, t.Hours, t.Minutes, t.Seconds);
                            List<string> group = new List<string>();
                            List<string> teacher = new List<string>();
                            foreach (Teacher t1 in s.Teachsrs)
                            {
                                teacher.Add(t1.FullName);
                            }
                            foreach (Group g1 in s.Groups)
                            {
                                group.Add(g1.ID);
                            }
                            bool b1 = (group.Count > 1) ? true : false;

                            Tuple<DateTime, IReadOnlyList<string>, bool> timeTeacherGroups =
                                new Tuple<DateTime, IReadOnlyList<string>, bool>(date, teacher, b1);
                            a[d].Add(timeTeacherGroups);
                        }
                    }
                }
            }

            foreach (DateTime d in items.Keys)
            {
                b[d] = a[d];
            }
            return b;
            
        }

        public IReadOnlyDictionary<DateTime, IReadOnlyList<Tuple<DateTime, string, IReadOnlyList<string>>>> GetByTeacher(string teacherName)
        {
            Dictionary<DateTime, List<Tuple<DateTime, string, IReadOnlyList<string>>>> a =
                 new Dictionary<DateTime, List<Tuple<DateTime, string, IReadOnlyList<string>>>>();
            Dictionary<DateTime, IReadOnlyList<Tuple<DateTime, string, IReadOnlyList<string>>>> b =
                new Dictionary<DateTime, IReadOnlyList<Tuple<DateTime, string, IReadOnlyList<string>>>>();
            foreach (DateTime d in items.Keys)
            {
                foreach (ScheduleItem s in items[d])
                {
                    foreach (Teacher teacher in s.Teachsrs)
                    {
                            if (object.Equals(teacher.FullName, teacherName))
                            {
                                if (!a.ContainsKey(d))
                                {
                                    a[d] = new List<Tuple<DateTime, string, IReadOnlyList<string>>>();
                                }
                                TimeSpan t = TimeOfStart(s.Lesson);
                                DateTime date = new DateTime(d.Year, d.Month, d.Day, t.Hours, t.Minutes, t.Seconds);
                                string room = s.Room.Id;
                                List<string> group = new List<string>();
                                foreach (Group g1 in s.Groups)
                                {
                                    group.Add(g1.ID);
                                }
                                Tuple<DateTime, string, IReadOnlyList<string>> timeTeacherGroups =
                                    new Tuple<DateTime, string, IReadOnlyList<string>>(date, room, group);
                                a[d].Add(timeTeacherGroups);
                            }
                    }

                }
            }

            foreach (DateTime d in items.Keys)
            {
                b[d] = a[d];
            }
            return b;
        }

        public IEnumerable<DateTime> AllExistingDates
        {
            get { return items.Keys; }
        }

        public IReadOnlyDictionary<Tuple<DateTime, LessonsOrder>, IReadOnlyList<Tuple<IRoom, IReadOnlyList<IReadOnlyTeacher>, IReadOnlyList<IReadOnlyGroup>>>> 
                                                                            GetWeekData(DateTime dateAtThisWeek)
        {
            Dictionary<Tuple<DateTime, LessonsOrder>, List<Tuple<IRoom, IReadOnlyList<IReadOnlyTeacher>, IReadOnlyList<IReadOnlyGroup>>>> a =
                new Dictionary<Tuple<DateTime, LessonsOrder>, List<Tuple<IRoom, IReadOnlyList<IReadOnlyTeacher>, IReadOnlyList<IReadOnlyGroup>>>>();
            Dictionary<Tuple<DateTime, LessonsOrder>, IReadOnlyList<Tuple<IRoom, IReadOnlyList<IReadOnlyTeacher>, IReadOnlyList<IReadOnlyGroup>>>> b =
                new Dictionary<Tuple<DateTime, LessonsOrder>, IReadOnlyList<Tuple<IRoom, IReadOnlyList<IReadOnlyTeacher>, IReadOnlyList<IReadOnlyGroup>>>>();
            DateTime dateAtThisWeek1 = new DateTime(dateAtThisWeek.Year, dateAtThisWeek.Month, dateAtThisWeek.Day, 1, 0, 0);
            int i=(int) dateAtThisWeek.DayOfWeek;
            DateTime monday = new DateTime(dateAtThisWeek1.Ticks - new DateTime(0, 0, i>0?(i - 1):6).Ticks);
            DateTime sunday = (i > 0) ? dateAtThisWeek.AddDays(7 - i) : dateAtThisWeek;
            
            foreach (DateTime d in items.Keys)
            {
                if (d >= monday && d <= sunday)
                {
                    foreach (ScheduleItem s in items[d])
                    {
                        Tuple<DateTime, LessonsOrder> lesson = new Tuple<DateTime, LessonsOrder>(d, s.Lesson);
                        if (!a.ContainsKey(lesson))
                        {
                            a[lesson] = new List<Tuple<IRoom, IReadOnlyList<IReadOnlyTeacher>, IReadOnlyList<IReadOnlyGroup>>>();
                        }
                        List<IReadOnlyTeacher> teachers = new List<IReadOnlyTeacher>();
                        List<IReadOnlyGroup> groups = new List<IReadOnlyGroup>();
                        foreach (IReadOnlyTeacher t in s.Teachsrs)
                        {
                            teachers.Add(t);
                        }
                        foreach (IReadOnlyGroup g in s.Groups)
                        {
                            groups.Add(g);
                        }
                        Tuple<IRoom, IReadOnlyList<IReadOnlyTeacher>, IReadOnlyList<IReadOnlyGroup>> roomTeachersGroup =
                            new Tuple<IRoom, IReadOnlyList<IReadOnlyTeacher>, IReadOnlyList<IReadOnlyGroup>>
                                             (s.Room,teachers,groups);
                        a[lesson].Add(roomTeachersGroup);
                    }
                }
       
            }

            foreach (var t in a.Keys)
            {
                b[t] = a[t];
            }
            return b;
        }
    }
}
