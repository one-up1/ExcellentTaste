﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ExcellentTaste.Domain.Services
{
    public interface IBtwTypeData
    {
        IEnumerable<BtwType> GetAll();
        BtwType Get(int btwTypeId);
    }
}