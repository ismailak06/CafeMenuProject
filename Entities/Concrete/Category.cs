using Core.Entities;
using Entities.Common;
using Entities.Common.Interfaces;
using System;

namespace Entities.Concrete
{
    public class Category : AuditableEntity, IEntity, ISoftDelete
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
        public int? ParentCategoryId { get; set; }
        public bool IsDeleted { get; private set; }
        public DateTime? DeletionDate { get; private set; }
        public void SoftDelete()
        {
            IsDeleted = true;
            DeletionDate = DateTime.Now;
        }
    }
}
