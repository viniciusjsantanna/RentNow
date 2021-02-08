using RentNow.Application.Interfaces;
using RentNow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentNow.Application.Pattern.Strategy.Login
{
    public class LoginContext : ILoginContext
    {
        private readonly IEnumerable<ILoginHandler> loginHandlers ;

        public LoginContext(IEnumerable<ILoginHandler> loginHandlers)
        {
            this.loginHandlers = loginHandlers;
        }

        public async Task<User> AuthenticateAsync(string login, string password, string role)
        {
            var concrete = loginHandlers.Where(e => e.GetType().Name.Contains(role)).FirstOrDefault();
            return await concrete.Authenticate(login, password);
        }
    }
}
