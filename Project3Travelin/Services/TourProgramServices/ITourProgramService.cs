using Project3Travelin.Dtos.TourProgramDtos;

namespace Project3Travelin.Services.TourProgramServices
{
    public interface ITourProgramService
    {
        Task<List<ResultTourProgramDto>> GetTourProgramsByTourIdAsync(string tourId);
    }
}