using CoreAracKiralama.Areas.AdminPaneli.Models;
using CoreAracKiralama.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace CoreAracKiralama.Areas.AdminPaneli.Controllers
{
    [Area("AdminPaneli")]
    [Authorize]
    public class ChartController : Controller
    {
        Context Context = new Context();
        public IActionResult Index()
        {
            List<Point> dataPoints = (from item in Context.Brands.Include(m => m.Vehicles).ToList()
                                      select new Point
                                      {
                                          Brands = item.BrandName,
                                          VehicleCount = item.Vehicles.Count
                                      }).ToList();
            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

            return View();
        }
        public IActionResult Index1()
        {
            List<Point> dataPoints = (from item in Context.Brands.Include(m => m.Vehicles).ToList()
                                      select new Point
                                      {
                                          Brands = item.BrandName,
                                          VehicleCount = item.Vehicles.Count
                                      }).ToList();
            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

            return View();
        }
        public IActionResult Index2()
        {
            List<Point> dataPoints = (from item in Context.Vehicles.Include(m => m.Brand)
                                      select new Point
                                      {
                                          Brands = item.Brand.BrandName + " " + item.VehicleName,
                                          VehicleCount = (int)item.VehiclePrice
                                      }).ToList();
            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

            return View();
        }
        public IActionResult Index3()
        {
            List<Point> dataPoints = (from item in Context.Companies.Include(m => m.Vehicles).ToList()
                                      select new Point
                                      {
                                          Brands = item.CompanyName,
                                          VehicleCount = item.Vehicles.Count
                                      }).ToList();
            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

            return View();
        }
        public IActionResult Index4()
        {
            List<Point> dataPoints = (from item in Context.Companies.Include(m => m.Vehicles).ToList()
                                      select new Point
                                      {
                                          Brands = item.CompanyName,
                                          VehicleCount = item.Vehicles.Count
                                      }).ToList();
            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

            return View();
        }

    }
}

