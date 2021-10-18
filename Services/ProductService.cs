using Microsoft.EntityFrameworkCore;
using ShopBridgeApi.Data;
using ShopBridgeApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ShopBridgeApi.Services
{
    public class ProductService:IProductService
    {
        private readonly IDataContext _context;

        public ProductService(IDataContext context)
        {
            _context = context;
        }
        public async Task Add(Product product)
        {
            _context.Products.Add(product);

            var existingUserCount = _context.Products.Count(x => x.Name == product.Name);
            if (existingUserCount == 0)
            {
                await _context.SaveChangesAsync();
            }
          

        }

        public async Task Delete(int id)
        {
            var itemToDelete = await _context.Products.FindAsync(id);
            if (itemToDelete == null)
            {
                throw new NullReferenceException();
            }
            _context.Products.Remove(itemToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<Product> Get(int id)
        {
            return await _context.Products.FindAsync(id);

        }
        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<int> GetProdCountByName(string name)
        {
            var existingProductCount =  _context.Products.Count(x => x.Name == name);
            return existingProductCount;
        }

        public async Task Update(int id, Product product)
        {
            var itemToUpdate = await _context.Products.FindAsync(id);
            if (itemToUpdate == null)
            {
                throw new NullReferenceException();
            }
            itemToUpdate.Name = product.Name;
            itemToUpdate.Price = product.Price;
            await _context.SaveChangesAsync();
        }

    }
}
