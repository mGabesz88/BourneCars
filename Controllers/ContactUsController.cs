using System;
using System.Configuration;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using System.Net.Mail;
using System.Configuration;
using BourneCars.Models;
using Umbraco.Web;

namespace BourneCars.Controllers
{
    public class ContactUsController : SurfaceController
    {
        public const string ContactUsPartialViewFolder = "~/Views/Partials/ContactUs";

        public ActionResult RednerContactDetails()
        {
            return PartialView(ContactUsPartialViewFolder + "/_ContactDetails.cshtml");
        }

        public ActionResult RenderContactForm()
        {
            return PartialView(ContactUsPartialViewFolder + "/_ContactForm.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(ContactUsModel model)
        {
            if (ModelState.IsValid)
            {
                SendEmail(model);
                TempData["ContactSuccess"] = true;
                return RedirectToCurrentUmbracoPage();
            }
            return CurrentUmbracoPage();
        }

        private void SendEmail(ContactUsModel model)
        {
            MailMessage message = new MailMessage(model.EmailAddress, "website@installumbraco.web.local");
            message.IsBodyHtml = true;
            if (CurrentPage.Id == int.Parse(ConfigurationManager.AppSettings["contactusPage"]))
            {
                message.Subject = string.Format("Contact form Enquiry from {0} - {1}", model.Name, model.EmailAddress);
                message.Body += model.Message;
            }
            else if (CurrentPage.Id == int.Parse(ConfigurationManager.AppSettings["servicePage"]))
            {
                message.Subject = string.Format("Service form Enquiry from {0} - {1}", model.Name, model.EmailAddress);
                message.Body += model.Message;
            }
            else
            {
                message.Subject = string.Format("Car Enquiry from {0} - {1}", model.Name, model.EmailAddress);
                message.Body = string.Format("{0} is Enquiring about {1}", model.Name, model.HiddenField);
                message.Body += "<br />";
                message.Body += model.Message;
            }
            SmtpClient client = new SmtpClient("127.0.0.1", 25);
            client.Send(message);
        }
    }
}