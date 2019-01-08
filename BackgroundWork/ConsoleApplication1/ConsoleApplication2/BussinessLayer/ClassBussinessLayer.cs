using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication2.Models;
using ConsoleApplication2.DataAccessLayer;
using System.Data.Entity;

namespace ConsoleApplication2.BussinessLayer
{
    public class ClassBussinessLayer
    {
        public void Add(ClassG cla)
        {
            using (var db= new ClassingContext())
            {
                db.Classes.Add(cla);
                db.SaveChanges();


            }
        }

        public List<ClassG> Query()
        {
            using (var db = new ClassingContext())
            {

                return db.Classes.ToList();
            }
        }

        
    }
}
