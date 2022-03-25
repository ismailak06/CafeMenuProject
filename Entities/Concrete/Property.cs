using Core.Entities;
using Entities.Common;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class Property : IEntity
    {
        public int Id { get; set; }
        private string _key;
        public string Key
        {
            get => _key;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Key cannot be null");
                }
                _key = value;
            }
        }
        private string _value;
        public string Value
        {
            get => _value;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Value cannot be null");
                }
                _value = value;
            }
        }
        public ICollection<ProductProperty> ProductProperties { get; set; }
    }
}
