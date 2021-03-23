
using CoreAracKiralama.Models;
using CoreAracKiralama.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using System.Linq;
using X.PagedList;

namespace CoreAracKiralama.Areas.AdminPaneli.Controllers
{
    [Area("AdminPaneli")]
    [Authorize]
    public class BrandController : Controller
    {
        BrandRepository Repository = new BrandRepository();

        public IActionResult Index(string search, int page = 1)
        {
            var brands = from m in Repository.List()
                         select m;
            if (!String.IsNullOrEmpty(search))
            {
                brands = brands.Where(s => s.BrandName.Contains(search.ToUpper(new CultureInfo("en-US", false))));
            }
            return View(brands.ToList().ToPagedList(page, 8));
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Brand brand)
        {
            if (!ModelState.IsValid)
            {
                return View("Add");
            }
            else
            {
                brand.BrandName = brand.BrandName.ToUpper(new CultureInfo("en-US", false));
                Repository.Create(brand);
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(Repository.Get(id));
        }
        [HttpPost]
        public IActionResult Update(Brand brand)
        {
            Repository.Update(brand);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var model = Repository.Get(id);
            if (model.BrandStatus == true)
            {
                model.BrandStatus = false;
            }
            else
            {
                model.BrandStatus = true;
            }

            Repository.Update(model);
            return RedirectToAction("Index");
        }
    }
}
