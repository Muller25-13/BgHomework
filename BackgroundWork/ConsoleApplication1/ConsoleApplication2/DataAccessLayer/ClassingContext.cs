using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ConsoleApplication2.Models;

namespace ConsoleApplication2.DataAccessLayer
{
    public class ClassingContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<ClassG> Classes { get; set; }
    }
}
