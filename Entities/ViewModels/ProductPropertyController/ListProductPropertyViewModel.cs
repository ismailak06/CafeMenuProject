﻿using Entities.Dtos.ProductProperty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels.ProductPropertyController
{
    public class ListProductPropertyViewModel
    {
        public IList<ProductPropertyDto> ProductPropertyDtos { get; set; }
    }
}
