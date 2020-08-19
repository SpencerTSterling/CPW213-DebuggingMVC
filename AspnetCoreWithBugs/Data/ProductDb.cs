using AspnetCoreWithBugs.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetCoreWithBugs.Data
{
    public static class ProductDb
    {
        /// <summary>
        /// Gets all the products from the database and returns a list
        /// </summary>
        /// <param name="_context"></param>
        /// <returns></returns>
        public async static Task<List<Product>> ListProductsAysnc(ProductContext _context)
        {
            return await
                (from p in _context.Product
                 orderby p.Name ascending
                 select p).ToListAsync();
        }

    }
}
