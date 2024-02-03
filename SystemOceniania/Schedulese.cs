using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOceniania
{
    public class Schedulese
    {
        public int id { get; set; }

        private string subject, day, time, forST;

        public string Subject { get { return subject; } set { subject = value; } }
        public string Day { get { return day; } set { day = value; } }
        public string Time { get { return time; } set { time = value; } }
        public string ForST { get { return forST; } set { forST = value; } }
        public Schedulese() { }

        public Schedulese(string subject, string day, string time, string forST)
        {
            this.day = day;
            this.time = time;
            this.subject = subject;
            this.forST = forST;
        }
    }
}
