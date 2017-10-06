using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BourneCars.Helpers
{
    public static class PricesHelper
    {
        public static List<SelectListItem> GetMinPriceSetting()
        {
            List<SelectListItem> minPriceList = new List<SelectListItem>();
            minPriceList.Add(new SelectListItem() { Text = "£0", Value = "0" , Selected = true});
            minPriceList.Add(new SelectListItem() { Text = "£1000", Value = "1000" });
            minPriceList.Add(new SelectListItem() { Text = "£2000", Value = "2000" });
            minPriceList.Add(new SelectListItem() { Text = "£3000", Value = "3000" });
            minPriceList.Add(new SelectListItem() { Text = "£4000", Value = "4000" });
            minPriceList.Add(new SelectListItem() { Text = "£5000", Value = "5000" });
            minPriceList.Add(new SelectListItem() { Text = "£6000", Value = "6000" });
            minPriceList.Add(new SelectListItem() { Text = "£7000", Value = "7000" });
            minPriceList.Add(new SelectListItem() { Text = "£8000", Value = "8000" });
            minPriceList.Add(new SelectListItem() { Text = "£9000", Value = "9000" });
            minPriceList.Add(new SelectListItem() { Text = "£10000", Value = "10000" });
            minPriceList.Add(new SelectListItem() { Text = "£11000", Value = "11000" });
            return minPriceList;
        }

        public static List<SelectListItem> GetMaxPriceSetting()
        {
            List<SelectListItem> maxPriceList = new List<SelectListItem>();
            maxPriceList.Add(new SelectListItem() { Text = "£1000", Value = "1000" });
            maxPriceList.Add(new SelectListItem() { Text = "£2000", Value = "2000" });
            maxPriceList.Add(new SelectListItem() { Text = "£3000", Value = "3000" });
            maxPriceList.Add(new SelectListItem() { Text = "£4000", Value = "4000" });
            maxPriceList.Add(new SelectListItem() { Text = "£5000", Value = "5000" });
            maxPriceList.Add(new SelectListItem() { Text = "£6000", Value = "6000" });
            maxPriceList.Add(new SelectListItem() { Text = "£7000", Value = "7000" });
            maxPriceList.Add(new SelectListItem() { Text = "£8000", Value = "8000" });
            maxPriceList.Add(new SelectListItem() { Text = "£9000", Value = "9000" });
            maxPriceList.Add(new SelectListItem() { Text = "£10000", Value = "10000" });
            maxPriceList.Add(new SelectListItem() { Text = "£11000", Value = "11000" });
            maxPriceList.Add(new SelectListItem() { Text = "£12000 and up", Value = "2000000", Selected = true});
            return maxPriceList;
        }
    }
}