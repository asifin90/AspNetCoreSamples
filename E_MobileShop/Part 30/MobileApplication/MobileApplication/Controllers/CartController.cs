using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MobileApplication.Contracts;
using MobileApplication.Helpers;
using MobileApplication.Models;
using MobileApplication.Repository;

namespace MobileApplication.Controllers
{
    public class CartController : Controller
    {
        readonly IRepositoryUser _user;
        readonly ICartProductsRepository _cartProdrepo;
        readonly ICartRepository _cart;
        readonly IProductDetailsRepo _product;        
        public CartController(IRepositoryUser user, ICartProductsRepository cartProdrepo, IProductDetailsRepo product, ICartRepository cart)
        {
            _user = user;
            _cartProdrepo = cartProdrepo;
            _product = product;
            _cart = cart;            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">ProductId</param>
        /// <param name="quantity">Quantity</param>
        /// /// <param name="flag">Flag helps to check product already available in cart and update quantity of selected product on cart</param>
        /// <returns></returns>
        public JsonResult Buy(int id, int quantity, bool flag=false)
        {
            var user = User.Identity.Name;
            string Userid = _user.FindById(user).Id;
            Cart objCart = new Cart();
            CartProducts objCartProducts = new CartProducts();            
            objCart.UserId = Userid;
            var cartdetails = _cart.FindById(Userid);
            if (cartdetails == null)
            {
                _cart.Create(objCart);
                cartdetails = _cart.FindById(Userid);
            }
            var cartProductDetails = _cartProdrepo.FindById(cartdetails.Id, id);
            if (cartProductDetails == null)
            {                
                objCartProducts.CartId = cartdetails.Id;
                objCartProducts.productId = id;
                objCartProducts.quantity = quantity;
                _cartProdrepo.Create(objCartProducts);
                cartProductDetails = _cartProdrepo.FindById(cartdetails.Id, id);
            }
            else
            {
                // update quantity if already available
                if (flag)
                    cartProductDetails.quantity = quantity;
                else
                    cartProductDetails.quantity = cartProductDetails.quantity + quantity;
                _cartProdrepo.Update(cartProductDetails);
            }
            return Json(quantity);
            //return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            CartProductviewModel cartViewModel = new CartProductviewModel();
            List<ProductDetailsVM> lstProductDetails = new List<ProductDetailsVM>();
            var user = User.Identity.Name;
            string UserId = _user.FindById(user).Id;
            var cart = _cart.FindCartByUser(UserId);
            var cartProduct = _cartProdrepo.FindProductByCart(cart.Id);
            
            if (cart != null)
            {
                var cartProducts = _product.FindAllProductByCart(cart.Id);                
                cartViewModel.CartId = cart.Id;
                cartViewModel.UserId = UserId;                
                cartViewModel.products = cartProducts;
                return View(cartViewModel);
            }
            else
            {
                return View();
            }
        }











        //public JsonResult Buy(int id)
        //{

        //    List<ProductDetails> cart;
        //    if (SessionHelper.GetDeserializeSessionData<List<ProductDetails>>(HttpContext.Session, "cart") == null)
        //    {
        //        cart = new List<ProductDetails>();
        //        cart.Add(_product.FindById(id));
        //    }
        //    else
        //    {
        //        cart = SessionHelper.GetDeserializeSessionData<List<ProductDetails>>(HttpContext.Session, "cart");
        //        int index = isExist(id.ToString());
        //        if (index != -1)
        //        {
        //            //cart[index].quantity++;
        //        }
        //        else
        //        {
        //            cart.Add(_product.FindById(id));
        //        }
        //    }
        //    SessionHelper.SetSerializeSessionData(HttpContext.Session, "cart", cart);
        //    return Json(cart.Count.ToString());
        //}



        public IActionResult Remove(string id)
        {
            List<ProductDetails> cart = SessionHelper.GetDeserializeSessionData<List<ProductDetails>>(HttpContext.Session, "cart");
            int index = isExist(id);
            cart.RemoveAt(index);
            SessionHelper.SetSerializeSessionData(HttpContext.Session, "cart", cart);
            return View();
        }

        //public IActionResult Index()
        //{
        //    var cart = SessionHelper.GetDeserializeSessionData<List<ProductDetails>>(HttpContext.Session, "cart");
        //    ViewBag.Cart = cart;
        //    List<ProductDetailsVM> lstProductDetails = new List<ProductDetailsVM>();
        //    foreach (var item in cart)
        //    {
        //        ProductDetailsVM vmProduct = new ProductDetailsVM()
        //        {
        //            Battery = cart[0].Battery,
        //            BrandName = cart[0].Battery,
        //            isBluetoothSupport = cart[0].isBluetoothSupport,
        //            DisplaySize = cart[0].DisplaySize,
        //            isWIFISupport = cart[0].isWIFISupport,
        //            Name = cart[0].Name,
        //            OperatingSystem = cart[0].OperatingSystem,
        //            Processor = cart[0].Processor,
        //            //ProductImage = cart[0].Image,
        //            weight = cart[0].weight
        //        };
        //        lstProductDetails.Add(vmProduct);
        //    }
        //    //ViewBag.Total = cart.Sum(item => item.price* item.quantity)
        //    return View(lstProductDetails);
        //}

        private int isExist(string id)
        {
            List<ProductDetails> cart = SessionHelper.GetDeserializeSessionData<List<ProductDetails>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Id.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
