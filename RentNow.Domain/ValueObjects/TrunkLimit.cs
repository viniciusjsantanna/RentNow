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

        public TrunkLimit(string trunkLimit)
        {
            this.trunkLimit = trunkLimit;
        }

        public string trunkLimit { get; set; }

        public override bool Equals(object obj)
        {
            return obj is TrunkLimit limit &&
                   trunkLimit == limit.trunkLimit;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(trunkLimit);
        }

        public static implicit operator TrunkLimit(string trunkLimit)
            => new TrunkLimit(trunkLimit);
    }
}
