using Booking.DAL.Interfaces;
using Booking.Domain.Entities.CountryAggregate;
using MongoDB.Driver;
using System.Threading.Tasks;
using Booking.DAL.MongoConfig;

namespace Booking.DAL.Repositories
{
    public class CountryRepository : BaseRepository<CountryEntity>, ICountryRepository
    {
        public CountryRepository(MongoDbSettings mongoSettings) : base(mongoSettings)
        {

        }

        public async Task UpdateAsync(CountryEntity countryEntity)
        {
            await collection.ReplaceOneAsync(doc => doc.Id == countryEntity.Id, countryEntity);
        }
    }
}
