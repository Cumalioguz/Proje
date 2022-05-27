using DataAccess.Abstract;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrate.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product { ProductId = 1, ProductName ="Kalem",UnitPrice=5,CategoryId=1,UnitsInStock=2},
                new Product { ProductId = 2, ProductName ="Silgi",UnitPrice=10,CategoryId=1,UnitsInStock=6},
                new Product { ProductId = 3, ProductName ="Cetvel",UnitPrice=4,CategoryId=2,UnitsInStock=5},
                new Product { ProductId = 4, ProductName ="Kağıt",UnitPrice=50,CategoryId=2,UnitsInStock=7},
                new Product { ProductId = 5, ProductName ="Defter",UnitPrice=7,CategoryId=2,UnitsInStock=6},
            }
                ;
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product deletedProduct = null;

            
            deletedProduct = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            _products.Remove(deletedProduct);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            return _products; 
        }

        public List<Product> GetAllByCategoryId(int categoryId)
        {
           return _products.Where(p => p.CategoryId==categoryId ).ToList();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            return Get(filter);
        }

        public void Update(Product product)
        {
            Product updatedProduct = null;
            updatedProduct = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            updatedProduct.ProductId=product.ProductId;
            updatedProduct.UnitPrice=product.UnitPrice;
            updatedProduct.CategoryId=product.CategoryId;
            updatedProduct.UnitsInStock=product.UnitsInStock;
        }
    }
}
