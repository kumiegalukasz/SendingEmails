using SendingEmailsFromController.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace SendingEmailsFromController.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult SendEmail()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SendEmail(EmployeeModel obj, List<HttpPostedFileBase> attachments)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    SmtpClient smtpClient = new SmtpClient("poczta.o2.pl", 587);
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential(obj.Email, obj.Password);
                    MailMessage message = new MailMessage();
                    foreach (HttpPostedFileBase attachment in attachments)
                    {
                        if (attachment != null)
                        {
                            string fileName = Path.GetFileName(attachment.FileName);
                            message.Attachments.Add(new Attachment(attachment.InputStream, fileName));
                        }
                    }
                    message.To.Add(new MailAddress(obj.ToEmail));
                    message.From = new MailAddress(obj.Email);
                    message.Body = obj.EMailBody;
                    message.Subject = obj.EmailSubject;
                    if (obj.EmailCC != null)
                    {
                        message.CC.Add(new MailAddress(obj.EmailCC));
                    }

                    //Attachment data = new Attachment();
                    //message.Attachments.Add(data);

                    smtpClient.Send(message);
                }
                catch (Exception)
                {
                    ViewBag.Status = "Problem while sending email, Please check details.";
                    throw;
                }

                return View("Wyslano", obj);
            }
            else
            {
                return View("SendEmail");
            }

        }
        public ActionResult Wyslano()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}