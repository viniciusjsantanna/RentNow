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
    }
}
