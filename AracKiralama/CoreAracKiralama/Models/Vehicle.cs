using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreAracKiralama.Models
{
    public class Vehicle
    {
        [DisplayName("ID")]
        public int VehicleId { get; set; }
        [DisplayName("Araç Adı")]
        [Required(ErrorMessage = "Araç Adını Boş Geçemezsiniz.")]
        public string VehicleName { get; set; }
        [DisplayName("Plaka")]
        [Required(ErrorMessage = "Araç Plakasını Boş Geçemezsiniz.")]
        public string VehiclePlate { get; set; }
        [DisplayName("Ücret")]
        [Required(ErrorMessage = "Araç Ücretini Boş Geçemezsiniz.")]
        public decimal VehiclePrice { get; set; }
        [DisplayName("Araç Durumu")]
        public bool VehicleStatus { get; set; }
        [DisplayName("Araç Resim Url")]
        public string VehicleImgUrl { get; set; }
        [DisplayName("Araç Tipi")]
        public string VehicleType { get; set; }
        [DisplayName("Vites Tipi")]
        public string VehicleGearType { get; set; }
        [DisplayName("Yakıt Tipi")]
        public string VehicleFuelType { get; set; }
        [DisplayName("Bakım Tarihi")]
        [Required(ErrorMessage = "Geçmiş Bakım Tarihini Giriniz.")]
        public DateTime VehicleInspectionTime { get; set; }
        [DisplayName("Marka ID")]
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        [DisplayName("Firma ID")]
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        [NotMapped]
        public IFormFile VehicleImgFile { get; set; }
    }
}
