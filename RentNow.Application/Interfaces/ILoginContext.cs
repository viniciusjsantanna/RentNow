using RentNow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RentNow.Application.Interfaces
{
    public interface ILoginContext
    {
        Task<User> AuthenticateAsync(string login, string password, string role);
    }
}
