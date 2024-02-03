using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOceniania
{
    internal class Grade
    {
        public int id { get; set; }

        private int gradi;
        private string studentId, subject;

        public string StudentId
        {
            get { return studentId; }
            set { studentId = value; }
        }

        public int Gradi
        {
            get { return gradi; }
            set { gradi = value; }
        }

        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }


        public Grade() { }

        public Grade(string studentId, int grade, string subject)
        {
            this.studentId = studentId;
            this.gradi = grade;
            this.subject = subject;
        }
    }
}
