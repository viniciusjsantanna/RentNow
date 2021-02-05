using System;
using System.Collections.Generic;
using System.Text;

namespace RentNow.Domain.ValueObjects
{
    public class Cpf
    {
        public Cpf()
        {
        }

        public Cpf(string cpf)
        {
            this.cpf = cpf;
        }

        public string cpf { get; private set; }

        public override bool Equals(object obj)
        {
            return obj is Cpf cpf &&
                   this.cpf == cpf.cpf;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(cpf);
        }

        public static implicit operator Cpf(string cpf)
            => new Cpf(cpf);

        public override string ToString()
        {
            var part1 = cpf.Substring(0, 3);
            var part2 = cpf.Substring(3, 3);
            var part3 = cpf.Substring(6, 3);
            var part4 = cpf.Substring(9);

            return part1 + "." + part2 + "." + part3 + "-" + part4;
        }
    }
}
