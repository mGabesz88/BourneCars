using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BourneCars.Models
{
    public class HomePageSearchModel
    {

        public string CarManufactureType { get; set; }

        public List<SelectListItem> CarManufactureTypes { get; set; }

        public int MinPrice { get; set; }

        public List<SelectListItem> MinPrices { get; set; }

        public int MaxPrice { get; set; }

        public List<SelectListItem> MaxPrices { get; set; }
    }
}