using System.ComponentModel.DataAnnotations;

namespace CrudApp.Models
{
    public class Admin
    {
        public int Id { get; set; }

        [Required]
        public string? User { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
