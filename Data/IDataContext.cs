using Microsoft.EntityFrameworkCore;
using ShopBridgeApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ShopBridgeApi.Data
{
    public interface IDataContext
    {

        DbSet<Product> Products { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
