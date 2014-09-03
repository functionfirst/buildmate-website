using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuildmateWebsite.Controllers
{
    public class FeaturesController : Controller
    {
        //
        // GET: /Features/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult extensive_tasks()
        {
            ViewBag.extensive_tasks = "class=active";
            return View();
        }

        public ActionResult project_templates()
        {
            ViewBag.project_templates = "class=active";
            return View();
        }

        public ActionResult cost_analysis()
        {
            ViewBag.cost_analysis = "class=active";
            return View();
        }

        public ActionResult pre_priced_resources()
        {
            ViewBag.pre_priced_resources = "class=active";
            return View();
        }

        public ActionResult customer_management()
        {
            ViewBag.customer_management = "class=active";
            return View();
        }

        public ActionResult professional_documents()
        {
            ViewBag.professional_documents = "class=active";
            return View();
        }
    }
}
