using CoreAracKiralama.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using System.Linq;
using X.PagedList;

namespace CoreAracKiralama.Controllers
{
    public class VehicleController : Controller
    {
        #region Repositories
        BrandRepository brandRepository = new BrandRepository();
        VehicleRepository vehicleRepository = new VehicleRepository();
        CompanyRepository companyRepository = new CompanyRepository();
        #endregion
        public IActionResult Index(string search, int minamount, int maxamount, int page = 1)
        {
            #region ViewBags
            ViewBag.Brands = brandRepository.List("Vehicles").Where(s => s.BrandStatus == true && s.Vehicles.Count > 0).OrderBy(s => s.BrandName).ToList();
            ViewBag.Companies = companyRepository.List("Vehicles").Where(s => s.CompanyStatus == true && s.Vehicles.Count > 0).OrderBy(s => s.CompanyName).ToList();
            ViewBag.LatestVehicles = vehicleRepository.List("Brand", "Company").OrderByDescending(s => s.VehicleId).Take(3).ToList();
            ViewBag.LatestCompanies = companyRepository.List().OrderByDescending(s => s.CompanyId).Take(3).ToList();
            ViewBag.CheapestVehicles = vehicleRepository.List("Brand", "Company").Where(s => s.Company.CompanyStatus == true && s.Brand.BrandStatus == true).OrderBy(s => s.VehiclePrice).Take(6).ToList();
            ViewBag.minamount = Convert.ToInt32(vehicleRepository.List().OrderBy(s => s.VehiclePrice).First().VehiclePrice);
            ViewBag.maxamount = Convert.ToInt32(vehicleRepository.List().OrderByDescending(s => s.VehiclePrice).First().VehiclePrice);
            #endregion
            var list = vehicleRepository.List("Brand", "Company").Where(s => s.VehiclePrice >= minamount);
            if (!String.IsNullOrEmpty(search))
            {
                list = list.Where(s => s.VehicleName.Contains(search.ToUpper(new CultureInfo("en-US", false))) ||
                s.Brand.BrandName.Contains(search.ToUpper(new CultureInfo("en-US", false))) ||
                s.Company.CompanyName.Contains(search.ToUpper(new CultureInfo("en-US", false))) ||
                s.VehicleType.ToUpper(new CultureInfo("en-US", false)).Contains(search.ToUpper(new CultureInfo("en-US", false))) ||
                s.VehicleFuelType.ToUpper(new CultureInfo("en-US", false)).Contains(search.ToUpper(new CultureInfo("en-US", false)))
                ).ToList();
            }

            return View(list.ToList().ToPagedList(page, 9));
        }
    }
}
