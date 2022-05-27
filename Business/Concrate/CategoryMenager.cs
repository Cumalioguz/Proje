using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrate
{
    public class CategoryMenager : ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryMenager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }

        public Category GetAll(int categoryId)
        {
           return _categoryDal.Get(c=>c.CategoryId==categoryId);
        }
    }
}
