using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace RentNow.Domain.Enum
{
    public enum FuelType
    {
        [Description("Gasolina")]
        Gas = 1,
        [Description("Etanol")]
        Ethanol = 2,
        [Description("Diesel")]
        Diesel = 3
    }
}
