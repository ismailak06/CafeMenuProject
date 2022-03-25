using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos.Product;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<Product> Create(AddProductDto addProductDto);
        IDataResult<Product> Update(EditProductDto updateCategoryDto);
        IDataResult<Product> Delete(int productId);
        IDataResult<List<ProductDto>> GetListWithProperties();
        IDataResult<Product> GetById(int productId);
    }
}
