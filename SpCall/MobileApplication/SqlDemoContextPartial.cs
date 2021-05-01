using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MobileApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileApplication
{
    public partial class SqlDbContext : DbContext
    {
        
        public User GetUser(string username)
        {
            SqlParameter usernameParam = new SqlParameter("@username", username ?? (object)DBNull.Value);
            return Users.FromSqlRaw("EXEC [dbo].[getUserByUserName] @username", usernameParam).AsEnumerable().FirstOrDefault();
        }
    }
}
