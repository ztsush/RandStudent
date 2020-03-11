using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RandStudent
{
    class ScheduleData
    {
        private struct LessonTime
        {
            public DateTime beginTime;
            public DateTime endTime;
        }

        private List<LessonTime> BellSchedule = new List<LessonTime>();
        private Dictionary<DayOfWeek, DaySchedule> Schedule = new Dictionary<DayOfWeek, DaySchedule>();
        private Dictionary<string, Group> GroupList = new Dictionary<string, Group>();

        private string ToFormat(string String)
        {
            string GroupName = "";
            for (int i = 0; i < String.Length; i++)
            {
                
                if ((int)String[i] != 13)
                {
                    GroupName += String[i];
                }
            }
            return GroupName;
        }

        public void PutBellList(string BellList)
        {
            try
            {
                string[] Lessons = BellList.Split('\n');
                for (int i = 0; i < Lessons.Length; i++)
                {
                    LessonTime CurrentLesson = new LessonTime();
                    CurrentLesson.beginTime = DateTime.Parse(Lessons[i].Split('-')[0]);
                    CurrentLesson.endTime = DateTime.Parse(Lessons[i].Split('-')[1]);
                    BellSchedule.Add(CurrentLesson);
                }
            }
            catch
            {
                MessageBox.Show("ERROR_PutBellList");
            }
        }

        public void PutGroupSchedule(string GroupSchedule)
        {
            try
            {
                string[] Days = GroupSchedule.Split(new string[] { "---" }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < Days.Length; i++)
                {
                    DaySchedule CurrentDaySchedule = new DaySchedule();
                    int LesssonNumber = 0;
                    string[] Lessons = Days[i].Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                    for (int j = 0; j < Lessons.Length; j++)
                    {
                        string GroupName = ToFormat(Lessons[j]);
                        if (GroupName == "")
                        {
                            continue;
                        }

                        CurrentDaySchedule.LessonList[LesssonNumber] = new Lesson(GroupName);
                     //   MessageBox.Show((i+1).ToString()+" "+CurrentDaySchedule.LessonList[LesssonNumber].GroupName);
                        LesssonNumber++;
                        
                    }
                    Schedule.Add((DayOfWeek)(i + 1), CurrentDaySchedule);
                //    MessageBox.Show(((DayOfWeek)(i + 1)).ToString()+CurrentDaySchedule.LessonList[0].GroupName);
                }
            }
            catch
            {
                MessageBox.Show("ERROR_PutGroupSchedule");
            }
        }

        public void PutGroupList(string DirectoryPath)
        {

            try
            {
                string[] Groups = Directory.GetFiles(DirectoryPath, "*.txt");
                for (int i = 0; i < Groups.Length; i++)
                {
                    string InputData = File.ReadAllText(Groups[i]);
                    Group CurrentGroup = new Group(Path.GetFileNameWithoutExtension(Groups[i]));

                    String[] StudentList = InputData.Split('\n');
                    foreach (string Student in StudentList)
                    {
                        CurrentGroup.StudentList.Add(ToFormat(Student));
                    }

                    GroupList.Add(Path.GetFileNameWithoutExtension(Groups[i]), CurrentGroup);
                //    MessageBox.Show("="+Path.GetFileNameWithoutExtension(Groups[i])+"=");
                }
                GroupList.Add("free",new Group("free"));
            }
            catch
            {
                MessageBox.Show("ERROR_PutGroupList");
            }
            /*
            foreach (DayOfWeek key in Schedule.Keys)
            {
                MessageBox.Show(key.ToString());
                DaySchedule CurrentdaySchedule = Schedule[key];
                foreach (Lesson Lesson in CurrentdaySchedule.LessonList)
                {
                    if(Lesson == null)
                    {
                        break;
                    }
                    MessageBox.Show("+" + Lesson.GroupName + "+");
                }
            }
            */
        }

        public int GetLessonNumber(DateTime Time)
        {
            try
            {
                int i = 0;
                foreach (LessonTime CurrentLesson in BellSchedule)
                {
                    if (Time >= CurrentLesson.beginTime && Time <= CurrentLesson.endTime)
                    {
                        return i;
                    }
                    i++;
                }
                return -1;
            }
            catch
            {
                MessageBox.Show("ERROR_GetLessonNumber");
                return -1;
            }
        }

        public Group GetGroup(DateTime dateTime)
        {
            
            /*int i = 0;
            foreach (LessonTime CurrentLesson in BellSchedule)
            {
                MessageBox.Show(i+"="+CurrentLesson.beginTime + ":" + CurrentLesson.endTime);
                i++;
            }*/
            try
            {
                if (!Schedule.ContainsKey(DateTime.Now.DayOfWeek))
                {
                    return new Group("free");
                }
                if (GetLessonNumber(dateTime) == -1)
                {
                    return new Group("-1");
                }
            //    MessageBox.Show("_="+Schedule[dateTime.DayOfWeek].LessonList[GetLessonNumber(dateTime)].GroupName+"=");
            //    MessageBox.Show(GroupList.ContainsKey(Schedule[dateTime.DayOfWeek].LessonList[GetLessonNumber(dateTime)].GroupName).ToString());
                return GroupList[Schedule[dateTime.DayOfWeek].LessonList[GetLessonNumber(dateTime)].GroupName];
            }
            catch
            {
             //   MessageBox.Show("ERROR_GetGroup");
                return new Group("-1");
            }
        }
        
        private void ShowData()
        {
            /*
            MessageBox.Show("BellSchedule");
            for(int i = 0; i < BellSchedule.Count; i++)
            {
                MessageBox.Show(BellSchedule[i].beginTime.ToString() + ":" + BellSchedule[i].endTime.ToString());
            }
            */
            /*
            MessageBox.Show("GroupList");
            foreach(string key in GroupList.Keys)
            {
                string StudentList = "";
                MessageBox.Show("=" + key +"="+GroupList[key].Name + "=");
                foreach(string Student in GroupList[key].StudentList)
                {
                    StudentList += Student;
                    StudentList += "\n";
                }
                MessageBox.Show(StudentList);
            }*//*
            MessageBox.Show("GroupSchedule");
            foreach(DayOfWeek key in Schedule.Keys)
            {
                MessageBox.Show(key.ToString());
                string CurrentGroupList = "";
                for(int i = 0; i < 9; i++)
                {
                    CurrentGroupList += Schedule[key].LessonList[i].GroupName;
                }
            //    MessageBox.Show(CurrentGroupList);
            }*/
        }
    }
}



////////////////////////////////////// trash code ...\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
//try
//{
//    string[] Days = GroupSchedule.Split(new string[] { "---" }, StringSplitOptions.RemoveEmptyEntries);
//    for (int i = 0; i < Days.Length; i++)
//    {
//            MessageBox.Show("+" + Days[i] + "+");
//        DaySchedule CurrentDaySchedule = new DaySchedule();
//        string[] Lessons = Days[i].Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
//        int LesssonNumber = 0;
//        for (int j = 0; j < Lessons.Length; j++)
//        {
//            Lesson CurrentLesson = new Lesson(ToFormat());
//            Lessons[j] = ToFormat(Lessons[j]);
//            if (Lessons[j] == "")
//            {
//                continue;
//            }
//            MessageBox.Show(LesssonNumber + "+" + Lessons[LesssonNumber] + "+");
//            CurrentDaySchedule.LessonList[LesssonNumber].GroupName = Lessons[LesssonNumber];
//            LesssonNumber++;

//        }
//        Schedule.Add((DayOfWeek)(i + 1), CurrentDaySchedule);
//    }
//}
//catch
//{
//    MessageBox.Show("ERROR_PutGroupSchedule");
//}
//string[] Days = GroupSchedule.Split(new string[] { "---" }, StringSplitOptions.RemoveEmptyEntries);
//for (int i = 0; i < Days.Length; i++)
//{
//    DaySchedule daySchedule = new DaySchedule();
//    string[] Lessons = Days[i].Split('\n');
//    for (int j = 0; j < Lessons.Length; j++)
//    {
//        Lesson CurrentLesson = new Lesson(ToFormat(Lessons[j]));
//        Lessons.
//        daySchedule.LessonList[j] = lesson;
//        MessageBox.Show(j.ToString()+"+"+lesson.GroupName+"+");
//    }
//    Schedule.Add((DayOfWeek)(i + 1), daySchedule);
//}
//    MessageBox.Show("+" + Schedule[DayOfWeek.Monday].LessonList[0].GroupName + "+");