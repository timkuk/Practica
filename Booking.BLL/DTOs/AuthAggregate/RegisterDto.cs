namespace Booking.BLL.DTOs.AuthAggregate
{
    public record RegisterDto(string UserName, string Password, string Email, string PhoneNumber) : LoginDto(UserName, Password) { }
}