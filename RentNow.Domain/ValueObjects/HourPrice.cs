using System;
using System.Collections.Generic;
using System.Text;

namespace RentNow.Domain.ValueObjects
{
    public class HourPrice
    {
        public HourPrice()
        {
        }

        public HourPrice(decimal hourPrice)
        {
            this.hourPrice = hourPrice;
        }

        public decimal hourPrice { get; private set; }

        public override bool Equals(object obj)
        {
            return obj is HourPrice price &&
                   hourPrice == price.hourPrice;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(hourPrice);
        }

        public static implicit operator HourPrice(decimal hourPrice)
            => new HourPrice(hourPrice);

        public string ToString(string format)
        {
            if (!string.IsNullOrEmpty(format))
            {
                return hourPrice.ToString(format);
            }
            return hourPrice.ToString();
        }

        public decimal ToDecimal()
        {
            return hourPrice;
        }
    }
}
