using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RandStudent
{
    public partial class Form1 : Form
    {

        private struct Student
        {
            public string Name;
            public bool Presence;

            public Student(string name, bool presence)
            {
                Name = name;
                Presence = presence;
            }
        }
        int LessonNumber = -2;
        ScheduleData Schedule;
        List <Student> CurrentStudentList;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Hide();
            ShowInTaskbar = false;

            MyNotifyIcon.ContextMenuStrip = MyContextMenuStrip;
            MyNotifyIcon.Icon = new Icon("image/icon.ico");

            Schedule = new ScheduleData();
            CurrentStudentList = new List<Student>();

            Schedule.PutBellList(File.ReadAllText("data/BellList.txt"));
            Schedule.PutGroupSchedule(File.ReadAllText("data/GroupSchedule.txt"));
            Schedule.PutGroupList("data/groups/");

            CheckTimer_Tick(sender, e);
            CheckTimer.Start();
            //    Schedule.ShowData();

        }

        private void CheckTimer_Tick(object sender, EventArgs e)
        {
            //    MessageBox.Show(Schedule.GetLessonNumber(DateTime.Now).ToString() + "\n" + Schedule.GetGroup(DateTime.Now).Name);
            //   MessageBox.Show(Schedule.GetLessonNumber(DateTime.Now).ToString()+" "+DateTime.Now.DayOfWeek.ToString());
            if (Schedule.GetLessonNumber(DateTime.Now) != LessonNumber)
            {
                if (Schedule.GetLessonNumber(DateTime.Now) == -1)
                {
                    string Message = "Have a rest!";
                    MyContextMenuStrip.Items.Clear();
                    MyContextMenuStrip.Items.Add(Message);
                    MyContextMenuStrip.Items[0].Image = Image.FromFile("image/rest.png");
                }
                else
                {
                    Group CurrentGroup = Schedule.GetGroup(DateTime.Now);
                //    MessageBox.Show(CurrentGroup.Name);
                    if (CurrentGroup.Name == "-1")
                    {
                        string Message = "ERROR_GroupNotFound";
                        MyContextMenuStrip.Items.Clear();
                        MyContextMenuStrip.Items.Add(Message);
                        MyContextMenuStrip.Items[0].Image = Image.FromFile("image/problem.png");
                    }
                    else if (CurrentGroup.Name == "free")
                    {
                        string Message = "Have a rest!";
                        MyContextMenuStrip.Items.Clear();
                        MyContextMenuStrip.Items.Add(Message);
                        MyContextMenuStrip.Items[0].Image = Image.FromFile("image/rest.png");
                    }
                    else
                    {
                        CurrentStudentList.Clear();
                        MyContextMenuStrip.Items.Clear();
                        MyContextMenuStrip.Items.Add(CurrentGroup.Name);
                        MyContextMenuStrip.Items[0].Font = new Font(FontFamily.GenericMonospace, 10, FontStyle.Bold);
                        MyContextMenuStrip.Items[0].Click += new EventHandler(ToolStripMenuItemName_Click);

                        int i = 1;
                        foreach (string student in CurrentGroup.StudentList)
                        {
                            MyContextMenuStrip.Items.Add(student);
                            MyContextMenuStrip.Items[i].MouseDown += new MouseEventHandler(ToolStripMenuItemStudent_MouseDown);
                            i++;
                            Student NewStudent = new Student(student,true);
                            CurrentStudentList.Add(NewStudent);
                        }
                    }
                }
                LessonNumber = Schedule.GetLessonNumber(DateTime.Now);
            }
            
        }

        private void ToolStripMenuItemName_Click(object sender, EventArgs e)
        {
            string GroupName = MyContextMenuStrip.Items[0].Text;
            MyContextMenuStrip.Items.Clear();
            MyContextMenuStrip.Items.Add(GroupName);
            MyContextMenuStrip.Items[0].Font = new Font(FontFamily.GenericMonospace, 10, FontStyle.Bold);
            MyContextMenuStrip.Items[0].Click += new EventHandler(ToolStripMenuItemName_Click);

            int i = 1;
            foreach (Student student in CurrentStudentList)
            {
                MyContextMenuStrip.Items.Add(student.Name);
                MyContextMenuStrip.Items[i].MouseDown += new MouseEventHandler(ToolStripMenuItemStudent_MouseDown);
                MyContextMenuStrip.Items[i].Enabled = student.Presence;
                i++;
            }
        }
        private void ToolStripMenuItemStudent_MouseDown(object sender, MouseEventArgs e)
        {
            //   MessageBox.Show("lol");
            if(sender is ToolStripItem)
            {
                 if (e.Button == MouseButtons.Right)
                 {
                    if (((ToolStripItem)(sender)).Enabled)
                    {
                        ((ToolStripItem)(sender)).Enabled = false;
                        CurrentStudentList[CurrentStudentList.IndexOf(new Student(((ToolStripItem)(sender)).ToString(), true))] = new Student(((ToolStripItem)(sender)).ToString(), false);
                    }
                 }   
            }
        }

        private void MyNotifyIcon_Click(object sender, EventArgs e)
        {
            if(e is MouseEventArgs)
            {
                MouseEventArgs mouse = (MouseEventArgs)e;
                if (mouse.Button == MouseButtons.Left) 
                {
                    Visible = true;
                    if(MyContextMenuStrip.Items.Count == 1)
                    {
                        int i = 1;
                        foreach (Student student in CurrentStudentList)
                        {
                            MyContextMenuStrip.Items.Add(student.Name);
                            MyContextMenuStrip.Items[i].MouseDown += new MouseEventHandler(ToolStripMenuItemStudent_MouseDown);
                            i++;
                        }
                    }

                    Random random = new Random();
                    int number = random.Next(1, MyContextMenuStrip.Items.Count);
                    string studentName = MyContextMenuStrip.Items[number].Text;
                    LbStudentName.Text = MyContextMenuStrip.Items[number].Text;
                    MyContextMenuStrip.Items.Remove(MyContextMenuStrip.Items[number]);
                }
            }
        }
    }
}
