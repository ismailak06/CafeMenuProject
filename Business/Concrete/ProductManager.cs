using Business.Abstract;
using Business.Utilities.AutoMapper;
using Business.ValidationRules.FluentValidation.Entities.Product;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Product;
using Entities.Dtos.ProductProperty;
using Entities.Dtos.Property;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        private readonly IProductPropertyService _productPropertyService;
        private const string USD = "USD";
        private const string EURO = "EUR";
        public ProductManager(IProductDal productDal, IProductPropertyService productPropertyService)
        {
            _productDal = productDal;
            _productPropertyService = productPropertyService;
        }

        public IDataResult<Product> Create(AddProductDto addProductDto)
        {
            var validator = new AddProductValidator();
            var validateResult = validator.Validate(addProductDto);
            if (!validateResult.IsValid)
            {
                var errorResults = ValidationHelper.GetErrors(validateResult.Errors);
                return new ErrorDataResult<Product>("Yeni ürün ekleme işlemi başarısız oldu.", errorResults);
            }
            var product = Mapping.Mapper.Map<Product>(addProductDto);
            var addedProdcut = _productDal.Add(product);


            return new SuccessDataResult<Product>(addedProdcut);
        }

        public IDataResult<Product> Delete(int productId)
        {
            var product = _productDal.GetById(productId);
            var deletedProduct = _productDal.Delete(product);

            return new SuccessDataResult<Product>(deletedProduct);
        }

        public IDataResult<Product> Update(EditProductDto updateCategoryDto)
        {
            var validator = new UpdateProductValidator();
            var validateResult = validator.Validate(updateCategoryDto);
            if (!validateResult.IsValid)
            {
                var errorResults = ValidationHelper.GetErrors(validateResult.Errors);
                return new ErrorDataResult<Product>("Ürün güncelleme işlemi başarısız oldu.", errorResults);
            }

            var product = _productDal.GetById(updateCategoryDto.Id);
            product.Name = updateCategoryDto.Name;
            product.Price = updateCategoryDto.Price;
            product.CategoryId = updateCategoryDto.CategoryId;

            var updatedProduct = _productDal.Update(product);

            //var editProductProperty = _productPropertyService.
            //_productPropertyService.Update(editProductProperty);

            return new SuccessDataResult<Product>(updatedProduct);
        }

        static string GetCurrency(string currencyName)
        {
            string exchangeRate = "http://www.tcmb.gov.tr/kurlar/today.xml";
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(exchangeRate);
            string currency = "";
            switch (currencyName)
            {
                case "USD":
                    currency = xmlDoc.SelectSingleNode("//Currency[CurrencyName='US DOLLAR']").SelectSingleNode("BanknoteSelling").InnerXml;
                    break;
                case "EUR":
                    currency = xmlDoc.SelectSingleNode("//Currency[CurrencyName='EURO']").SelectSingleNode("BanknoteSelling").InnerXml;
                    break;
            }
            return currency.Replace(".", ",");
        }
        public IDataResult<List<ProductDto>> GetListWithProperties()
        {
            var productList = _productDal.GetQueryableList.Where(m => !m.IsDeleted)
                .Include(m => m.ProductProperties)
                .ThenInclude(m => m.Property).ToList();

            var mappedProductList = Mapping.Mapper.Map<List<ProductDto>>(productList)
                .Select(m => new ProductDto
                {
                    CategoryId = m.CategoryId,
                    Name = m.Name,
                    Price = m.Price,
                    Id = m.Id,
                    ImagePath = m.ImagePath,
                    PriceUsd = Math.Round(m.Price / decimal.Parse(GetCurrency(USD)), 2),
                    PriceEuro = Math.Round(m.Price / decimal.Parse(GetCurrency(EURO)), 2),
                    Properties = Mapping.Mapper.Map<List<PropertyDto>>(productList.SelectMany(m => m.ProductProperties.Select(m => m.Property)).ToList())
                }).ToList();

            return new SuccessDataResult<List<ProductDto>>(mappedProductList);
        }

        public IDataResult<Product> GetById(int productId)
        {
            var product = _productDal.GetById(productId);
            return new SuccessDataResult<Product>(product);
        }
    }
}
