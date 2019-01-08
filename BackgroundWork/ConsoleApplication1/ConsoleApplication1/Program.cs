using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.Models;
using ConsoleApplication1.BlogBusinessLayer;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {


            opBlog();




        }
      
        static void opBlog()
        {
            Console.WriteLine("博客ID:");
            QueryBlog();
            Console.WriteLine("1--创建博客  2--修改博客  3--删除博客  4--帖子操作  5--退出  6--查询博客");
            int num = int.Parse(Console.ReadLine());
            
            if (num== 1)
            {
                createBlog();
                Console.Clear();
                opBlog();           
            }
            else if (num == 2)
            {
                Update();
                Console.Clear();

                opBlog();
            }
            else if (num == 3)
            {
                Delete();
                Console.Clear();

                opBlog();
            }
           
            else if (num == 4)
            {
                Console.Clear();

                opPost();
            }
            else if (num == 5)
            {
                return;
            }
            else if (num == 6)
            {
                MHQuery();
            }
            else
            {
                Console.WriteLine("输入有误");
                opBlog();
            }
        }

        static void opPost()
        {
           
            Console.WriteLine("1--查询帖子  2--新增帖子  3--修改帖子  4--删除帖子  5--查询博客ID  6--返回");
            int num = int.Parse(Console.ReadLine());
            if (num == 1)
            {
                DisplayPosts2();
                opPost();
            }
            else if (num == 2)
            {
                AddPost();               
                opPost();
            }
            else if (num == 3)
            {
                UpdatePosts();
                Console.Clear();
                opPost();
            }
            else if (num == 4)
            {
                DeletePosts();
                opPost();
            }
            else if (num == 5)
            {
                QueryBlog();
                opPost();
            }
            else if (num == 6)
            {
                Console.Clear();
                opBlog();
            }
            else
            {
                Console.WriteLine("输入有误");
                opPost();
            }
        }

        static void createBlog()
        {
            Console.WriteLine("请输入一个博客名称");         
            string name = Console.ReadLine();
            Blog blog = new Blog();
            blog.Name = name;
            BlogBusinessLayerss bbl= new BlogBusinessLayerss();
            bbl.Add(blog);
            Console.WriteLine("创建成功");
        }
        static void QueryBlog()
        {
            BlogBusinessLayerss bbl = new BlogBusinessLayerss();
            var blogs = bbl.Query();
            foreach(var item in blogs)
            {
                Console.WriteLine(item.BlogId + "" + item.Name);
            }
        }

        static void Update()
        {
            Console.WriteLine("请输入id");
            int id = int.Parse(Console.ReadLine());
            BlogBusinessLayerss bbl = new BlogBusinessLayerss();
            Blog blog= bbl.Query(id);
            Console.WriteLine("请输入新名字");
            string name = Console.ReadLine();
            blog.Name = name;
            bbl.Update(blog);
            Console.WriteLine("修改成功");
        }

        static void Delete()
        {
            BlogBusinessLayerss bbl = new BlogBusinessLayerss();
            Console.WriteLine("请输入一个博客ID");
            int id = int.Parse(Console.ReadLine());

            CheckBlogID(id);

            Blog blog = bbl.Query(id);
            bbl.Delete(blog);
            Console.WriteLine("删除成功");
        }

        static void AddPost()
        {
            //显示博客列表
            QueryBlog();

            //用户选择某个博客（id）
            Console.WriteLine("输入一个博客ID");
            int id = int.Parse(Console.ReadLine());

            //显示指定博客的帖子列表
            DisplayPosts(id);

            //根据指定到博客信息创建新帖子  
            Console.WriteLine("                              --新建帖子--");
            CreatNewPosts();

            //显示指定博客的帖子列表
            DisplayPosts(id);
        }
        static void DisplayPosts(int blogID)
        {
            

            BlogBusinessLayerss bbl = new BlogBusinessLayerss();
            Blog blog = bbl.Query(blogID);

            List<Post> postList = bbl.pQuery(blogID);
            foreach (var item in postList)
            {
                Console.WriteLine("博客ID:{0}  ---  帖子题目：{1}  ---  帖子内容:{2}  ---帖子ID:{3}",item.BlogId, item.Title,item.Content,item.PostId);
            }

        }

        static void DisplayPosts2()
        {
            Console.WriteLine("输入一个博客ID");
            int blogID = int.Parse(Console.ReadLine());
            BlogBusinessLayerss bbl = new BlogBusinessLayerss();
            Blog blog = bbl.Query(blogID);

            List<Post> postList = bbl.pQuery(blogID);
            foreach (var item in postList)
            {
                Console.WriteLine("博客ID:{0}  ---  帖子题目：{1}  ---  帖子内容:{2}  ---帖子ID:{3}", item.BlogId, item.Title, item.Content, item.PostId);
            }

        }

        static void CreatNewPosts()
        {
            Console.WriteLine("请输入一个博客ID");
            int id = int.Parse(Console.ReadLine());

            

            Console.WriteLine("请输入一个帖子名称");
            string title = Console.ReadLine();
            Console.WriteLine("请输入一个帖子名称");
            string content = Console.ReadLine();

            Post post = new Post();
            post.BlogId = id;
            post.Title = title;
            post.Content = content;

            BlogBusinessLayerss bbl = new BlogBusinessLayerss();
            bbl.pAdd(post);
        }

        //static void PostByID(int blogID)
        //{
        //    Console.WriteLine("请输入一个帖子名称");
        //    string title = Console.ReadLine();
        //    Console.WriteLine("请输入一个帖子内容");
        //    string content = Console.ReadLine();

        //    Post post = new Post();
        //    post.BlogId = blogID;
        //    post.Title = title;
        //    post.Content = content;

        //    BlogBusinessLayerss bbl = new BlogBusinessLayerss();
        //    bbl.pAdd(post);
        //}

        static void DeletePosts()
        {

            QueryBlog();

            BlogBusinessLayerss bbl = new BlogBusinessLayerss();
            Console.WriteLine("请输入一个博客ID");
            int blogID = int.Parse(Console.ReadLine());
            DisplayPosts(blogID);
            Console.WriteLine("请输入要删除的帖子ID");
            int postID = int.Parse(Console.ReadLine());
            Post post = bbl.postQuery(postID);
            bbl.DeletePost(post);
            DisplayPosts(blogID);

        }

        static void UpdatePosts()
        {
            QueryBlog();


            BlogBusinessLayerss bbl = new BlogBusinessLayerss();
            Console.WriteLine("请输入一个博客ID");
            int blogID = int.Parse(Console.ReadLine());
            DisplayPosts(blogID);
            Console.WriteLine("请输入要修改的帖子ID");
            int postID = int.Parse(Console.ReadLine());
            Post post = bbl.postQuery(postID);
            Console.WriteLine("请输入新题目");
            string newTitle = Console.ReadLine();
            post.Title = newTitle;
            Console.WriteLine("请输入新内容");
            string newContent = Console.ReadLine();
            post.Content = newContent;
            bbl.pUpdate(post);
            DisplayPosts(blogID);

            
        }


        static void CheckBlogID(int blogID)
        {
            BlogBusinessLayerss bbl = new BlogBusinessLayerss();

            Blog blog = bbl.Query(blogID);

            if (blog == null)
            {

                Console.WriteLine("没有此博客");

                opBlog();
            }
            else
            {
                return;
            }
                      
        }

        static void CheckPostID(int blogID)
        {
            BlogBusinessLayerss bbl = new BlogBusinessLayerss();

            Blog blog = bbl.Query(blogID);

            if (blog == null)
            {

                Console.WriteLine("没有此博客");

                opBlog();
            }
            else
            {
                return;
            }

        }

        static void MHQuery()
        {
            Console.WriteLine("输入博客名称关键字");
            string i = Console.ReadLine();

            BlogBusinessLayerss bbl = new BlogBusinessLayerss();
            var blog = bbl.mhQuery(i);
            foreach (var item in blog)
            {
                Console.WriteLine("{0}---{1}",item.Name,item.BlogId);
            }
            Console.ReadKey();
        }


    }
}
