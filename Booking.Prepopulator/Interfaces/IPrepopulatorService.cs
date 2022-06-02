using System.Threading.Tasks;

namespace Booking.Prepopulator.Interfaces
{
    public interface IPrepopulatorService
    {
        Task SeedAllDataAsync();
    }
}