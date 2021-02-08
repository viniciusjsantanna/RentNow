using AutoMapper;
using MediatR;
using RentNow.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace RentNow.Application.CQRS.Users.Commands
{
    public class AuthenticateHandler : IRequestHandler<AuthenticateCommand, IResponse>
    {
        private readonly IResponse response;
        private readonly IMapper mapper;
        private readonly ILoginContext loginContext;

        public AuthenticateHandler(IResponse response, IMapper mapper, ILoginContext loginContext)
        {
            this.response = response;
            this.mapper = mapper;
            this.loginContext = loginContext;
        }

        //private readonly ITokenGenerator tokenGenerator;



        public async Task<IResponse> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
        {
            var userLogged = await loginContext.AuthenticateAsync(request.Login, request.Password, request.Role.ToString());
            //var jwt = await tokenGenerator.GenerateToken(userLogged);

            return await response.Generate(collections:"");
        }
    }
}
