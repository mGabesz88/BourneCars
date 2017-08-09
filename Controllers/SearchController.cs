using System.Web.Mvc;
using BourneCars.Helpers;
using BourneCars.Models;
using Umbraco.Web.Mvc;

namespace BourneCars.Controllers
{
    public class SearchController : SurfaceController
    {
        private DropDownHelper preValueHelper = new DropDownHelper();

        public const string SearchPartialViewFolder = "~/Views/Partials/Search";

        public ActionResult RenderMainSearchForm()
        {
            SearchFormModel model = new SearchFormModel();
            model.CarManufactureTypes = preValueHelper.GetPreValuesFromAppSettingName("carManufactureDropDownId");
            model.MinPrices = preValueHelper.GetPreValuesFromAppSettingName("minPrice");
            model.MaxPrices = preValueHelper.GetPreValuesFromAppSettingName("maxPrice");
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
    }
}