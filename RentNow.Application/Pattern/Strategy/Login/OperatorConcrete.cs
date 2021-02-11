using Microsoft.EntityFrameworkCore;
using RentNow.Application.Interfaces;
using RentNow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentNow.Application.Pattern.Strategy.Login
{
    public class OperatorConcrete : ILoginHandler
    {
        private readonly IEFContext context;

        public OperatorConcrete(IEFContext context)
        {
            this.context = context;
        }

        public Task<User> Authenticate(string login, string password)
        {
            var user = context.Operator.Include(e => e.Credentials).Where(e => e.Registration.registration.Equals(login)).FirstOrDefaultAsync().Result;
            if (user is null || user.Credentials is null || !user.Credentials.isAuthentic(password))
            {
                return null;
            }
            return Task.FromResult((User)user);
        }
    }
}
