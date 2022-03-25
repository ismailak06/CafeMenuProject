using Core.Entities;
using Entities.Common;
using Entities.Common.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class Product : AuditableEntity, IEntity, ISoftDelete
    {
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be null");
                }
                _name = value;
            }
        }
        private int _categoryId;
        public int CategoryId
        {
            get => _categoryId;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("CategoryId cannot be less than zero");
                }
                _categoryId = value;
            }
        }
        private decimal _price;
        public decimal Price
        {
            get => _price;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Price cannot be less than zero");
                }
                _price = value;
            }
        }
        private string _imagePath;
        public string ImagePath
        {
            get => _imagePath;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("ImagePath cannot be null");
                }
                _imagePath = value;
            }
        }

        public ICollection<ProductProperty> ProductProperties { get; set; }

        public bool IsDeleted { get; private set; }

        public DateTime? DeletionDate { get; private set; }
        public void SoftDelete()
        {
            IsDeleted = true;
            DeletionDate = DateTime.Now;
        }
    }
}
