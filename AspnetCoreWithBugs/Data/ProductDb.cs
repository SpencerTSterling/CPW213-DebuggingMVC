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
        public async static Task<List<Product>> ListProductsAsync(ProductContext _context)
        {
            return await
                (from p in _context.Product
                 orderby p.Name ascending
                 select p).ToListAsync();
        }

        /// <summary>
        /// Adds product to the database and saves it
        /// </summary>
        /// <param name="_context"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public async static Task<Product> CreateProductAsync(ProductContext _context, Product p)
        {
            _context.Product.Add(p);
            await _context.SaveChangesAsync();
            return p;
        }

        /// <summary>
        /// Edits/Updates a product inside the database and returns the new product
        /// </summary>
        /// <param name="_context"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public async static Task<Product> EditProductAsync(ProductContext _context, Product p)
        {
            _context.Entry(p).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return p;
        }

        /// <summary>
        /// Deelets a product from the database
        /// </summary>
        /// <param name="_context"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public async static Task<Product> DeleteProductAsync(ProductContext _context, Product p)
        {
            _context.Entry(p).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return p;
        }

        /// <summary>
        /// Finds a product with given id and returns it
        /// </summary>
        /// <param name="_context"></param>
        /// <param name="id">ProductId of desired product</param>
        /// <returns></returns>
        public async static Task<Product> SelectProductAsync(ProductContext _context, int id)
        {
            Product p =
                await (from prod in _context.Product
                where prod.ProductId == id
                select prod).SingleAsync();

            return p;
        }
    }
}
