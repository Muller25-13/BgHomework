﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.ViewModels;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            //实例化员工信息业务层
            EmployeeBusinessLayer empBL = new EmployeeBusinessLayer();
            EmployeeListViewModel empListModel = new EmployeeListViewModel();
            var e = empBL.GetEmployeeList();

            //获取将处理过的数据列表
            empListModel.EmployeeViewList =getEmpVmList(e);
            // 获取问候语
            empListModel.Greeting = getGreeting();
            //获取用户名
            empListModel.UserName = getUserName();

            

            //将数据送往视图
            return View(empListModel);
        }
       
     
        public ActionResult QueryEmp(string search)
        {

            EmployeeBusinessLayer empBL = new EmployeeBusinessLayer();
            EmployeeListViewModel empListModel = new EmployeeListViewModel();
            var e = empBL.MHQuery(search);

            //获取将处理过的数据列表
            empListModel.EmployeeViewList = getEmpVmList(e.ToList());
            // 获取问候语
            empListModel.Greeting = getGreeting();
            //获取用户名
            empListModel.UserName = getUserName();

            //将数据送往视图
            return View("index",empListModel);


        }

        public ActionResult AddNew() {
            return View("CreateEmployee");
        }

        public ActionResult Editor(int id)
        {
           // ViewBag.id = id;
            EmployeeBusinessLayer empBL = new EmployeeBusinessLayer();
            Employee emp = empBL.Query(id);
 
            return View(emp);
        }

        public ActionResult Save(Employee emp)
        {
            EmployeeBusinessLayer empBL = new EmployeeBusinessLayer();
            empBL.AddEmployee(emp);

            

            // return (emp.Name + "-----" + emp.Salary.ToString());
            return new RedirectResult("index");
        }

        public ActionResult SaveEditor(Employee e)
        {
            
            EmployeeBusinessLayer empBL = new EmployeeBusinessLayer();
            empBL.EditorEmployee(e);
            return RedirectToAction("index");
        }

        public ActionResult Delete(int id)
        {
            EmployeeBusinessLayer emp = new EmployeeBusinessLayer();
            emp.DeleteEmployee(id);

            return RedirectToAction("index");
        }




        


        [NonAction]
        List<EmployeeViewModel> getEmpVmList(List<Employee> e)
        {
            //实例化员工信息业务层
           // EmployeeBusinessLayer empBL = new EmployeeBusinessLayer();
            //员工原始数据列表，获取来自业务层类的数据
            var listEmp = e;
            //员工原始数据加工后的视图数据列表，当前状态是空的
            var listEmpVm = new List<EmployeeViewModel>();

            

            //通过循环遍历员工原始数据数组，将数据一个一个的转换，并加入listEmpVm
            foreach (var item in listEmp)
            {
                EmployeeViewModel empVmObj = new EmployeeViewModel();
                empVmObj.EmployeeName = item.Name;
                empVmObj.EmployeeID = item.EmployeeID;
                empVmObj.EmployeeSalary = item.Salary.ToString("C");
                if (item.Salary > 10000)
                {
                    empVmObj.EmployeeGrade = "土豪";
                }
                else
                {
                    empVmObj.EmployeeGrade = "qiong";
                }

                listEmpVm.Add(empVmObj);
            }

            return listEmpVm;

        }

     



        [NonAction]
        string getGreeting()
        {
            string greeting;
            //获取当前时间
            DateTime dt = DateTime.Now;
            //获取当前小时数
            int hour = dt.Hour;
            //根据小时数判断需要返回哪个视图，<12 返回myview 否则返回 yourview
            if (hour < 12)
            {
                greeting = "早上好";
            }
            else
            {
                greeting = "下午好";
            }
            return greeting;
        }


        [NonAction]
        string getUserName()
        {
            return "Admin";
        }
    }
}