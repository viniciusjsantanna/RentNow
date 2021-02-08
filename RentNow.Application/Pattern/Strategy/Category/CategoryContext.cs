using RentNow.Application.Interfaces;
using RentNow.Domain.Entities;
using RentNow.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentNow.Application.Pattern.Strategy.Category
{
    public class CategoryContext
    {
        private readonly IEnumerable<ICategoryCalculate> categories;
        public CategoryContext(IEnumerable<ICategoryCalculate> categories)
        {
            this.categories = categories;
        }

        public decimal GetCurrentCategoryCalculate(decimal price, int totalHours, string category)
        {
            var concrete = categories.Where(e => e.GetType().Name.Contains(category)).FirstOrDefault();
            var TotalPrice = concrete.Calculate(price * totalHours);
            return TotalPrice;
        }

        public decimal GetCurrentCategoryCalculate(decimal price, string category)
        {
            var concrete = categories.Where(e => e.GetType().Name.Contains(category)).FirstOrDefault();
            var TotalPrice = concrete.Calculate(price);
            return TotalPrice;
        }


    }
}
