using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RentNow.Application.Interfaces
{
    public interface IResponse
    {
        bool hasError { get; set; }
        string message { get; set; }
        Task<IResponse> Generate(string message = default, object collections = default, bool hasError = default);
    }
}
