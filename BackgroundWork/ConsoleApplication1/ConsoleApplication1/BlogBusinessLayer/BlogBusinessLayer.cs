using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.Models;
using ConsoleApplication1.DataAccessLayer;
using System.Data.Entity;

namespace ConsoleApplication1.BlogBusinessLayer
{
    public class BlogBusinessLayerss
    {
        public void Add(Blog blog)
        {
            using (var db=new BloggingContext())
            {
                db.Blogs.Add(blog);
                db.SaveChanges();
            }
        }

        public List<Blog> Query()
        {
            using (var db = new BloggingContext())
            {

                return db.Blogs.ToList();
            }
        }

        public List<Blog> bQuery(int id)
        {
            using (var db = new BloggingContext())
            {
                var query = from b in db.Blogs
                            where b.BlogId == id
                            select b;
                return query.ToList();
            }
        }


        public List<Post>pQuery(int id)
        {
            using (var db=new BloggingContext())
            {
                var query = from b in db.Posts
                            where b.BlogId == id
                            select b;
                return query.ToList();
            }
        }

        public List<Blog>mhQuery(string i)
        {
            using(var db=new BloggingContext())
            {
                //var query = from b in db.Blogs
                //            where b.Name.Contains(i)
                //            select b;


                var query = db.Blogs.Where(num => num.Name.Contains(i));
                return query.ToList();
            }
        }

        public void pAdd(Post post)
        {
            using (var db = new BloggingContext())
            {
                db.Posts.Add(post);
                db.SaveChanges();
            }
        }

        public void DeletePost(Post post)
        {
            using (var db = new BloggingContext())
            {
                db.Entry(post).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public Post postQuery(int id)
        {
            using (var db = new BloggingContext())
            {
                return db.Posts.Find(id);
            }
        }


        public void pUpdate(Post post)
        {
            using (var db = new BloggingContext())
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
            }
        }


        public Blog Query(int id)
        {
            using (var db = new BloggingContext())
            {
                return db.Blogs.Find(id);
            }
        }

        public void Update(Blog blog)
        {
            using (var db = new BloggingContext())
            {
                db.Entry(blog).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(Blog blog)
        {
            using (var db = new BloggingContext())
            {
                db.Entry(blog).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

    }
}
