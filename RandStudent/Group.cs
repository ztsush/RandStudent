using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandStudent
{
    class Group
    {
        public string Name { get; set; }
        public List<string> StudentList { get; set; } = new List<string>();

        public Group(string name)
        {
            Name = name;
        }
        public Group()
        {

        }
    }
}
