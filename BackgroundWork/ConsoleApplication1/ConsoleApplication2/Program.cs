using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication2.Models;
using ConsoleApplication2.BussinessLayer;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            createBlog();
            QueryBlog();
            Console.WriteLine("按任意键退出");
            Console.ReadKey();
        }

        static void createBlog()
        {
            Console.WriteLine("请输入一个班级名称");
            string name = Console.ReadLine();
            ClassG cla = new ClassG();
            cla.ClassName = name;
            ClassBussinessLayer cbl = new ClassBussinessLayer();
            cbl.Add(cla);

        }
        static void QueryBlog()
        {
            ClassBussinessLayer cbl = new ClassBussinessLayer();
            var blogs = cbl.Query();
            foreach (var item in blogs)
            {
                Console.WriteLine(item.ClassGID + "" + item.ClassName);
            }
        }
    }
}
