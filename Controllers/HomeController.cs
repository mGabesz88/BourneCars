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
            HomePageSearchModel model =  new HomePageSearchModel();
            model.CarManufactureTypes = GetMakesFromCms();
            model.MinPrices = GetMinPriceSetting();
            model.MaxPrices = GetMaxPriceSetting();
            model.JsonObject = JsonFormData();
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

        private List<SelectListItem> GetMakesFromCms()
        {
            List<SelectListItem> listOfMakes = new List<SelectListItem>();
            string prevalue = AppSettingsHelper.GetStringFromAppSetting("defaultDropDOwnValue");
            listOfMakes.Add(new SelectListItem { Value = prevalue, Text = prevalue });

            IPublishedContent configurationNode = Umbraco.TypedContent(AppSettingsHelper.GetIntFromAppSetting("configurationFolder"));

            foreach (var child in configurationNode.Children)
            {
                listOfMakes.Add(new SelectListItem { Value = child.Name, Text = child.Name});
            }
            return listOfMakes;
        }

        private List<SelectListItem> GetMinPriceSetting()
        {
            List<SelectListItem> minPriceList = new List<SelectListItem>();
            string prevalue = AppSettingsHelper.GetStringFromAppSetting("defaultDropDOwnValue");
            minPriceList.Add(new SelectListItem { Value = prevalue, Text = prevalue });

            IPublishedContent configurationNode = Umbraco.TypedContent(AppSettingsHelper.GetIntFromAppSetting("configurationFolder"));


            foreach (var child in (IEnumerable<string>)configurationNode.GetPropertyValue("minPrice"))
            {
                minPriceList.Add(new SelectListItem { Value = child, Text = child });
            }
            return minPriceList;
        }

        private List<SelectListItem> GetMaxPriceSetting()
        {
            List<SelectListItem> minPriceList = new List<SelectListItem>();
            string prevalue = AppSettingsHelper.GetStringFromAppSetting("defaultDropDOwnValue");
            minPriceList.Add(new SelectListItem { Value = prevalue, Text = prevalue });

            IPublishedContent configurationNode = Umbraco.TypedContent(AppSettingsHelper.GetIntFromAppSetting("configurationFolder"));


            foreach (var child in (IEnumerable<string>)configurationNode.GetPropertyValue("maxPrice"))
            {
                minPriceList.Add(new SelectListItem { Value = child, Text = child });
            }
            return minPriceList;
        }

        private string JsonFormData()
        {
            List<Cars> listOfMakes = new List<Cars>();
            string prevalue = AppSettingsHelper.GetStringFromAppSetting("defaultDropDOwnValue");
           
            IPublishedContent configurationNode = Umbraco.TypedContent(AppSettingsHelper.GetIntFromAppSetting("configurationFolder"));

            foreach (var child in configurationNode.Children)
            {  
                var cars = new Cars
                {
                    make = child.Name,
                    model = (string[])child.GetPropertyValue("model")
                };

                listOfMakes.Add(cars);
            }
            string output = JsonConvert.SerializeObject(listOfMakes);
            return output;
        }

    }
}
