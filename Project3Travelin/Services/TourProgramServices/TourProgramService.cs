using MongoDB.Driver;
using Project3Travelin.Dtos.TourProgramDtos;
using Project3Travelin.Entities;
using Project3Travelin.Settings;

namespace Project3Travelin.Services.TourProgramServices
{
    public class TourProgramService : ITourProgramService
    {
        private readonly IMongoCollection<TourProgram> _tourProgramCollection;

        public TourProgramService(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _tourProgramCollection = database.GetCollection<TourProgram>("TourPrograms");
        }

        public async Task<List<ResultTourProgramDto>> GetTourProgramsByTourIdAsync(string tourId)
        {
            var values = await _tourProgramCollection.Find(x => x.TourId == tourId).ToListAsync();

            return values.Select(x => new ResultTourProgramDto
            {
                TourProgramId = x.TourProgramId,
                TourId = x.TourId,
                DayTitle = x.DayTitle,
                Description = x.Description
            }).ToList();
        }
    }
}