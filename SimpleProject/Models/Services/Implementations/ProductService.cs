﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleProject.Data;
using SimpleProject.Models.Services.Interfaces;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;

namespace SimpleProject.Models.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly AppDBContext _context;
        private readonly IFileService _fileService;

        public ProductService(AppDBContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }
        #region Fields

        #endregion
        #region Consturctor
        public ProductService(IFileService fileService)

        {
            _fileService = fileService;



        }
        #endregion
        public async Task<string> AddProduct(Product product)
        {
            try
            {


                await _context.Product.AddAsync(product);
                await _context.SaveChangesAsync();
                return "success";
            }
            catch (Exception ex)
            {
                return ex.Message + "--" + ex.InnerException;



            }
        }

        public async Task<string> DeleteProduct(Product product)
        {
            try
            {

                _fileService.deleteFile(product.Path);
                _context.Product.Remove(product);
                await _context.SaveChangesAsync();
                return "success";

            }
            catch (Exception ex)
            {
                return ex.Message + "--" + ex.InnerException;
            }





        }

        public async Task<Product?> GetProductById(int id)
        {


            return await _context.Product.FindAsync(id);
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _context?.Product?.ToListAsync();
        }

        public async Task<bool> IsProductNameExist(string name)
        {
            return await _context.Product.AnyAsync(x => x.Name == name);


        }

        public async Task<string> UpdateProduct(Product product)
        {

            try
            {
                var model = await this.GetProductById(product.Id);
                if (model != null)
                {
                    model.Name = product.Name;
                    model.Price = product.Price;
                    model.File = product.File;
                    model.Path = product.Path;
                    _context.Product.Update(model);
                    await _context.SaveChangesAsync();
                    return "success";

                }
                return "Failed";

            }
            catch (Exception ex)
            {
                return ex.Message + "--" + ex.InnerException;
            }





        }



    }
}

