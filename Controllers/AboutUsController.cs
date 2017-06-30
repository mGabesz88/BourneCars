using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace BourneCars.Controllers
{
    public class AboutUsController : SurfaceController
    {
        public const string ContactUsPartialViewFolder = "~/Views/Partials/AboutUs";

        public ActionResult RenderAboutUsIntroduction()
        {
            return PartialView(ContactUsPartialViewFolder + "/_AboutUsIntroduction.cshtml");
        }

        public ActionResult RenderAboutUsTeamMebers()
        {
            return PartialView(ContactUsPartialViewFolder + "/_AboutUsTeamMembers.cshtml");
        }
    }
}