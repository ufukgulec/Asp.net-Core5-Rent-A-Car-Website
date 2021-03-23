using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreAracKiralama.Models
{
    public class Company
    {
        [DisplayName("ID")]
        public int CompanyId { get; set; }
        [DisplayName("FİRMA ADI")]
        public string CompanyName { get; set; }
        [DisplayName("FİRMA ADRES")]
        public string CompanyAddress { get; set; }
        [DisplayName("FİRMA TEL")]
        public string CompanyPhoneNumber { get; set; }
        [DisplayName("FİRMA LOGO")]
        public string CompanyLogoUrl { get; set; }
        [DisplayName("FİRMA EPOSTA")]
        public string CompanyEmail { get; set; }
        [DisplayName("PAROLA")]
        public string CompanyPassword { get; set; }
        [DisplayName("FİRMA DURUMU")]
        public bool CompanyStatus { get; set; }
        public List<Vehicle> Vehicles { get; set; }

        [NotMapped]
        public IFormFile CompanyImgFile { get; set; }
    }
}
