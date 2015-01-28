using BuildmateWebsite.Models;
using System;
//using System.Collections.Generic;
//using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace BuildmateWebsite.Controllers
{
    public class ContactController : Controller
    {
        //
        // GET: /Contact/

        [HttpGet]
        public ActionResult Index()
        {
            //foo
            ViewBag.success = false;
            ViewBag.error = false;

            ViewBag.title = "Get In Touch";
            ViewBag.message = "If have any comments, questions or ideas to improve Buildmate we'd love to hear from you!";
            return View();
        }

        [HttpPost]
        public ActionResult Index(ContactForm contactForm)
        {
            ViewBag.success = false;
            ViewBag.error = false;

            if (ModelState.IsValid)
            {
                StringBuilder message = new StringBuilder();
                message.Append("Name: " + contactForm.Name + "<br />\n");
                message.Append("Email Address: " + contactForm.Email + "<br />\n");
                message.Append("Phone: " + contactForm.Phone + "<br />\n");

                message.Append("Message: " + contactForm.Message);

                if (SendEmail("alan@functionfirst.co.uk", message))
                {
                    ViewBag.success = true;
                }
                else
                {
                    ViewBag.error = true;
                }

                return View();
            }

            return View();
        }

        public static bool SendEmail(string SentTo, StringBuilder Text)
        {
            MailMessage msg = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            MailAddress from = new MailAddress(SentTo);
            StringBuilder sb = new StringBuilder();
            msg.To.Add("alan@functionfirst.co.uk");
            msg.Subject = "[Buildmate] Website Contact";
            msg.IsBodyHtml = true;
            smtp.Host = "mail.buildmateapp.com";
            smtp.Port = 8889;
            sb.Append(Text);
            msg.Body = sb.ToString();

            try
            {
                smtp.Send(msg);
                msg.Dispose();
                return true;
            }
            catch (Exception) {
                return false;
            }
        }

    }
}
