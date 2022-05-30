using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrate
{
    public class ProductMenager : IProductService
    {
        IProductDal _productDal;
        public ProductMenager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            if (product.ProductName.Length< 2)
            {
                return new ErrorResult(Messages.ProductNameInvalied);
            } 
           _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Product>>GetAll()
        {
            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenaceTime);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductListed);
        }

        public IDataResult<List<Product>> GetByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.CategoryId == id));
        }

        public IDataResult<Product>GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p=>p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.UnitPrice>=min&&p.UnitPrice<=max));
        }

        public IDataResult<List<ProdutDetailDto>> GetProdutDetails()
        {
            if (DateTime.Now.Hour ==3)
            {
                return new ErrorDataResult<List<ProdutDetailDto>>(Messages.MaintenaceTime);
            }
            
            return new SuccessDataResult<List<ProdutDetailDto>>(_productDal.GetProdutDetails());
        }
    }
}
