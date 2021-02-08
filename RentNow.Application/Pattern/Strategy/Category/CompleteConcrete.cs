using RentNow.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentNow.Application.Pattern.Strategy.Category
{
    public class CompleteConcrete : ICategoryHandler
    {
        public decimal Calculate(decimal price)
        {
            var percents = price * 0.5M;
            return price + percents;
        }
    }
}
