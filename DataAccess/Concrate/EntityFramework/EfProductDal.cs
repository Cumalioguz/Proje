using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrate;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrate.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<ProdutDetailDto> GetProdutDetails()
        {
            using (NorthwindContext northwindContext = new NorthwindContext()) 
            {
                var result = from p in northwindContext.products
                             join
                                c in northwindContext.categories
                                on p.CategoryId equals c.CategoryId
                             select new ProdutDetailDto
                             {
                                 ProductId = p.ProductId,
                                 ProductName = p.ProductName,
                                 CategoryName = c.CategoryName,
                                 UnitsInStock = p.UnitsInStock
                             };
                return result.ToList();

            }
            
        }
    }
}
