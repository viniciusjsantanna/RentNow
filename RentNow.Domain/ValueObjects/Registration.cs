using System;
using System.Collections.Generic;
using System.Text;

namespace RentNow.Domain.ValueObjects
{
    public class Registration
    {
        public Registration()
        {
        }

        public Registration(string registration)
        {
            this.registration = registration;
        }

        public string registration { get; private set; }

        public override bool Equals(object obj)
        {
            return obj is Registration registration &&
                   this.registration == registration.registration;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(registration);
        }

        public static implicit operator Registration(string registration)
            => new Registration(registration);
    }
}
