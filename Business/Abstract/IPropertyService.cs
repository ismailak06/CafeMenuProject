using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos.Property;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IPropertyService
    {
        IDataResult<Property> Create(AddPropertyDto addPropertyDto);
        IDataResult<Property> Update(EditPropertyDto updatePropertyDto);
        IDataResult<Property> Delete(int propertyId);
        IList<PropertyDto> GetList();
        Property GetById(int propertyId);

    }
}
