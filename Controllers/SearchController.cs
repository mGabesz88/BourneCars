using System.Collections.Generic;
using System.Web.Mvc;
using BourneCars.Helpers;
using BourneCars.Models;
using Newtonsoft.Json;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace BourneCars.Controllers
{
    public class SearchController : SurfaceController
    {
        private static DropDownHelper preValueHelper = new DropDownHelper();

        public const string SearchPartialViewFolder = "~/Views/Partials/Search";

        public  ActionResult RenderMainSearchForm()
        {
            SearchFormModel model = new SearchFormModel();
            model.CarManufactureTypes = GetMakesFromCms();
            model.MinPrices = GetMinPriceSetting();
            model.MaxPrices = GetMaxPriceSetting();
            return PartialView(SearchPartialViewFolder + "/_MainSearchForm.cshtml", model);
        }

        public ActionResult RenderSearchListing()
        {
            return PartialView(SearchPartialViewFolder + "/_SearchLiting.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(ContactUsModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToCurrentUmbracoPage();
            }
            return CurrentUmbracoPage();
        }

        private List<SelectListItem> GetMakesFromCms()
        {
            List<SelectListItem> listOfMakes = new List<SelectListItem>();
            string prevalue = AppSettingsHelper.GetStringFromAppSetting("defaultDropDOwnValue");
            listOfMakes.Add(new SelectListItem { Value = prevalue, Text = prevalue });

            IPublishedContent configurationNode = Umbraco.TypedContent(AppSettingsHelper.GetIntFromAppSetting("configurationFolder"));

            foreach (var child in configurationNode.Children)
            {
                listOfMakes.Add(new SelectListItem { Value = child.Name, Text = child.Name });
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
    }
}