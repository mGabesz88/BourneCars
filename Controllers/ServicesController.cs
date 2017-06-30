using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace BourneCars.Controllers
{
    public class ServicesController : SurfaceController
    {
        public const string ServicesUsPartialViewFolder = "~/Views/Partials/Services";
        public ActionResult RenderServicesDescription()
        {
            return PartialView(ServicesUsPartialViewFolder + "/_ServicesDescription.cshtml");
        }

        public ActionResult RenderServicesRequestForm()
        {
            return PartialView(ServicesUsPartialViewFolder + "/_ServicesRequestForm.cshtml");
        }
    }
}