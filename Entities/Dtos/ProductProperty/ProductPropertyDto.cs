using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.ProductProperty
{
    public class ProductPropertyDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int PropertyId { get; set; }
    }
}
