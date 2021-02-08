using RentNow.Application.DTOs.Jwt;
using RentNow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RentNow.Application.Interfaces
{
    public interface ITokenGenerator
    {
        Task<JsonWebToken> GenerateToken(User user);
    }
}
