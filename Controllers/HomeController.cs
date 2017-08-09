using System.Web.Mvc;
using BourneCars.Helpers;
using BourneCars.Models;
using Umbraco.Web.Mvc;

namespace BourneCars.Controllers
{
    public class HomeController: SurfaceController
    {
        private DropDownHelper preValueHelper = new DropDownHelper();

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
            HomePageSearchModel model =  new HomePageSearchModel();
            model.CarManufactureTypes = preValueHelper.GetPreValuesFromAppSettingName("carManufactureDropDownId");
            model.MinPrices = preValueHelper.GetPreValuesFromAppSettingName("minPrice");
            model.MaxPrices = preValueHelper.GetPreValuesFromAppSettingName("maxPrice");
            return PartialView(HomePartialViewFolder + "/_HomePageSearch.cshtml", model);
        }

        public ActionResult RenderSlider()
        {
            return PartialView(HomePartialViewFolder + "/_Slider.cshtml");
        }

    }
}