using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2.Models
{
    public class ClassG
    {
        public int ClassGID { get; set; }
        public string ClassName { get; set; }
        public virtual List<Student> Students { get; set; }
    }
}
