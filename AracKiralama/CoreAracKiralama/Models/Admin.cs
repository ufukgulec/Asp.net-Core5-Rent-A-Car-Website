using System.ComponentModel.DataAnnotations;

namespace CoreAracKiralama.Models
{
    public class Admin
    {
        public int AdminId { get; set; }
        public string AdminName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [StringLength(1)]
        public string AdminRole { get; set; }
    }
}
