using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BourneCars.Models
{
    public class SearchFormModel
    {
       
        public string CarManufactureType { get; set; }

        public List<SelectListItem> CarManufactureTypes { get; set; }

        public string CarModel { get; set; }

        public int MinPrice { get; set; }
        
        public List<SelectListItem> MinPrices { get; set; }

        public int MaxPrice { get; set; }

        public List<SelectListItem> MaxPrices { get; set; }

    }
}