using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CoreAracKiralama.Models
{
    public class Brand
    {
        [DisplayName("ID")]
        public int BrandId { get; set; }
        [DisplayName("MARKA ADI")]
        [Required(ErrorMessage = "Marka Adını Boş Geçemezsiniz.")]
        public string BrandName { get; set; }
        [DisplayName("MARKA AÇIKLAMASI")]
        public string BrandDescription { get; set; }
        [DisplayName("MARKA GÖRÜNÜRLÜĞÜ")]
        public bool BrandStatus { get; set; }
        public string BrandLogoUrl { get; set; }
        public List<Vehicle> Vehicles { get; set; }
    }
}
