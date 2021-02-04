using MediatR;
using Moq;
using RentNow.Application.CQRS.CarBrands.Commands.Register;
using RentNow.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace RentNow.Qa.Tests.CarBrand
{
    public class CarBrandTest
    {
        [Theory]
        [InlineData("BMW")]
        public async void RegisterTest_Success(string brandName)
        {
            
        }



    }
}
