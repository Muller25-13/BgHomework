using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.DataAccessLayer;
using System.Data.Entity;

namespace WebApplication1.Models
{
    public class EmployeeBusinessLayer
    {
        public List<Employee> GetEmployeeList()
        {
            using (SalesERPDAL dal = new SalesERPDAL())
            {
               
                var list = dal.Employees.ToList();
                return list;
            }
        }

        public void AddEmployee(Employee e)
        {
            using (var db = new SalesERPDAL())
            {
                db.Employees.Add(e);
                db.SaveChanges();
            }
        }

        public void DeleteEmployee(int id)
        {
            using (var db = new SalesERPDAL())
            {
                Employee emp = db.Employees.Find(id);
                db.Entry(emp).State = EntityState.Deleted;
                db.SaveChanges();
            }

        }

        public void EditorEmployee(Employee e)
        {
            using (var db = new SalesERPDAL())
            {
                //Employee emp = db.Employees.Find(id);
                db.Entry(e).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public Employee Query(int id)
        {
            using (var db = new SalesERPDAL())
            {
                Employee emp = db.Employees.Find(id);
                return emp;
            }
        }


        public IEnumerable<Employee> MHQuery(string search)
        {
            using (var db = new SalesERPDAL())
            {
               var e= db.Employees.Where(num => num.Name.Contains(search)).ToList();
                return e;
            }


        }
    }
}