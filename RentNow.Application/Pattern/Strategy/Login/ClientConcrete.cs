using AutoMapper;
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
    public class ClientConcrete : ILoginHandler
    {
        private readonly IEFContext context;

        public ClientConcrete(IEFContext context)
        {
            this.context = context;
        }

        public Task<User> Authenticate(string login, string password)
        {
            var user = context.Client.Include(e => e.Credentials).Where(e => e.Cpf.cpf.Equals(login)).FirstOrDefaultAsync().Result;
            if(user is null || user.Credentials is null || !user.Credentials.isAuthentic(password))
            {
                return null;
            }
            return Task.FromResult((User)user);
        }
    }
}
