using System;
using System.Linq;
using System.Web.Mvc;
using BuildmateWebsite.Models;
using System.Collections.Generic;

namespace BuildmateWebsite.Controllers
{
    public class KnowledgeBaseController : Controller
    {
        readonly BuildmateEntities knowledgeDB = new BuildmateEntities();
        //
        // GET: /KnowledgeBase/
        public ActionResult Index()
        {
            ArticleViewData knowledgeData = new ArticleViewData();
            knowledgeData.KnowledgeCategories = knowledgeDB.KnowledgeCategories.OrderBy(c => c.Name).Where(c => c.KnowledgeArticles.Count > 0).ToList();
            knowledgeData.PopularArticles = knowledgeDB.KnowledgeArticles.OrderByDescending(c => c.ViewCount).Take(5).ToList();
            knowledgeData.RecentArticles = knowledgeDB.KnowledgeArticles.Where(c => c.Hidden == false).OrderByDescending(c => c.DateModified).Take(10).ToList();

            ViewBag.noCategoryClass = "active";
            return View(knowledgeData);
        }

        // GET: /KnowledgeBase/category/id/categoryname
        public ActionResult Category(int? id, string categoryName)
        {
            ArticleViewData knowledgeData = new ArticleViewData();
            knowledgeData.KnowledgeCategories = knowledgeDB.KnowledgeCategories.OrderBy(c => c.Name).Where(c => c.KnowledgeArticles.Count > 0).ToList();
            knowledgeData.PopularArticles = knowledgeDB.KnowledgeArticles.OrderByDescending(c => c.ViewCount).Take(5).ToList();
            knowledgeData.ArticlesInCategory = knowledgeDB.KnowledgeArticles.Where(c => c.CategoryId == id).ToList();
            knowledgeData.CurrentCategory = knowledgeDB.KnowledgeCategories.Single(c => c.KnowledgeCategoryId == id);

            ViewBag.currentCategoryId = id;
            return View(knowledgeData);
        }

        // GET: /KnowledgeBase/Article/id/title/
        public ActionResult Article(int? id, string Title)
        {
            ArticleViewData knowledgeData = new ArticleViewData();
            knowledgeData.KnowledgeArticle = knowledgeDB.KnowledgeArticles.Find(id);
            knowledgeData.KnowledgeCategories = knowledgeDB.KnowledgeCategories.OrderBy(c=>c.Name).Where(c=>c.KnowledgeArticles.Count>0).ToList();
            knowledgeData.PopularArticles = knowledgeDB.KnowledgeArticles.OrderByDescending(c => c.ViewCount).Take(5).ToList();

            ViewBag.currentCategoryID = knowledgeData.KnowledgeArticle.CategoryId;
            return View(knowledgeData);
        }

        // GET: /knowledgebase/search/searchTerm?=
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Search(string searchTerm)
        {
            ViewBag.SearchTerm = searchTerm;
            string[] terms = searchTerm.Split(' ');

            ArticleViewData searchData = new ArticleViewData();
            searchData.KnowledgeCategories = knowledgeDB.KnowledgeCategories.OrderBy(c => c.Name).Where(c => c.KnowledgeArticles.Count > 0).ToList();
            searchData.PopularArticles = knowledgeDB.KnowledgeArticles.OrderByDescending(c => c.ViewCount).Take(5).ToList();
            searchData.SearchArticles = knowledgeDB.KnowledgeArticles.MultiValueContainsAny(terms, s => s.Title).ToList();
            return View(searchData);
        }

        public class ArticleViewData
        {
            public List<KnowledgeCategory> KnowledgeCategories { get; set; }
            public List<KnowledgeArticle> ArticlesInCategory { get; set; }
            public List<KnowledgeArticle> SearchArticles { get; set; }
            public List<KnowledgeArticle> PopularArticles { get; set; }
            public List<KnowledgeArticle> RecentArticles { get; set; }
            public KnowledgeArticle KnowledgeArticle { get; set; }
            public KnowledgeCategory CurrentCategory { get; set; }
        }
    }
}
