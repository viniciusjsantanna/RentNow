using RentNow.Application.Interfaces;
using RentNow.Domain.Entities;
using RentNow.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentNow.Application.Pattern.Strategy.Category
{
    public class CategoryContext : ICategoryContext
    {
        private readonly IEnumerable<ICategoryHandler> categories;
        public CategoryContext(IEnumerable<ICategoryHandler> categories)
        {
            this.categories = categories;
        }

        public decimal GetCurrentCategoryCalculate(decimal price, int totalHours, string category)
        {
            var concrete = categories.Where(e => e.GetType().Name.Contains(category)).FirstOrDefault();
            return concrete.Calculate(price * totalHours); 
        }

        public decimal GetCurrentCategoryCalculate(decimal price, string category)
        {
            var concrete = categories.Where(e => e.GetType().Name.Contains(category)).FirstOrDefault();
            return concrete.Calculate(price); 
        }


    }
}
