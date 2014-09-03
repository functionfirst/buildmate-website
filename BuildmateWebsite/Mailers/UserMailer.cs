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


        public virtual MvcMailMessage Welcome(string user_email, string password)
		{
            var mailMessage = new MvcMailMessage { Subject = "[Buildmate] Welcome" };

            mailMessage.To.Add(ViewBag.user_email);
            ViewBag.user_email = user_email;
            ViewBag.password = password;
			PopulateBody(mailMessage, viewName: "Welcome");

			return mailMessage;
		}


        public virtual MvcMailMessage Confirmation(string user_email)
        {
            MailAddress from = new MailAddress(user_email);
            var mailMessage = new MvcMailMessage { Subject = "[Buildmate] New Account", From = from };

            mailMessage.To.Add("support@buildmateapp.com");
            ViewBag.user_email = user_email;
            PopulateBody(mailMessage, viewName: "Confirmation");

            return mailMessage;
        }

        public virtual MvcMailMessage PasswordReset()
		{
            var mailMessage = new MvcMailMessage { Subject = "[Buildmate] Password Reset" };
			
			PopulateBody(mailMessage, viewName: "PasswordReset");

			return mailMessage;
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