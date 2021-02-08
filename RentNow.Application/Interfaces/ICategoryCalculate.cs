using System;
using System.Collections.Generic;
using System.Text;

namespace RentNow.Application.Interfaces
{
    public interface ICategoryCalculate
    {
        decimal Calculate(decimal price); 
    }
}
