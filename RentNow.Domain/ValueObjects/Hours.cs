using System;
using System.Collections.Generic;
using System.Text;

namespace RentNow.Domain.ValueObjects
{
    public class Hours
    {
        public Hours()
        {
        }

        public Hours(int hours)
        {
            this.hours = hours;
        }

        public int hours { get; private set; }

        public override bool Equals(object obj)
        {
            return obj is Hours hours &&
                   this.hours == hours.hours;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(hours);
        }

        public int ToInt()
        {
            return hours;
        }

        public static implicit operator Hours(int hours)
            => new Hours(hours);

    }
}
