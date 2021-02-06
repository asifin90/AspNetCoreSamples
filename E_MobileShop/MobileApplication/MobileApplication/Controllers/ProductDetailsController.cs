using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileApplication.Contracts;
using MobileApplication.Models;

namespace MobileApplication.Controllers
{
    public class ProductDetailsController : Controller
    {
        IRepositoryCRUD<ProductDetails> _product;
        public ProductDetailsController(IRepositoryCRUD<ProductDetails> product)
        {
            _product = product;
        }

        // GET: ProductDetailsController
        public ActionResult Index()
        {
            return View(_product.FindAll());
        }

        // GET: ProductDetailsController/Details/5
        public ActionResult Details(int id)
        {
            return View(_product.FindById(id));
        }

        // GET: ProductDetailsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductDetailsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductDetails entity)
        {
            try
            {
                _product.Create(entity);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductDetailsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_product.FindById(id));
        }

        // POST: ProductDetailsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductDetails entity)
        {
            try
            {
                _product.Update(entity);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductDetailsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_product.FindById(id));
        }

        // POST: ProductDetailsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ProductDetails entity)
        {
            try
            {
                _product.Delete(entity);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
