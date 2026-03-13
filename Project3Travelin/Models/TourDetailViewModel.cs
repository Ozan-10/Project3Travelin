using Project3Travelin.Dtos.TourDtos;
using Project3Travelin.Dtos.TourProgramDtos;

namespace Project3Travelin.Models
{
    public class TourDetailViewModel
    {
        public GetTourByIdDto Tour { get; set; }

        public List<ResultTourProgramDto> TourPrograms { get; set; }
    }
}