using System;
using System.Collections.Generic;
using System.Text;

namespace RentNow.Domain.ValueObjects
{
    public class Year
    {
        public Year()
        {
        }

        public Year(int year)
        {
            this.year = year;
        }

        public int year { get; private set; }

        public override bool Equals(object obj)
        {
            return obj is Year year &&
                   this.year == year.year;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(year);
        }

        public static implicit operator Year(int year)
            => new Year(year);
    }
}
