using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileApplication.Models
{
    public class MobileDbContext:DbContext
    {
        public MobileDbContext(DbContextOptions<MobileDbContext> options) : base(options)
        {

        }

        public DbSet<MobileBrand> Brand { get; set; }

    }
}
