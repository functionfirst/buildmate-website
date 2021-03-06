using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mvc.Mailer;
using System.Net.Mail;

namespace BuildmateWebsite.Mailers
{ 
    public interface IUserMailer
    {
        MvcMailMessage NotFound(string url);

        MvcMailMessage Error500(Exception ex);
	}
}