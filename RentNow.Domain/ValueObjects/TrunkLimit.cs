using System;
using System.Collections.Generic;
using System.Text;

namespace RentNow.Domain.ValueObjects
{
    public class TrunkLimit
    {
        public TrunkLimit()
        {
        }

        public TrunkLimit(int trunkLimit)
        {
            this.trunkLimit = trunkLimit;
        }

        public int trunkLimit { get; set; }

        public override bool Equals(object obj)
        {
            return obj is TrunkLimit limit &&
                   trunkLimit == limit.trunkLimit;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(trunkLimit);
        }

        public static implicit operator TrunkLimit(int trunkLimit)
            => new TrunkLimit(trunkLimit);

        public override string ToString()
        {
            return trunkLimit.ToString() + " Litros";
        }
    }
}
