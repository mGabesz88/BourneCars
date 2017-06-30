using System.Web.Mvc;
using Umbraco.Web.Mvc;

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
    }
}