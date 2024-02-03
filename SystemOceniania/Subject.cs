using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOceniania
{
    internal class Subject
    {
        public int id {  get; set; }

        private string subjectName;

        public string SubjectName
        {
            get { return subjectName; }
            set { subjectName = value; }
        }

        public Subject() { }

        public Subject(string subjectName)
        {
            this.subjectName = subjectName;
        }
    }
}
