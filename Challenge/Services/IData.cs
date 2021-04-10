﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Challenge.Services
{
    public interface IData<T>
    {
        Task<IEnumerable<T>> GetElephantsAsync(bool forceRefresh = false);

    }
}
