﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaltaStore.Domain.StoreContext.Enums
{
    public enum EOrderStatus
    {
        Created = 1,
        Paid = 2,
        Shipped = 3,
        Canceled = 4
    }
}
