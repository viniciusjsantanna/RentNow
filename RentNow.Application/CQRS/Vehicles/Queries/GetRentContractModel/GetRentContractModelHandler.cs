using MediatR;
using RentNow.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RentNow.Application.CQRS.Vehicles.Queries.GetRentContractModel
{
    public class GetRentContractModelHandler : IRequestHandler<GetRentContractModelQuery, IResponse>
    {
        public Task<IResponse> Handle(GetRentContractModelQuery request, CancellationToken cancellationToken)
        {
            var path = Path.Combine(
                     Directory.GetCurrentDirectory(),
                     "wwwroot", request.FileName);
            throw new NotImplementedException();
        }
    }
}
