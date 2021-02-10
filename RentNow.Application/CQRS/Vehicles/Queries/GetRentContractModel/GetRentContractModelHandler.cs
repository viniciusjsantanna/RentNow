using MediatR;
using RentNow.Application.DTOs.Vehicle;
using RentNow.Application.Interfaces;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace RentNow.Application.CQRS.Vehicles.Queries.GetRentContractModel
{
    public class GetRentContractModelHandler : IRequestHandler<GetRentContractModelQuery, IResponse>
    {
        private readonly IResponse response;
        public GetRentContractModelHandler(IResponse response)
        {
            this.response = response;
        }

        public Task<IResponse> Handle(GetRentContractModelQuery request, CancellationToken cancellationToken)
        {
            var path = Path.Combine(
                    "C:\\Users\\139988\\Desktop\\RentNow\\RentNow\\RentNow.Application\\RentContract\\", request.FileName);

            var stream = File.OpenRead(path);
            using (MemoryStream ms = new MemoryStream())
            {
                stream.CopyTo(ms);

                var document = new RentContractDTO()
                {
                    Content = ms.ToArray(),
                    FileName = Path.GetFileName(stream.Name),
                };

                return response.Generate(collections: document);
            }
        }
    }
}
