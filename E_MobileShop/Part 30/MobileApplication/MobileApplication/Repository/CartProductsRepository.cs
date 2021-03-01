using MobileApplication.Contracts;
using MobileApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileApplication.Repository
{
    public class CartProductsRepository : ICartProductsRepository
    {

        MobileDbContext _dbContext;
        public CartProductsRepository(MobileDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<CartProducts> FindAll()
        {
            return _dbContext.CartProductsDetails.ToList();
        }
        public List<CartProducts> FindProductByCart(int cartId)
        {
            return _dbContext.CartProductsDetails.Where(p => p.CartId == cartId).ToList();
        }

        public CartProducts FindById(int id)
        {
            return _dbContext.CartProductsDetails.FirstOrDefault(p => p.CartId == id);
        }
        public CartProducts FindById(int cartId, int productId)
        {
            return _dbContext.CartProductsDetails.FirstOrDefault(p => p.CartId == cartId && p.productId == productId);
        }

        public bool Create(CartProducts entity)
        {
            _dbContext.Add(entity);
            return Save();
        }
        public bool Update(CartProducts entity)
        {
            _dbContext.Update(entity);
            return Save();
        }

        public bool Delete(CartProducts entity)
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

    public interface ICartProductsRepository : IRepositoryCRUD<CartProducts>
    {
        public CartProducts FindById(int cartId, int productId);

        public List<CartProducts> FindProductByCart(int cartId);
    }
}
