﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MY_Domain.Entities;

namespace MY_Domain.Abstract
{
    public interface IUsefulLinksRepository
    {
        IQueryable<UsefulLinks> UsefulLinks { get; }
    }
}
