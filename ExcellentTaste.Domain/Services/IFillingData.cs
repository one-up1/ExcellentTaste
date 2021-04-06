﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ExcellentTaste.Domain.Services
{
    public interface IFillingData
    {
        IEnumerable<Filling> GetAll();
        Filling Get(int fillingId);
    }
}