using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace RentNow.Domain.Enum
{
    public enum CategoryType
    {
        [Description("Básico")]
        Basic = 1,
        [Description("Completo")]
        Complet = 2,
        [Description("Luxo")]
        Lux = 3
    }
}
