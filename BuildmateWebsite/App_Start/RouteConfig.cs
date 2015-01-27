using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BuildmateWebsite
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // robots.txt
            routes.IgnoreRoute("robots.txt");

            // blog homepage
            routes.MapRoute(
                "blogIndex",
                "blog",
                new { controller = "Blog", action = "Index", id = "", title = "", date = "" }
            );

            // blog article
            routes.MapRoute(
                "blogArticle",
                "blog/{id}/{title}",
                new { controller = "Blog", action = "Article", id = "", title = "" }
            );

            // blog category
            routes.MapRoute(
                "blogCategory",
                "blog/category/{id}/{title}",
                new { controller = "Blog", action = "Category", id = "", title = "" }
            );

            // knowledge base homepage
            routes.MapRoute(
                "KBIndex",
                "knowledgebase",
                new { controller = "KnowledgeBase", action = "Index", id = "", title = "" }
            );

            // knowledge base category
            routes.MapRoute(
                "KBCategory",
                "knowledgebase/category/{id}/{title}",
                new { controller = "KnowledgeBase", action = "Category", id = "", title = "" }
            );

            // knowledge base articles
            routes.MapRoute(
                "KBArticle",
                "knowledgebase/article/{id}/{title}",
                new { controller = "KnowledgeBase", action = "Article", id = "", title = "" }
            );



            // Features
            routes.MapRoute(
                "FeaturesIndex",
                "Features",
                new { controller = "Features", action = "Index", id = "", title = "" }
            );
            // Contact
            routes.MapRoute(
                "ContactIndex",
                "Contact",
                new { controller = "Contact", action = "Index", id = "", title = "" }
            );


            //// signup
            //routes.MapRoute(
            //    "register",
            //    "signup",
            //    new { controller = "Account", action = "Register" }
            //);

            //// pricing
            //routes.MapRoute(
            //    "pricing",
            //    "plans_and_pricing",
            //    new { controller = "Pricing", action = "Index" }
            //);
             
            // Page routes
            //routes.MapRoute("SpecificRoute", "{action}/{id}", new { controller = "Page", action = "Index", id = UrlParameter.Optional });


            routes.MapRoute(
                name: "Home",
                url: "{action}",
                defaults: new { controller = "Home", id = UrlParameter.Optional }
            );


            // Home
            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}