using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BourneCars.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
        public string Mileage { get; set; }
        public string FuelType { get; set; }
        public string RegistrationYear { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string Transmission { get; set; }
    }
}