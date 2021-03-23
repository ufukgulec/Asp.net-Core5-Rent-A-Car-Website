using CoreAracKiralama.Models;
using CoreAracKiralama.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace CoreAracKiralama.Areas.AdminPaneli.Controllers
{
    [Area("AdminPaneli")]
    [Authorize]
    public class VehicleController : Controller
    {
        VehicleRepository Repository = new VehicleRepository();
        BrandRepository BrandRepository = new BrandRepository();
        CompanyRepository companyRepository = new CompanyRepository();
        private readonly IWebHostEnvironment _environment;

        public VehicleController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        public IActionResult Index(string search, int page = 1)
        {
            var vehicles = from m in Repository.List("Brand")
                           select m;
            if (!String.IsNullOrEmpty(search))
            {
                vehicles = vehicles.Where(s => s.VehicleName.Contains(search.ToUpper(new CultureInfo("en-US", false))) ||
                s.VehiclePlate.Contains(search.ToUpper(new CultureInfo("en-US", false))) ||
                s.Brand.BrandName.Contains(search.ToUpper(new CultureInfo("en-US", false))));
            }
            return View(vehicles.ToList().ToPagedList(page, 8));
        }
        [HttpGet]
        public IActionResult Add()
        {
            List<SelectListItem> brands = (from item in BrandRepository.List()
                                           select new SelectListItem
                                           {
                                               Text = item.BrandName,
                                               Value = item.BrandId.ToString()
                                           }).ToList();
            ViewBag.Brands = brands;
            List<SelectListItem> companies = (from item in companyRepository.List()
                                              select new SelectListItem
                                              {
                                                  Text = item.CompanyName,
                                                  Value = item.CompanyId.ToString()
                                              }).ToList();
            ViewBag.Companies = companies;
            ViewBag.VehicleTypes = Repository.VehicleTypeList();
            ViewBag.VehicleGearTypes = Repository.VehicleGearTypeList();
            ViewBag.VehicleFuelTypes = Repository.VehicleFuelTypeList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(Vehicle vehicle)
        {
            if (!ModelState.IsValid)
            {
                return View("Add");
            }
            else
            {
                vehicle.VehicleName = vehicle.VehicleName.ToUpper(new CultureInfo("en-US", false));
                vehicle.VehiclePlate = vehicle.VehiclePlate.ToUpper();
                vehicle.VehicleStatus = true;
                //Image File Upload
                string resimler = Path.Combine(_environment.WebRootPath, "carImages");
                if (vehicle.VehicleImgFile != null)
                {
                    string newFileName = vehicle.VehicleName + vehicle.VehiclePlate + "." + vehicle.VehicleImgFile.FileName.Split('.').LastOrDefault();
                    if (vehicle.VehicleImgFile.Length > 0)
                    {
                        using (var fileStream = new FileStream(Path.Combine(resimler, newFileName), FileMode.Create))
                        {
                            await vehicle.VehicleImgFile.CopyToAsync(fileStream);
                        }
                    }
                    vehicle.VehicleImgUrl = "/carImages/" + newFileName;
                }
                else
                {
                    vehicle.VehicleImgUrl = "https://media.istockphoto.com/vectors/car-flat-icon-vector-id1144092062?k=6&m=1144092062&s=612x612&w=0&h=KjHYZQoPokl3q-FtNHBx6Nbgy79vQ2BOpsTrgJzVNuA=";
                }


                //Image File Upload
                Repository.Create(vehicle);
                return RedirectToAction("Index");
            }
        }
        public IActionResult Delete(int id)
        {
            Repository.Delete(Repository.Get(id));
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            List<SelectListItem> brands = (from item in BrandRepository.List()
                                           select new SelectListItem
                                           {
                                               Text = item.BrandName,
                                               Value = item.BrandId.ToString()
                                           }).ToList();
            ViewBag.Brands = brands;
            List<SelectListItem> companies = (from item in companyRepository.List()
                                              select new SelectListItem
                                              {
                                                  Text = item.CompanyName,
                                                  Value = item.CompanyId.ToString()
                                              }).ToList();
            ViewBag.Companies = companies;
            ViewBag.VehicleTypes = Repository.VehicleTypeList();
            ViewBag.VehicleGearTypes = Repository.VehicleGearTypeList();
            ViewBag.VehicleFuelTypes = Repository.VehicleFuelTypeList();

            return View(Repository.Get(id));
        }
        [HttpPost]
        public IActionResult Update(Vehicle vehicle)
        {

            Repository.Update(vehicle);
            return RedirectToAction("Index");
        }
        public IActionResult Detail(int id)
        {
            ViewBag.Company = Repository.List("Company").FirstOrDefault(s => s.VehicleId == id).Company.CompanyName;
            var model = Repository.List("Brand").FirstOrDefault(m => m.VehicleId == id);
            return View(model);
        }
    }
}