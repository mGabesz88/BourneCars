using System;
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
            model.MinPrices = PricesHelper.GetMinPriceSetting();
            model.MinPrice = 0;
            model.MaxPrices = PricesHelper.GetMaxPriceSetting();
            model.MaxPrice = 2000000;
            model.CarModels = GetAllModels();
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
                model.CarModels = GetModels(model.CarManufactureType);
                TempData["searchFormModel"] = model;
                return RedirectToUmbracoPage(3135);
            }
            return CurrentUmbracoPage();
        }



        private List<SelectListItem> GetAllModels()
        {
            List<SelectListItem> models = new List<SelectListItem>();
            models.Add(new SelectListItem() { Text = "All Models", Value = "All Models" });
            foreach (var model in CarsHelper.GetAllModels())
            {
                models.Add(new SelectListItem() { Text = model, Value = model });
            }
            return models;
        }

        private List<SelectListItem> GetModels(string manufacturer)
        {
            List<SelectListItem> models = new List<SelectListItem>();
            models.Add(new SelectListItem() { Text = "All Models", Value = "All Models" });
            foreach (var model in CarsHelper.GetAllModels(manufacturer))
            {
                models.Add(new SelectListItem() { Text = model, Value = model });
            }
            return models;
        }
    }
}