using MobileApplication.Contracts;
using MobileApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileApplication.Repository
{
    public class CartRepository : ICartRepository
    {
        MobileDbContext _dbContext;
        public CartRepository(MobileDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Cart> FindAll()
        {
            return _dbContext.CartDetails.ToList();
        }

        public Cart FindById(int id)
        {
            return _dbContext.CartDetails.FirstOrDefault(p => p.Id == id);
        }

        public Cart FindCartByUser(string userId)
        {
            return _dbContext.CartDetails.Where(p => p.UserId == userId).FirstOrDefault();
        }

        public Cart FindById(string id)
        {
            return _dbContext.CartDetails.FirstOrDefault(p => p.UserId == id);
        }
        public bool Create(Cart entity)
        {
            _dbContext.Add(entity);
            return Save();
        }
        public bool Update(Cart entity)
        {
            _dbContext.Update(entity);
            return Save();
        }

        public bool Delete(Cart entity)
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

    public interface ICartRepository : IRepositoryCRUD<Cart>
    {
        public Cart FindById(string id);

        public Cart FindCartByUser(string userId);
    }
}
