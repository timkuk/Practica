using System.Threading.Tasks;
using Booking.Domain.Entities.UserAggregate;

namespace Booking.BLL.Interfaces
{
    public interface ITokenService
    {
        Task<string> GenerateTokenAsync(ApplicationUser user);
    }
}