using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MobileApplication;
using MobileApplication.Models;
using SpCall.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace SpCall.Controllers
{
    public class HomeController : Controller
    {
        private readonly SqlDbContext _dbContext;
        public HomeController(SqlDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index3()
        {

            return View();
        }


        [HttpPost]
        public IActionResult Index3(User entity)
        {
            List<SqlParameter> parms = new List<SqlParameter>
            { 
                new SqlParameter { ParameterName = "@id", Value = entity.id },
                new SqlParameter { ParameterName = "@Name", Value = entity.UserName }
            };

            _dbContext.Database.ExecuteSqlRaw("EXEC SQLAuth.dbo.uspUserUpdate @id, @Name", parms);
            return View();
        }

        public IActionResult Index2()
        {
            return View(GetUserRoles("asif001"));
        }

        public List<UserRole> GetUserRoles(string username)
        {
            List<UserRole> lstUserRole = new List<UserRole>();
            DbDataReader dr;
            SqlParameter usernameParam1 = new SqlParameter("@user", username ?? (object)DBNull.Value);
            var data = _dbContext.Database.GetDbConnection().CreateCommand();
            data.Parameters.Add(usernameParam1);
            //data.Parameters.Add("@userName", userName);
            data.CommandText = "Exec SQLAuth.dbo.getUserRoles @user";
            _dbContext.Database.OpenConnection();
            dr = data.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {
                UserRole objUserRole = new UserRole();
                objUserRole.User = dr[0].ToString();
                objUserRole.Role = dr[1].ToString();
                lstUserRole.Add(objUserRole);
            }
            return lstUserRole;
        }


        public IActionResult Index1()
        {
            ViewBag.User = GetUser("asif001").UserName;
            return View();
        }

        public User GetUser(string username)
        {
            SqlParameter usernameParam = new SqlParameter("@username", username ?? (object)DBNull.Value);
            return _dbContext.Users.FromSqlRaw("EXEC [dbo].[getUserByUserName] @username", usernameParam).AsEnumerable().FirstOrDefault();
        }
    }
}
