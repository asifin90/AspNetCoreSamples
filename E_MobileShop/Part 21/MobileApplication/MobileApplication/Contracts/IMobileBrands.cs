using MobileApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileApplication.Contracts
{
    public interface IMobileBrands
    {
        List<MobileBrand> FindAll();
        MobileBrand FindById(int id);
        bool Create(MobileBrand entity);
        bool Update(MobileBrand entity);
        bool Delete(MobileBrand entity);
        bool Save();
    }
}
