using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Common
{
    public abstract class AuditableEntity : Entity<int>
    {
        public DateTime CreationDate { get; set; }
        public int? CreatorUserId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedUserId { get; set; }
    }
}
