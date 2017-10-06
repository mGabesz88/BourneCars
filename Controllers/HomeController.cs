using System.Collections.Generic;
using System.Web.Mvc;
using BourneCars.Helpers;
using BourneCars.Models;
using Microsoft.CodeAnalysis;
using Newtonsoft.Json;
using Umbraco.Core.Models;
using Umbraco.Web;
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
            var model =  new SearchFormModel();
            model.CarManufactureTypes = CarsHelper.GetMakesFromCms();
            model.MinPrices = PricesHelper.GetMinPriceSetting();
            model.MinPrice = 0;
            model.MaxPrices = PricesHelper.GetMaxPriceSetting();
            model.MaxPrice = 2000000;
            return PartialView(HomePartialViewFolder + "/_HomePageSearch.cshtml", model);
        }

        public ActionResult RenderSlider()
        {
            return PartialView(HomePartialViewFolder + "/_Slider.cshtml");
        }

        public List<SelectListItem> GetPreValuesFromAppSettingName(string appSettingName)
        {
            int dataTypeId = AppSettingsHelper.GetIntFromAppSetting(appSettingName);
            List<SelectListItem> preValues = DropDownHelper.GetPreValuesFromDataTypeId(dataTypeId);
            return preValues;
        }


    }
}
