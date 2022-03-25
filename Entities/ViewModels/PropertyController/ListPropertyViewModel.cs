using Entities.Dtos.Property;
using System.Collections.Generic;

namespace Entities.ViewModels.PropertyController
{
    public class ListPropertyViewModel
    {
        public IList<PropertyDto> PropertiesDtos { get; set; }
    }
}
