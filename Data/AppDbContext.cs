using Microsoft.EntityFrameworkCore;
using CrudApp.Models;

namespace CrudApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Siswa> Siswas { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
