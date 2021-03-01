using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MobileApplication.Models
{
    public class Cart
    {
        public int Id { get; set; }

        [ForeignKey("UserId")]
        public IdentityUser User { get; set; }
        public string UserId { get; set; }        
    }

    public class CartProducts
    {
        public int Id { get; set; }
        [ForeignKey("CartId")]
        public Cart Cart { get; set; }
        public int CartId { get; set; }

        [ForeignKey("productId")]
        public ProductDetails Product { get; set; }
        public int productId { get; set; }        
        public double quantity { get; set; }
    }

    public class CartProductviewModel
    {
        public int CartId { get; set; }
        
        public string UserId { get; set; }

        public List<ProductDetailsVM> products { get; set; }

    }

}
