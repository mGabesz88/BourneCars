using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using BourneCars.Helpers;
using BourneCars.Models;
using Newtonsoft.Json;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.WebApi;

namespace BourneCars.Controllers
{
    public class FormDataController : UmbracoApiController
    {
        [HttpGet]
        public string GetAllProducts(string id)
        {
            SearchFormModel model = new SearchFormModel();
            List<Cars> listOfMakes = new List<Cars>();
            IPublishedContent configurationNode = Umbraco.TypedContent(AppSettingsHelper.GetIntFromAppSetting("configurationFolder"));

            foreach (var child in configurationNode.Children.Where(n => n.Name == id))
            {
                var cars = new Cars
                {
                    make = child.Name,
                    model = (string[])child.GetPropertyValue("model")
                };

                listOfMakes.Add(cars);
            }

            string output = JsonConvert.SerializeObject(listOfMakes);
            return output;
        }
    }
}
