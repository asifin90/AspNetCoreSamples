using Microsoft.EntityFrameworkCore;
using MobileApplication.Models;

namespace MobileApplication
{
    public class MobileDbContext:DbContext
    {
        public MobileDbContext(DbContextOptions<MobileDbContext> options) : base(options)
        {

        }

        public DbSet<MobileBrand> Brand { get; set; }

    }
}
