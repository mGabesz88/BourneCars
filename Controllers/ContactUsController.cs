using System;
using System.Configuration;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using System.Net.Mail;
using System.Configuration;
using BourneCars.Models;
using BourneCars.Models.ViewModels;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ContactUsSubmitForm(ContactUsViewModel model)
        {
            if (ModelState.IsValid)
            {
                SendContactFormEmail(model);
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

        private void SendContactFormEmail(ContactUsViewModel model)
        {
            MailMessage message = new MailMessage(model.EmailAddress, "website@installumbraco.web.local");
            message.IsBodyHtml = true;
            if (CurrentPage.Id == int.Parse(ConfigurationManager.AppSettings["contactusPage"]))
            {
                message.Subject = string.Format("Contact form enquiry from {0} - {1}", model.Name, model.EmailAddress);
                message.Body = string.Format("<b>" + "Name:" + " </b> " + "{0}", model.Name);
                message.Body += "<br />";
                message.Body += string.Format("<b>" + "Email:" + " </b> " + "{0}", model.EmailAddress);
                message.Body += "<br />";
                if (!string.IsNullOrWhiteSpace(model.NoneRequiredPhoneNumber))
                {
                    message.Body += string.Format("<b>" + "Phone number:" + " </b> " + "{0}", model.NoneRequiredPhoneNumber);
                }
                message.Body += "<br />";
                message.Body += string.Format("<b>" + "Message:" + " </b>" + "{0}", model.Message);
            }
            else
            {
                message.Subject = string.Format("Car Enquiry from {0} - {1}", model.Name, model.EmailAddress);
                message.Body = string.Format("{0} is Enquiring about {1}", model.Name, model.HiddenField);
                message.Body += "<br />";
                message.Body += string.Format("<b>" + "Name:" + " </b> " + "{0}", model.Name);
                message.Body += "<br />";
                message.Body += string.Format("<b>" + "Email:" + " </b> " + "{0}", model.EmailAddress);
                message.Body += "<br />";
                if (!string.IsNullOrWhiteSpace(model.NoneRequiredPhoneNumber))
                {
                    message.Body += string.Format("<b>" + "Phone number:" + " </b> " + "{0}", model.NoneRequiredPhoneNumber);
                }
                message.Body += "<br />";
                message.Body += string.Format("<b>" + "Message:" + " </b>" + "{0}", model.Message);
            }
            SmtpClient client = new SmtpClient("127.0.0.1", 25);
            client.Send(message);
        }
    }
}