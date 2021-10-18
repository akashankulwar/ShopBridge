using ShopBridgeApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridgeApi.Services
{
    public interface IProductService
    {

        Task<Product> Get(int id);

        Task<int> GetProdCountByName(string Name);

        Task<IEnumerable<Product>> GetAll();

        Task Add(Product product);

        Task Update(int id, Product product);

        Task Delete(int id);



    }
}
