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
             ProductTest();
            //CategoryTest();
        }

        private static void CategoryTest()
        {
            CategoryMenager categoryMenager = new CategoryMenager(new EfCategoryDal());
            foreach (var c in categoryMenager.GetAll().Data)
            {
                Console.WriteLine(c.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductMenager productMenager = new ProductMenager(new EfProductDal(), new CategoryMenager(new EfCategoryDal()));
            var result = productMenager.GetProdutDetails();
           
            
            if (result.Success==true)
            {
                foreach (var p in result.Data)
                {
                    Console.WriteLine(p.ProductName + "-->" + p.CategoryName);
                }
            }
            else
            {
                Console.WriteLine(result.Message );
            }
            
        }
    }
}
