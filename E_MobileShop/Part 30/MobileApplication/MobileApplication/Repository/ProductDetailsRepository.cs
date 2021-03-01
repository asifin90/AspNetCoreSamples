using MobileApplication.Contracts;
using MobileApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileApplication.Repository
{
    public class ProductDetailsRepository : IProductDetailsRepo
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

        public List<ProductDetailsVM> FindAllProductByCart(int cartId)
        {
            List<ProductDetailsVM> listProductDetailsVM = new List<ProductDetailsVM>();
            var data =  (from prod in _dbContext.productDetails
                 join cartprod in _dbContext.CartProductsDetails on prod.Id equals cartprod.productId
                 join brand in _dbContext.Brand on prod.BrandId equals brand.Id
                 let BrandName = brand.Name
                 where cartprod.CartId == cartId
                 select new { prod.Battery, prod.BrandId, prod.DisplaySize, prod.Id, prod.Image, prod.isBluetoothSupport,
                    prod.isWIFISupport, prod.Name, prod.OperatingSystem, prod.Price, prod.Processor, prod.SimDetails, prod.weight,
                    BrandName,
                    cartprod.quantity
                 }).ToList();

            foreach (var item in data)
            {
                ProductDetailsVM objProductDetailsVM = new ProductDetailsVM()
                {
                    Battery = item.Battery,                    
                    BrandName = item.BrandName,
                    DisplaySize = item.DisplaySize,
                    Id = item.Id,
                    ImagePath = item.Image,
                    isBluetoothSupport = item.isBluetoothSupport,
                    isWIFISupport = item.isWIFISupport,
                    Name = item.Name,
                    OperatingSystem = item.OperatingSystem,
                    price = item.Price,
                    Quantity = item.quantity,
                };
                listProductDetailsVM.Add(objProductDetailsVM);
            }
            return listProductDetailsVM;
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

    public interface IProductDetailsRepo : IRepositoryCRUD<ProductDetails>
    {
        public List<ProductDetailsVM> FindAllProductByCart(int cartId);
    }
}
