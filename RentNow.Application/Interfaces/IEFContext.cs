using Microsoft.EntityFrameworkCore;
using RentNow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RentNow.Application.Interfaces
{
    public interface IEFContext
    {
        DbSet<Brand> Brand { get; set; }
        DbSet<CarModel> CarModel { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
