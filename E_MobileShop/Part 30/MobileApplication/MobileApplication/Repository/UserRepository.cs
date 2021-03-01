using Microsoft.AspNetCore.Identity;
using MobileApplication.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileApplication.Repository
{
    public class UserRepository: IRepositoryUser
    {
        MobileDbContext _dbContext;
        public UserRepository(MobileDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public IdentityUser FindById(string user)
        {            
            return _dbContext.Users.Where(p => p.UserName == user).FirstOrDefault();
        }

    }

    public interface IRepositoryUser
    {
        IdentityUser FindById(string user);
    }
}
