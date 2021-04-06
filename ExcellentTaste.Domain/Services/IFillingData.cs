using System;
using System.Collections.Generic;
using System.Text;

namespace ExcellentTaste.Domain.Services
{
    interface IFillingData
    {
        IEnumerable<Filling> GetAll();
        Filling Get(int fillingId);
    }
}
