using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos.ProductProperty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductPropertyService
    {
        IDataResult<ProductProperty> Create(AddProductPropertyDto addProductPropertyDto);
        IDataResult<ProductProperty> Update(EditProductPropertyDto updateProductPropertyDto);
        IDataResult<ProductProperty> Delete(int productPropertyId);
        IDataResult<ProductProperty> UpdateAll(int[] productPropertyIds, int productId);
        IList<ProductPropertyDto> GetListByProductId(int productId);
    }
}
