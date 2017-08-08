using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace BourneCars.Controllers
{
    public class CarDetailsController : SurfaceController
    {
        public const string CarDetailsPartialViewFolder = "~/Views/Partials/CarDetails";

        public ActionResult RenderCarCarousel()
        {
            return PartialView(CarDetailsPartialViewFolder + "/_CarCarousel.cshtml");
        }

        public ActionResult RenderCarDescription()
        {
            return PartialView(CarDetailsPartialViewFolder + "/_CarDescription.cshtml");
        }

        public ActionResult RenderCarFeatures()
        {
            return PartialView(CarDetailsPartialViewFolder + "/_CarFeatures.cshtml");
        }

        public ActionResult RenderCarDetailsForm()
        {
            return PartialView(CarDetailsPartialViewFolder + "/_CarDetailsEnquireform.cshtml");
        }
    }
}