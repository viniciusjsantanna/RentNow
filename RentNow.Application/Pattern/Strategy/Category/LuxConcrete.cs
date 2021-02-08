using RentNow.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentNow.Application.Pattern.Strategy.Category
{
    public class LuxConcrete : ICategoryHandler
    {
        public decimal Calculate(decimal price)
        {
            var percents = price * 0.8M;
            return price + percents;
        }
    }
}
