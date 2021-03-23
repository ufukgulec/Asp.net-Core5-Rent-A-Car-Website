using CoreAracKiralama.Areas.AdminPaneli.Models;
using CoreAracKiralama.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace CoreAracKiralama.Areas.AdminPaneli.Controllers
{
    [Area("AdminPaneli")]
    [Authorize]
    public class HomeController : Controller
    {
        #region Repositories
        CompanyRepository companyRepository = new CompanyRepository();
        BrandRepository brandRepository = new BrandRepository();
        VehicleRepository vehicleRepository = new VehicleRepository();
        #endregion
        public IActionResult Index()
        {
            Statistics statistics1 = new Statistics()
            {
                BrandCount = brandRepository.List().Count(),
                VehicleCount = vehicleRepository.List().Count(),
                AvailableVehicleCount = vehicleRepository.List("Brand", "Company").Where(s => s.VehicleStatus == true && s.Brand.BrandStatus == true && s.Company.CompanyStatus == true).Count(),
                CompanyCount = companyRepository.List().Count(),
                LatestBrand = brandRepository.List().OrderByDescending(s => s.BrandId).FirstOrDefault().BrandName,
                LatestVehicle = vehicleRepository.List().OrderByDescending(s => s.VehicleId).FirstOrDefault().VehicleName,
                LatestCompany = companyRepository.List().OrderByDescending(s => s.CompanyId).FirstOrDefault().CompanyName,
                NeedtoServices = vehicleRepository.List().Where(s => s.VehicleInspectionTime.AddYears(1) <= DateTime.Now).Count(),
                MinPriceVehicle = vehicleRepository.List().OrderBy(s => s.VehiclePrice).FirstOrDefault().VehicleName,
                MaxPriceVehicle = vehicleRepository.List().OrderByDescending(s => s.VehiclePrice).FirstOrDefault().VehicleName,
                AveragePriceVehicle = vehicleRepository.List().Average(s => s.VehiclePrice).ToString("0.00"),
                TotalPriceVehicle = vehicleRepository.List().Sum(s => s.VehiclePrice).ToString("0"),
                AutoGearVehicle = vehicleRepository.List().Where(s => s.VehicleGearType == "Otomatik").Count(),
                ManuelGearVehicle = vehicleRepository.List().Where(s => s.VehicleGearType == "Manuel").Count(),
                GasolineVehicle = vehicleRepository.List().Where(s => s.VehicleFuelType == "Benzin").Count(),
                DieselVehicle = vehicleRepository.List().Where(s => s.VehicleFuelType == "Dizel").Count()
            };
            return View(statistics1);
        }
    }
}
