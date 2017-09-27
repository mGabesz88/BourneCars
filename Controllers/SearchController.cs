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
            model.CarManufactureTypes = CarsHelper.GetMakesFromCms();
            model.MinPrices = GetMinPriceSetting();
            model.MaxPrices = GetMaxPriceSetting();
            if (TempData["Search"] != null)
            {
               // model = (SearchFormModel)TempData["searchFormModel"];
            }
            return PartialView(SearchPartialViewFolder + "/_MainSearchForm.cshtml", model);
        }

        public ActionResult RenderSearchListing()
        {
            return PartialView(SearchPartialViewFolder + "/_SearchLiting.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(SearchFormModel model)
        {
            if (ModelState.IsValid)
            {
                //Set TempData for selected cars to implement the filter
                TempData["Search"] = true;
                TempData["searchFormModel"] = model;
                return RedirectToUmbracoPage(3135);
            }
            return CurrentUmbracoPage();
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