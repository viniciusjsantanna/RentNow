using RentNow.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RentNow.Application.DTOs
{
    public class Response : IResponse
    {
        public string message { get; set; }
        public object collections { get; set; }
        public bool hasError { get; set; }

        public Task<IResponse> Generate(string message = null, object collections = null, bool hasError = false)
        {
            this.message = message;
            this.collections = collections;
            this.hasError = hasError;
            return Task.FromResult((IResponse)this);
        }
    }
}
