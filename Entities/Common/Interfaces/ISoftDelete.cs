﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Common.Interfaces
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; }
        DateTime? DeletionDate { get; }
        void SoftDelete();
    }
}
