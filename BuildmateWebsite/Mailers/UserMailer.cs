using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mvc.Mailer;
using System.Net.Mail;

namespace BuildmateWebsite.Mailers
{ 
    public class UserMailer : MailerBase, IUserMailer     
	{
		public UserMailer():
			base()
		{
			MasterName="_Layout";
		}

        public virtual MvcMailMessage NotFound(string url)
        {
            var mailMessage = new MvcMailMessage { Subject = "[Buildmate] 404 Error" };

            mailMessage.To.Add("alan@buildmateapp.com");
            ViewBag.url = url;
            PopulateBody(mailMessage, viewName: "NotFound");

            return mailMessage;
        }

        public virtual MvcMailMessage Error500(Exception ex)
        {
            var mailMessage = new MvcMailMessage { Subject = "[Buildmate] 500 Error" };

            mailMessage.To.Add("alan@buildmateapp.com");
            ViewBag.exception = ex;
            PopulateBody(mailMessage, viewName: "Error500");

            return mailMessage;
        }
	}
}