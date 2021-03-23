using CoreAracKiralama.Models;
using CoreAracKiralama.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;

namespace CoreAracKiralama.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        #region Repositories
        BrandRepository brandRepository = new BrandRepository();
        VehicleRepository vehicleRepository = new VehicleRepository();
        CompanyRepository companyRepository = new CompanyRepository();
        #endregion
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            #region Counters
            ViewBag.CompanyCount = companyRepository.List().Where(s => s.CompanyStatus).Count();
            ViewBag.BrandCount = brandRepository.List().Where(s => s.BrandStatus).Count();
            ViewBag.VehicleCount = vehicleRepository.List("Brand", "Company").Where(s => s.Company.CompanyStatus == true && s.Brand.BrandStatus == true).Count();
            #endregion
            #region MostPopular
            var popularCompanies = companyRepository.List("Vehicles").Where(s => s.CompanyStatus == true).OrderByDescending(s => s.Vehicles.Count()).Take(5).ToList();
            var popularBrands = brandRepository.List("Vehicles").Where(s => s.BrandStatus == true).OrderByDescending(s => s.Vehicles.Count()).Take(5).ToList();
            //Group by ile tekrarlanan araç isimlerine göre sıraladım (CLIO 3 EGEA 2 gibi)
            var popularVehicles = vehicleRepository.List("Company").Where(s => s.Company.CompanyStatus == true).GroupBy(s => s.VehicleName).Select(s => new Vehicle
            {
                VehicleName = s.Key,
                VehicleImgUrl = vehicleRepository.List().FirstOrDefault(v => v.VehicleName == s.Key).VehicleImgUrl,
                VehicleId = s.Count()
            }).OrderByDescending(s => s.VehicleId).Take(5).ToList();
            ViewBag.popularCompanies = popularCompanies;
            ViewBag.popularBrands = popularBrands;
            ViewBag.popularVehicles = popularVehicles;
            #endregion
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}