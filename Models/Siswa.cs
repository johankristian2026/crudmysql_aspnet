using System.ComponentModel.DataAnnotations;

namespace CrudApp.Models
{
    public class Siswa
    {
        public int Id { get; set; }

        [Required]
        public string? Nama { get; set; }

        [Required]
        public string Kelas { get; set; }

        [Required]
        public string? Alamat { get; set; }
    }
}
