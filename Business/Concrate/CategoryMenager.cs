using Business.Abstract;
using Core.Utilities.Results;
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
        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult< List < Category >>(_categoryDal.GetAll());
        }

        public IDataResult< Category> Get(int categoryId)
        {
           return new SuccessDataResult<Category>(_categoryDal.Get(c=>c.CategoryId==categoryId));
        }
       
    }
}
