using Microsoft.EntityFrameworkCore;
using ShopBridgeApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridgeApi.Data
{
    public class DataContext:DbContext, IDataContext
    {
    
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

    }
}
