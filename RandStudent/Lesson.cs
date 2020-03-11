using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandStudent
{
    class Lesson
    {
        public String GroupName { get; set; }

        public Lesson(string groupName)
        {
            GroupName = groupName;
        }
        public Lesson()
        {

        }
    }
}