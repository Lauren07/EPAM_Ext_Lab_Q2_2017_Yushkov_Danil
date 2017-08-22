using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BLL.Models;
using DataAccessLayer;
using DataAccessLayer.Entities;

namespace BLL.Services
{
    public class ProductService
    {
        private DAL database;

        public ProductService()
        {
            this.database = new DAL();
        }

        public IEnumerable<ProductDTO> GetAllProducts()
        {
            var products = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>> (this.database.GetAllProducts());
            return products.Where(prod => prod.UnitsInStock > 0);
        }

        public bool AddProduct(ProductDetailsDTO product)
        {
            var dbProd = Mapper.Map<ProductDetailsDTO, ProductDetails>(product);
            return this.database.AddProductInOrder(dbProd);
        }
    }
}
