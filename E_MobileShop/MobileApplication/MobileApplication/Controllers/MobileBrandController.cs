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
    public class MobileBrandController : Controller
    {
        readonly IRepositoryCRUD<MobileBrand> _brand;
        public MobileBrandController(IRepositoryCRUD<MobileBrand> brand)
        {
            _brand = brand;
        }

        // GET: MobileBrandController
        public ActionResult Index()
        {
            var data = _brand.FindAll();
            return View(data);
        }

        // GET: MobileBrandController/Details/5
        public ActionResult Details(int id)
        {
            var data = _brand.FindById(id);
            return View(data);
        }

        // GET: MobileBrandController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MobileBrandController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MobileBrand entity)
        {
            try
            {
                _brand.Create(entity);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: MobileBrandController/Edit/5
        public ActionResult Edit(int id)
        {            
            return View(_brand.FindById(id));
        }

        // POST: MobileBrandController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MobileBrand entity)
        {
            try
            {
                _brand.Update(entity);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MobileBrandController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MobileBrandController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, MobileBrand entity)
        {
            try
            {
                _brand.Delete(entity);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
