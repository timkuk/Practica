using Booking.Domain.Entities.CountryAggregate;
using System.Threading.Tasks;

namespace Booking.DAL.Interfaces
{
    public interface ICountryRepository : IRepository<CountryEntity>
    {
        Task UpdateAsync(CountryEntity countryEntity);
    }
}
