using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc.Html;

namespace BuildmateWebsite.Models
{
    public class ViewExtensions
    {
            public static string MyValidationSummary(this HtmlHelper html, string validationMessage)
        {
            if (!html.ViewData.ModelState.IsValid)
            {
                return "<div class=\"alert\">" + html.ValidationSummary(validationMessage) + "</div>";
            }
            
            return "";
        }
    }
}