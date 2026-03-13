using Project3Travelin.Dtos.BookingDtos;

namespace Project3Travelin.Services.BookingServices
{
    public interface IBookingService
    {
        Task CreateBookingAsync(CreateBookingDto dto);
        Task<List<ResultBookingDto>> GetAllBookingAsync();
        Task ApproveBookingAsync(string id);
        Task DeleteBookingAsync(string id);
        Task<List<ResultBookingDto>> GetBookingsByTourIdAsync(string tourId);
    }
}