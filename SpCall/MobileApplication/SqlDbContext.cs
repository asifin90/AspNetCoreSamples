using Microsoft.EntityFrameworkCore;
using MobileApplication.Models;

namespace MobileApplication
{
    public partial class SqlDbContext:DbContext
    {
        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

    }
}
