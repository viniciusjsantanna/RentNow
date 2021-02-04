using System;
using System.Collections.Generic;
using System.Text;

namespace RentNow.Domain.ValueObjects
{
    public class Address
    {
        public string Street { get; private set; }
        public string Postcode { get; private set; }
        public string Number { get; private set; }
        public string Complement { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }

        public override bool Equals(object obj)
        {
            return obj is Address address &&
                   Street == address.Street &&
                   Postcode == address.Postcode &&
                   Number == address.Number &&
                   Complement == address.Complement &&
                   City == address.City &&
                   State == address.State;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
