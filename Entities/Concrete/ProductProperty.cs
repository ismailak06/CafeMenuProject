using Core.Entities;
using System;

namespace Entities.Concrete
{
    public class ProductProperty : IEntity
    {
        public int Id { get; set; }
        private int _productId;
        public int ProductId
        {
            get => _productId;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("ProductId cannot be less than zero.");
                }
                _productId = value;
            }
        }
        private int _propertyId;
        public int PropertyId
        {
            get => _propertyId;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("PropertyId cannot be less than zero.");
                }
                _propertyId = value;
            }
        }

        public Product Product { get; set; }
        public Property Property { get; set; }

    }
}
