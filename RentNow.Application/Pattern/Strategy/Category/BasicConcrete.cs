using RentNow.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentNow.Application.Pattern.Strategy.Category
{
    public class BasicConcrete : ICategoryHandler
    {
        public decimal Calculate(decimal price)
        {
            return price;
        }
    }
}
