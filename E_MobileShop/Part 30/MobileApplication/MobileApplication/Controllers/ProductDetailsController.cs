using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileApplication.Contracts;
using MobileApplication.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using MobileApplication.Helpers;
using MobileApplication.Repository;

namespace MobileApplication.Controllers
{
    [Authorize(Roles = "Administrator,Dealer")]
    public class ProductDetailsController : Controller
    {
        IRepositoryCRUD<MobileBrand> _brand;
        IProductDetailsRepo _product;
        IWebHostEnvironment webHostEnvironment;
        public ProductDetailsController(IProductDetailsRepo product,  IWebHostEnvironment hostEnvironment, IRepositoryCRUD<MobileBrand> brand)
        {
            _brand = brand;
            _product = product;
            webHostEnvironment = hostEnvironment;
        }

        [AllowAnonymous]
        // GET: ProductDetailsController
        public ActionResult Index()
        {
            var cart = SessionHelper.GetDeserializeSessionData<List<ProductDetails>>(HttpContext.Session, "cart");
            var products = _product.FindAll();
            var brands = _brand.FindAll();
            foreach (var item in products)
            {
                item.Name = $"{brands.Where(p=>p.Id == item.BrandId).FirstOrDefault().Name} {item.Name}";
            }
            return View(products);
        }

        [AllowAnonymous]
        // GET: ProductDetailsController/Details/5
        public ActionResult Details(int id)
        {
            return View(_product.FindById(id));
        }

        // GET: ProductDetailsController/Create
        public ActionResult Create()
        {
            ViewBag.Brand = new SelectList(_brand.FindAll(), "Id", "Name");
            return View();
        }

        // POST: ProductDetailsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string Brand, ProductDetailsVM viewModel)
        {
            try
            {
                string uniqueFileName = FileUpload(viewModel);

                ProductDetails details = new ProductDetails
                {
                    Battery = viewModel.Battery,
                    DisplaySize = viewModel.DisplaySize,
                    isBluetoothSupport = viewModel.isBluetoothSupport,
                    isWIFISupport = viewModel.isWIFISupport,
                    Name = viewModel.Name,
                    OperatingSystem = viewModel.OperatingSystem,
                    Processor = viewModel.Processor,
                    SimDetails = viewModel.SimDetails,
                    weight = viewModel.weight,
                    Image = uniqueFileName,
                    BrandId = int.Parse(Brand)
                };
                _product.Create(details);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        private string FileUpload(ProductDetailsVM model)
        {
            string uniqueFileName = null;
            int index = model.ProductImage.FileName.LastIndexOf('\\');
            if (index < 0)
                index = 0;
            else
                index = index + 1;

            if (model.ProductImage != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProductImage.FileName.Substring(index);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ProductImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        // GET: ProductDetailsController/Edit/5
        public ActionResult Edit(int id)
        {
            var product = _product.FindById(id);
            ViewBag.Brand = new SelectList(_brand.FindAll(),"Id", "Name", product.BrandId);
            ProductDetailsVM details = new ProductDetailsVM
            {
                Battery = product.Battery,
                DisplaySize = product.DisplaySize,
                isBluetoothSupport = product.isBluetoothSupport,
                isWIFISupport = product.isWIFISupport,
                Name = product.Name,
                OperatingSystem = product.OperatingSystem,
                Processor = product.Processor,
                SimDetails = product.SimDetails,
                weight = product.weight,
                ImagePath = product.Image,
                BrandId = product.BrandId,
                price = product.Price
            };
            return View(details);
        }

        // POST: ProductDetailsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, string Brand, ProductDetailsVM viewModel)
        {
            try
            {
                viewModel.BrandId = Convert.ToInt32(Brand);
                string uniqueFileName = viewModel.ImagePath;
                if (viewModel.ProductImage != null)
                {
                    uniqueFileName = FileUpload(viewModel);
                }
                ProductDetails details = new ProductDetails
                {
                    Id = viewModel.Id,
                    Battery = viewModel.Battery,
                    DisplaySize = viewModel.DisplaySize,
                    isBluetoothSupport = viewModel.isBluetoothSupport,
                    isWIFISupport = viewModel.isWIFISupport,
                    Name = viewModel.Name,
                    OperatingSystem = viewModel.OperatingSystem,
                    Processor = viewModel.Processor,
                    SimDetails = viewModel.SimDetails,
                    weight = viewModel.weight,
                    Image = uniqueFileName,
                    BrandId = int.Parse(Brand),
                    Price = viewModel.price
                };
                _product.Update(details);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
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
