using CoreAracKiralama.Data;
using CoreAracKiralama.Models;
using CoreAracKiralama.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace CoreAracKiralama.Areas.AdminPaneli.Controllers
{

    [Area("AdminPaneli")]
    [Authorize]
    public class CompanyController : Controller
    {
        CompanyRepository Repository = new CompanyRepository();
        private readonly IWebHostEnvironment _environment;
        public CompanyController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        public IActionResult Index(string search, int page = 1)
        {
            //Search
            var companies = from m in Repository.List()
                            select m;
            if (!String.IsNullOrEmpty(search))
            {
                companies = companies.Where(s => s.CompanyName.Contains(search.ToUpper(new CultureInfo("en-US", false))));
            }
            return View(companies.ToList().ToPagedList(page, 8));
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(Company company)
        {
            if (!ModelState.IsValid)
            {
                return View("Add");
            }
            else
            {
                company.CompanyName = company.CompanyName.ToUpper(new CultureInfo("en-US", false));
                company.CompanyStatus = true;

                #region ImageFileUpload
                string resimler = Path.Combine(_environment.WebRootPath, "companyImages");
                if (company.CompanyImgFile != null)
                {
                    string newFileName = company.CompanyName + "." + company.CompanyImgFile.FileName.Split('.').LastOrDefault();
                    if (company.CompanyImgFile.Length > 0)
                    {
                        using (var fileStream = new FileStream(Path.Combine(resimler, company.CompanyImgFile.FileName), FileMode.Create))
                        {
                            await company.CompanyImgFile.CopyToAsync(fileStream);
                        }
                    }
                    company.CompanyLogoUrl = "/companyImages/" + newFileName;
                }
                else
                {
                    company.CompanyLogoUrl = "https://cdn3.iconfinder.com/data/icons/filled-construction-1/64/Artboard_1-256.png";
                }
                #endregion

                Repository.Create(company);
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(Repository.Get(id));
        }
        [HttpPost]
        public IActionResult Update(Company company)
        {
            Repository.Update(company);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var model = Repository.Get(id);
            if (model.CompanyStatus == true)
            {
                model.CompanyStatus = false;
            }
            else
            {
                model.CompanyStatus = true;
            }

            Repository.Update(model);
            return RedirectToAction("Index");
        }
        public IActionResult Detail(int id, int page = 1)
        {
            Context context = new Context();
            ViewBag.Company = Repository.Get(id);
            ViewBag.VehicleCount1 = context.Vehicles.Where(s => s.CompanyId == id).Count();
            ViewBag.VehicleCount = Repository.List("Vehicles").Find(s => s.CompanyId == id).Vehicles.Count;
            //context.Vehicles.Include(s => s.Brand).Where(s => s.CompanyId == id).ToList().ToPagedList(page, 6)
            return View(context.Vehicles.Include(s => s.Brand).Where(s => s.CompanyId == id).ToList().ToPagedList(page, 6));
        }
    }
}
