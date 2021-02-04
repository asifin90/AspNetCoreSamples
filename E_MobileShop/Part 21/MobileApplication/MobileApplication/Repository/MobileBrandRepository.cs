using Microsoft.Data.SqlClient;
using MobileApplication.Contracts;
using MobileApplication.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MobileApplication.Repository
{
    public class MobileBrandRepository : IMobileBrands
    {
        MobileDbContext _dbContext; 
        public MobileBrandRepository(MobileDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<MobileBrand> FindAll()
        {
            return _dbContext.Brand.ToList();
        }

        public MobileBrand FindById(int id)
        {
            return _dbContext.Brand.FirstOrDefault(p => p.Id == id);
        }

        public bool Create(MobileBrand entity)
        {
            _dbContext.Add(entity);
            return Save();
        }
        public bool Update(MobileBrand entity)
        {
            _dbContext.Update(entity);
            return Save();
        }

        public bool Delete(MobileBrand entity)
        {
            _dbContext.Remove(entity);
            return Save();
        }

        public bool Save()
        {
            _dbContext.SaveChanges();
            return true;
        }       
    }
}
