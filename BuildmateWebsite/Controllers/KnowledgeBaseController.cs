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
            knowledgeData.Articles = knowledgeDB.KnowledgeArticles.Where(c => c.Hidden == false).OrderByDescending(c => c.DateModified).Take(10).ToList();

            ViewBag.noCategoryClass = "active";
            return View(knowledgeData);
        }

        // GET: /KnowledgeBase/category/id/categoryname
        public ActionResult Category(int? id, string categoryName)
        {
            ArticleViewData knowledgeData = new ArticleViewData();
            knowledgeData.KnowledgeCategories = knowledgeDB.KnowledgeCategories.OrderBy(c => c.Name).Where(c => c.KnowledgeArticles.Count > 0).ToList();
            knowledgeData.Articles = knowledgeDB.KnowledgeArticles.Where(c => c.CategoryId == id).ToList();
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
            searchData.Articles = knowledgeDB.KnowledgeArticles.MultiValueContainsAny(terms, s => s.Title).ToList();
            return View(searchData);
        }

        public class ArticleViewData
        {
            public List<KnowledgeCategory> KnowledgeCategories { get; set; }
            public List<KnowledgeArticle> Articles { get; set; }
            public KnowledgeArticle KnowledgeArticle { get; set; }
            public KnowledgeCategory CurrentCategory { get; set; }
        }
    }
}
