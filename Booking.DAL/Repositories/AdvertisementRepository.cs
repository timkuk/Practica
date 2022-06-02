using Booking.DAL.Interfaces;
using Booking.Domain.Entities.AdvertiesementAggregate;
using MongoDB.Driver;
using System.Threading.Tasks;
using Booking.DAL.MongoConfig;
using System.Linq;

namespace Booking.DAL.Repositories
{
    public class AdvertisementRepository : BaseRepository<AdvertisementEntity>, IAdvertisementRepository
    {
        public AdvertisementRepository(MongoDbSettings mongoSettings) : base(mongoSettings)
        {

        }

        public async Task UpdateAsync(AdvertisementEntity advertisementEntity)
        {
            await collection.ReplaceOneAsync(doc => doc.Id == advertisementEntity.Id, advertisementEntity);
        }
    }
}