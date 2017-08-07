using System.Web.Mvc;
using Umbraco.Web.Mvc;
using System.Net.Mail;
using BourneCars.Models;

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
            message.Subject = string.Format("Enquiry from {0} - {1}", model.Name, model.EmailAddress);
            message.Body = model.Message;
            SmtpClient client = new SmtpClient("127.0.0.1", 25);
            client.Send(message);
        }
    }
}