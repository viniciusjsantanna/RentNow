using RentNow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RentNow.Application.Interfaces
{
    public interface ILoginHandler
    {
        Task<User> Authenticate(string login, string password);
    }
}
