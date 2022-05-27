using Business.Concrate;
using DataAccess.Concrate.EntityFramework;
using DataAccess.Concrate.InMemory;
using System;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ProductTest();
            CategoryMenager categoryMenager = new CategoryMenager(new EfCategoryDal());
            foreach (var c in categoryMenager.GetAll())
            {
                Console.WriteLine(c.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductMenager productMenager = new ProductMenager(new EfProductDal());

            foreach (var p in productMenager.GetByUnitPrice(50, 100))
            {
                Console.WriteLine(p.ProductName);
            }
        }
    }
}
