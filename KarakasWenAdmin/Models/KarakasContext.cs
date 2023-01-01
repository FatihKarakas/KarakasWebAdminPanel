using KarakasWenAdmin.Models.Entitys;
using Microsoft.EntityFrameworkCore;

namespace KarakasWenAdmin.Models
{
    public class KarakasContext : DbContext
    {
        public KarakasContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<UserControl> UserControl { get; set; }   
    }
}
