using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace RentNow.Domain.Enum
{
    public enum Role
    {
        [Description("Operador")]
        Operator = 1,
        [Description("Cliente")]
        Client = 2
    }
}
