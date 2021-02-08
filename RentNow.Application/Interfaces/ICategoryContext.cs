using System;
using System.Collections.Generic;
using System.Text;

namespace RentNow.Application.Interfaces
{
    public interface ICategoryContext
    {
        decimal GetCurrentCategoryCalculate(decimal price, int totalHours, string category);
        decimal GetCurrentCategoryCalculate(decimal price, string category);
    }
}
