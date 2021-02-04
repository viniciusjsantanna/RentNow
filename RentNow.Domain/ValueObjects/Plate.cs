using System;
using System.Collections.Generic;
using System.Text;

namespace RentNow.Domain.ValueObjects
{
    public class Plate
    {
        public Plate()
        {
        }

        public Plate(string plate)
        {
            this.plate = plate;
        }

        public string plate { get; private set; }

        public static implicit operator Plate(string plate)
            => new Plate(plate);

        public override bool Equals(object obj)
        {
            return obj is Plate plate &&
                   this.plate == plate.plate;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(plate);
        }
    }
}
