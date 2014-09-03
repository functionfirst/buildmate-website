using System;
using System.Linq;
using System.Web.Mvc;
using BuildmateWebsite.Models;
using System.Collections.Generic;

namespace BuildmateWebsite.Controllers
{
    public class BlogController : Controller
    {
        readonly BuildmateEntities blogDB = new BuildmateEntities();
        //
        // GET: /Blog/
        public ActionResult Index()
        {
            BlogViewData blogData = new BlogViewData();
            blogData.RecentBlogArticles = blogDB.BlogArticles.OrderByDescending(c => c.DateCreated).Take(10).ToList();
            blogData.RecentPosts = blogDB.BlogArticles.OrderByDescending(c => c.DateCreated).Take(5).ToList();
            blogData.BlogCategories = blogDB.BlogCategories.OrderBy(c => c.Name).Where(c => c.Blogs.Count > 0).ToList();
            return View(blogData);
        }

        // GET: /blog/category/id/categoryname
        public ActionResult Category(int? id, string categoryName)
        {
            BlogViewData blogData = new BlogViewData();
            blogData.BlogInCategories = blogDB.BlogArticles.Where(c => c.CategoryId == id).OrderByDescending(c => c.DateCreated).ToList();
            blogData.BlogCategories = blogDB.BlogCategories.OrderBy(c => c.Name).Where(c => c.Blogs.Count > 0).ToList();
            blogData.RecentPosts = blogDB.BlogArticles.OrderByDescending(c => c.DateCreated).Take(5).ToList();
            blogData.CurrentCategory = blogDB.BlogCategories.Single(c => c.BlogCategoryId == id);
            return View(blogData);
        }

        //
        // GET: /Blog/Date/Id/Title/
        public ActionResult Article(int? id)
        {
            BlogViewData blogData = new BlogViewData();
            blogData.BlogCategories = blogDB.BlogCategories.OrderBy(c => c.Name).Where(c => c.Blogs.Count > 0).ToList();
            blogData.RecentPosts = blogDB.BlogArticles.OrderByDescending(c => c.DateCreated).Take(5).ToList();
            blogData.Blog = blogDB.BlogArticles.Find(id);
            return View(blogData);
        }

        public class BlogViewData
        {
            public List<BlogCategory> BlogCategories { get; set; }
            public List<Blog> BlogInCategories { get; set; }
            public List<Blog> RecentBlogArticles { get; set; }
            public List<Blog> RecentPosts  { get; set; }
            public Blog Blog { get; set; }
            public BlogCategory CurrentCategory { get; set; }
        }
    }
}
