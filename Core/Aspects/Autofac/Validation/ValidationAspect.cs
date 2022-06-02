using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        //aspect:methodun başında, ortasında ,hata alırken, sonunda  çalışan yapı
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))//Gönderdiğimiz validatortype bir ivalidator mu onu tespit eder

            {
                throw new System.Exception("Bu bir dogrulama sınıfı değil");
            }
            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);//ivalidator tipinde instance oluşturur validator typı tutar validatortypı  newleme gibi ex:productvalidator
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];//validatortypın base nin generiklerinin 0.teriminin tipini yakala ex : product
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);//methodun argümanlarını gez eğer tipi entitytypla aynıysa alttaki çalışır ex:add methodunun argümanı product entitytypda product ->productu entitiese atar
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
