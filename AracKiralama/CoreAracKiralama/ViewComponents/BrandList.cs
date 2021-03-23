using CoreAracKiralama.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreAracKiralama.ViewComponents
{
    public class BrandList : ViewComponent
    {
        /// <summary>
        /// Markaları Araç Sayısına Göre Sıralar
        /// </summary>
        /// <returns></returns>
        public IViewComponentResult Invoke()
        {
            BrandRepository repository = new BrandRepository();
            var brandList = repository.List("Vehicles").Where(s => s.BrandStatus == true).OrderByDescending(s => s.Vehicles.Count).Take(11).ToList();

            return View(brandList);
        }
    }
}