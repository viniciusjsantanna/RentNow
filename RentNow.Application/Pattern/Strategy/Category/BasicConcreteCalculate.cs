using RentNow.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentNow.Application.Pattern.Strategy.Category
{
    public class BasicConcreteCalculate : ICategoryCalculate
    {
        public decimal Calculate(decimal price)
        {
            return price;
        }
    }
}
