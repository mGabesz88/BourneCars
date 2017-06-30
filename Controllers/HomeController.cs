using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace BourneCars.Controllers
{
    public class HomeController: SurfaceController
    {
        public const string HomePartialViewFolder = "~/Views/Partials/Home";
        public ActionResult RenderFeaturedCars()
        {
            return PartialView(HomePartialViewFolder + "/_FeaturedCars.cshtml");
        }

        public ActionResult RenderRecentlyAddedCars()
        {
            return PartialView(HomePartialViewFolder + "/_RecentlyAddedCars.cshtml");
        }

        public ActionResult RenderHomePageSearch()
        {
            return PartialView(HomePartialViewFolder + "/_HomePageSearch.cshtml");
        }

        public ActionResult RenderSlider()
        {
            return PartialView(HomePartialViewFolder + "/_Slider.cshtml");
        }
    }
}