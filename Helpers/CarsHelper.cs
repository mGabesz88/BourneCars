using BourneCars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using umbraco;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.Models;

namespace BourneCars.Helpers
{
    public static class CarsHelper
    {
        public static List<SelectListItem> GetMakesFromCms()
        {
            var allCars = GetAllCars();
            var allMakes = allCars.Select(o => o.Make).Distinct<string>();
            List<SelectListItem> listOfMakes = new List<SelectListItem>();
            string prevalue = AppSettingsHelper.GetStringFromAppSetting("defaultDropDOwnValue");
            listOfMakes.Add(new SelectListItem { Value = prevalue, Text = prevalue });

            foreach (var child in allMakes)
            {
                listOfMakes.Add(new SelectListItem { Value = child, Text = child });
            }
            return listOfMakes;
        }

        internal static List<string> GetAllModels(string id)
        {
            var allCars = GetAllCars();
            var carsOfThisMake = allCars.Where(c => c.Make == id);
            var allModelsOfThisMake = carsOfThisMake.Select(c => c.Model).Distinct<string>().ToList();
            return allModelsOfThisMake;
        }

        internal static List<string> GetAllModels()
        {
            var allCars = GetAllCars();
            var allModels = allCars.Select(c => c.Model).Distinct<string>().ToList();
            return allModels;
        }

        public static List<Car> GetAllCars()
        {
            var allCars = new List<Car>();
            var UmbracoHelper = new UmbracoHelper(UmbracoContext.Current);
            var carsPage = UmbracoHelper.TypedContent(3135);
            foreach (var item in carsPage.Children())
            {
                var car = new Car()
                {
                    Id = item.Id,
                    Make = item.GetPropertyValue<string>("CompanyMake"),
                    Image = item.GetPropertyValue<IPublishedContent>("podImage").Url,
                    Url = item.Url,
                    Name = item.Name,
                    Mileage = item.GetPropertyValue<string>("milage"),
                    FuelType = item.GetPropertyValue<string>("fuel"),
                    RegistrationYear = item.GetPropertyValue<DateTime>("registrationYear").ToString("yyyy"),
                    Transmission = item.GetPropertyValue<string>("transmission"),
                    Price = item.GetPropertyValue<int>("price"),
                    Model = item.GetPropertyValue<string>("model"),
                };
                allCars.Add(car);
            }
            return allCars;

        }
    }
}