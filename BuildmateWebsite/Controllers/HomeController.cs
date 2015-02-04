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
        // GET: /Company/
        public ActionResult Company()
        {
            return View();
        }

        //
        // GET: /Pricing/
        public ActionResult plans_and_pricing()
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
