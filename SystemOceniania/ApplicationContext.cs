using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SystemOceniania
{
    internal class ApplicationContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Schedulese> Schedules { get; set; }
        public DbSet<Subject> SubjectsST { get; set; }
        public ApplicationContext(): base("DefaultConnection") { }
    }
}
