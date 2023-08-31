using CoreAuthentication.Data;
using CoreAuthentication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using CoreAuthentication.Interface;

namespace CoreAuthentication.Repository
{
    public class ProductRepository : IProduct
    {
        private readonly BirlaContext context;
        public ProductRepository(BirlaContext context)
        {
            this.context = context;
        }

        public async Task<Product> CreateAsync(Product productDto)
        {
            var product = new Product
            {
                Category = productDto.Category,
                Description = productDto.Description,
                Name = productDto.Name,
                Price = productDto.Price,
                Quantity = productDto.Quantity
            };

            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();

            return product;
            
        }

        public async Task<Product?> DeleteAsync(int Id)
        {
            var deleteProduct = await context.Products.FirstOrDefaultAsync(x => x.Id == Id);

            if (deleteProduct == null)
            {
                return null;
            }

            context.Products.Remove(deleteProduct);
            await context.SaveChangesAsync();

            return deleteProduct;
        }

        public async Task<List<Product>> GetAllProductAsync()
        {
            return await context.Products.ToListAsync();
        }

        public async Task<Product?> UpdateAsync(int id, Product product)
        {
            var updateProduct = await context.Products.FirstOrDefaultAsync(x => x.Id == id);

            if(updateProduct == null)
            {
                return null;
            }

            updateProduct.Category = product.Category;
            updateProduct.Name = product.Name;
            updateProduct.Description = product.Description;
            updateProduct.Quantity = product.Quantity;
            updateProduct.Price = product.Price;
            
            await context.SaveChangesAsync();

            return updateProduct;
        }
    }
}

