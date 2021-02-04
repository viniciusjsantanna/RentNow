using System;
using System.Collections.Generic;
using System.Text;

namespace RentNow.Domain.ValueObjects
{
    public class Name
    {
        public Name()
        {
        }

        public Name(string name)
        {
            this.name = name;
        }

        public string name { get; private set; }

        public override bool Equals(object obj)
        {
            return obj is Name name &&
                   this.name == name.name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(name);
        }

        public static implicit operator Name(string name)
            => new Name(name);

        public override string ToString()
        {
            return name.ToString();
        }
    }
}
