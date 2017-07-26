using System.Web.Mvc;
using Umbraco.Web.Mvc;


namespace BourneCars.Controllers
{
    public class SearchController : SurfaceController
    {
        public const string SearchPartialViewFolder = "~/Views/Partials/Search";

        public ActionResult RenderMainSearchForm()
        {
            return PartialView(SearchPartialViewFolder + "/_MainSearchForm.cshtml");
        }

        public ActionResult RenderSearchListing()
        {
            return PartialView(SearchPartialViewFolder + "/_SearchLiting.cshtml");
        }
    }
}