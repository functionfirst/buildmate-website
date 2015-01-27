using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuildmateWebsite.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /About/
        public ActionResult About()
        {
            return View();
        }

        //
        // GET: /Contact/
        //public ActionResult Contact()
        //{
        //    return View();
        //}

        //
        // GET: /Pricing/
        public ActionResult Pricing()
        {
            return View();
        }

        //
        // GET: /Privacy/
        public ActionResult Privacy()
        {
            return View();
        }

        //
        // GET: /resources/
        public ActionResult Resources()
        {
            return View();
        }

        //
        // GET: /Security/
        public ActionResult Security()
        {
            return View();
        }

        //
        // GET: /whats_new/
        public ActionResult whats_new()
        {
            return View();
        }

        //
        // GET: /Terms/
        public ActionResult Terms()
        {
            return View();
        }

        #region -- Robots() Method --
        public ActionResult Robots()
        {
            Response.ContentType = "text/plain";
            return View();
        }
        #endregion

    }

}
