using CoreAracKiralama.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace CoreAracKiralama.Repositories
{
    public class VehicleRepository : IRepository<Vehicle>
    {
        public List<SelectListItem> VehicleTypeList()
        {
            List<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Text="İş-Seyahat",
                    Value="İş-Seyahat"
                },
                new SelectListItem
                {
                    Text="Arazi",
                    Value="Arazi"
                },

                new SelectListItem
                {
                    Text="Motorsiklet",
                    Value="Motorsiklet"
                },
                new SelectListItem
                {
                    Text="Ticari",
                    Value="Ticari"
                },
                new SelectListItem
                {
                    Text="Spor",
                    Value="Spor"
                },
                new SelectListItem
                {
                    Text="Vip",
                    Value="Vip"
                }
            };
            return list;
        }
        public List<SelectListItem> VehicleGearTypeList()
        {
            List<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Text="Manuel",
                    Value="Manuel"
                },
                new SelectListItem
                {
                    Text="Otomatik",
                    Value="Otomatik"
                },
                new SelectListItem
                {
                    Text="Yarı Otomatik",
                    Value="Yarı Otomatik"
                }

            };
            return list;
        }
        public List<SelectListItem> VehicleFuelTypeList()
        {
            List<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Text="Benzin",
                    Value="Benzin"
                },
                new SelectListItem
                {
                    Text="Dizel",
                    Value="Dizel"
                },
                new SelectListItem
                {
                    Text="Bezin+Lpg",
                    Value="Bezin+Lpg"
                },
                new SelectListItem
                {
                    Text="Elektrik",
                    Value="Elektrik"
                }

            };
            return list;
        }

    }
}
