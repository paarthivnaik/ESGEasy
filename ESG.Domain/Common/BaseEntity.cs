﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Domain.Common
{
    public  abstract class BaseEntity<T>
    {
        public virtual T Id { get; set; }
    }
}
