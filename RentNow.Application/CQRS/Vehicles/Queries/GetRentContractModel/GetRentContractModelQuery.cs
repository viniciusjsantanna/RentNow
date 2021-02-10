using MediatR;
using RentNow.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RentNow.Application.CQRS.Vehicles.Queries.GetRentContractModel
{
    public class GetRentContractModelQuery : IRequest<IResponse>
    {
        public GetRentContractModelQuery(string fileName)
        {
            FileName = fileName;
        }

        public string FileName { get; set; }
    }
}
