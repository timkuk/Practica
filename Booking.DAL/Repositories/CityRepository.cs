using System.Threading.Tasks;
using Booking.DAL.Interfaces;
using Booking.DAL.MongoConfig;
using Booking.Domain.Entities.CountryAggregate;
using MongoDB.Driver;

namespace Booking.DAL.Repositories
{
    public class CityRepository : BaseRepository<CityEntity>, ICityRepository
    {
        public CityRepository(MongoDbSettings mongoSettings) : base(mongoSettings) { }

        public async Task UpdateAsync(CityEntity entity)
        {
            await collection.ReplaceOneAsync(doc => doc.Id == entity.Id, entity);
        }
    }
}