using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace BourneCars.Controllers
{
    public class FinancePageController : SurfaceController
    {
        public const string FinancePartialViewFolder = "~/Views/Partials/Finance";
        public ActionResult RenderFinanceDetails()
        {
            return PartialView(FinancePartialViewFolder + "/_FinanceDetails.cshtml");
        }

        public ActionResult RenderContactUsDetails()
        {
            return PartialView(FinancePartialViewFolder + "/_ContactUsDetails.cshtml");
        }
    }
}