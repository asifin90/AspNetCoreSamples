using MobileApplication.Contracts;
using MobileApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileApplication.Repository
{
    public class ProductDetailsRepository : IRepositoryCRUD<ProductDetails>
    {
        MobileDbContext _dbContext;
        public ProductDetailsRepository(MobileDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<ProductDetails> FindAll()
        {
            return _dbContext.productDetails.ToList();
        }

        public ProductDetails FindById(int id)
        {
            return _dbContext.productDetails.FirstOrDefault(p => p.Id == id);
        }

        public bool Create(ProductDetails entity)
        {
            _dbContext.Add(entity);
            return Save();
        }
        public bool Update(ProductDetails entity)
        {
            _dbContext.Update(entity);
            return Save();
        }

        public bool Delete(ProductDetails entity)
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
