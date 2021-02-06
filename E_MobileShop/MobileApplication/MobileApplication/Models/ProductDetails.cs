using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MobileApplication.Models
{
    public class ProductDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Battery { get; set; }
        public string Processor { get; set; }
        public double DisplaySize { get; set; }
        public string  OperatingSystem { get; set; }
        public string SimDetails { get; set; }
        public double weight { get; set; }
        public bool isWIFISupport { get; set; }
        public bool isBluetoothSupport { get; set; }

        [ForeignKey("MobileBrandId")]
        public MobileBrand LeaveType { get; set; }
    }
}
