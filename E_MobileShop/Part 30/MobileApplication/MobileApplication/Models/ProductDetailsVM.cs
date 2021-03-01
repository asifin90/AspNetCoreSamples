using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileApplication.Models
{
    public class ProductDetailsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Battery { get; set; }
        public string Processor { get; set; }
        public double DisplaySize { get; set; }
        public string OperatingSystem { get; set; }
        public string SimDetails { get; set; }
        public double weight { get; set; }
        public bool isWIFISupport { get; set; }
        public bool isBluetoothSupport { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public IFormFile ProductImage { get; set; }
        public string ImagePath { get; set; }

        public decimal price { get; set; }
        public double  Quantity { get; set; }
    }
}
