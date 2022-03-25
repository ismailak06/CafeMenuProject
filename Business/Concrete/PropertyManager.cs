using Business.Abstract;
using Business.Utilities.AutoMapper;
using Business.ValidationRules.FluentValidation.Entities.Property;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PropertyManager : IPropertyService
    {
        private readonly IPropertyDal _propertyDal;

        public PropertyManager(IPropertyDal propertyDal)
        {
            _propertyDal = propertyDal;
        }

        public IDataResult<Property> Create(AddPropertyDto addPropertyDto)
        {
            var validator = new AddPropertyValidator();
            var validateResult = validator.Validate(addPropertyDto);
            if (!validateResult.IsValid)
            {
                var errorResults = ValidationHelper.GetErrors(validateResult.Errors);
                return new ErrorDataResult<Property>("Yeni özellik ekleme işlemi başarısız oldu.", errorResults);
            }
            var property = Mapping.Mapper.Map<Property>(addPropertyDto);
            var addedProperty = _propertyDal.Add(property);

            return new SuccessDataResult<Property>(addedProperty);
        }
        public IDataResult<Property> Update(EditPropertyDto updatePropertyDto)
        {
            var validator = new UpdatePropertyValidator();
            var validateResult = validator.Validate(updatePropertyDto);
            if (!validateResult.IsValid)
            {
                var errorResults = ValidationHelper.GetErrors(validateResult.Errors);
                return new ErrorDataResult<Property>("Özellik güncelleme işlemi başarısız oldu.", errorResults);
            }

            var property = _propertyDal.GetById(updatePropertyDto.Id);
            property.Key = updatePropertyDto.Key;
            property.Value = updatePropertyDto.Value;

            var updatedProperty = _propertyDal.Update(property);
            return new SuccessDataResult<Property>(updatedProperty);
        }

        public IDataResult<Property> Delete(int propertyId)
        {
            var property = _propertyDal.GetById(propertyId);
            var deletedProperty = _propertyDal.Delete(property);
            return new SuccessDataResult<Property>(deletedProperty);
        }

        public IList<PropertyDto> GetList()
        {
            return Mapping.Mapper.Map<List<PropertyDto>>(_propertyDal.GetList());
        }

        public Property GetById(int propertyId)
        {
            return _propertyDal.GetById(propertyId);
        }
    }
}
