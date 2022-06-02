using Booking.Domain.Entities.AdvertiesementAggregate;
using System.Threading.Tasks;

namespace Booking.DAL.Interfaces
{
    public interface IAdvertisementRepository : IRepository<AdvertisementEntity>
    {
        Task UpdateAsync(AdvertisementEntity advertisementEntity);
    }
}
