using System.Threading.Tasks;
using Booking.Domain.Entities.CountryAggregate;

namespace Booking.DAL.Interfaces
{
    public interface ICityRepository : IRepository<CityEntity>
    {
        Task UpdateAsync(CityEntity entity);
    }
}