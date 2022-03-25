using Business.Abstract;
using Business.Utilities.AutoMapper;
using Business.ValidationRules.FluentValidation.Entities.ProductProperty;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Product;
using Entities.Dtos.ProductProperty;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductPropertyManager : IProductPropertyService
    {
        private readonly IProductPropertyDal _productPropertyDal;

        public ProductPropertyManager(IProductPropertyDal productPropertyDal)
        {
            _productPropertyDal = productPropertyDal;
        }

        public IDataResult<ProductProperty> Create(AddProductPropertyDto addProductPropertyDto)
        {
            var validator = new AddProductPropertyValidator();
            var validateResult = validator.Validate(addProductPropertyDto);
            if (!validateResult.IsValid)
            {
                var errorResults = ValidationHelper.GetErrors(validateResult.Errors);
                return new ErrorDataResult<ProductProperty>("Ürün özelliği ekleme işlemi başarısız oldu.", errorResults);
            }
            var productProperty = Mapping.Mapper.Map<ProductProperty>(addProductPropertyDto);
            var addedProductProperty = _productPropertyDal.Add(productProperty);

            return new SuccessDataResult<ProductProperty>(addedProductProperty);
        }
        public IDataResult<ProductProperty> Update(EditProductPropertyDto updateProductPropertyDto)
        {
            var validator = new UpdateProductPropertyValidator();
            var validateResult = validator.Validate(updateProductPropertyDto);
            if (!validateResult.IsValid)
            {
                var errorResults = ValidationHelper.GetErrors(validateResult.Errors);
                return new ErrorDataResult<ProductProperty>("Ürün özelliği güncelleme işlemi başarısız oldu.", errorResults);
            }

            var productProperty = _productPropertyDal.GetById(updateProductPropertyDto.Id);
            productProperty.PropertyId = updateProductPropertyDto.PropertyId;
            productProperty.ProductId = updateProductPropertyDto.ProductId;

            var updatedProductProperty = _productPropertyDal.Update(productProperty);
            return new SuccessDataResult<ProductProperty>(updatedProductProperty);
        }

        public IDataResult<ProductProperty> Delete(int productPropertyId)
        {
            var productProperty = _productPropertyDal.GetById(productPropertyId);
            var deletedProductProperty = _productPropertyDal.Delete(productProperty);
            return new SuccessDataResult<ProductProperty>(deletedProductProperty);
        }

        public IDataResult<ProductProperty> UpdateAll(int[] productPropertyIds, int productId)
        {
            if (productPropertyIds == null)
            {
                return new SuccessDataResult<ProductProperty>();
            }
            var productProperties = _productPropertyDal.GetList(m => m.ProductId == productId);
            var removeProductProperties = productProperties.Where(p => !productPropertyIds.Contains(p.PropertyId)).ToList();
            _productPropertyDal.DeleteRange(removeProductProperties);

            for (int i = 0; i <= productPropertyIds.Length - 1; i++)
            {
                var productProperty = new AddProductPropertyDto
                {
                    PropertyId = productPropertyIds[i],
                    ProductId = productId
                };
                Create(productProperty);
            }
            return new SuccessDataResult<ProductProperty>();
        }

        public IList<ProductPropertyDto> GetListByProductId(int productId)
        {
            return Mapping.Mapper.Map<IList<ProductPropertyDto>>(_productPropertyDal.GetList(m => m.ProductId == productId));
        }
    }
}
