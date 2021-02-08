using System;
using System.Collections.Generic;
using System.Text;

namespace RentNow.Application.Interfaces
{
    public interface ICategoryHandler
    {
        decimal Calculate(decimal price); 
    }
}
