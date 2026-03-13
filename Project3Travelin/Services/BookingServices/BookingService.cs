using MongoDB.Driver;
using Project3Travelin.Dtos.BookingDtos;
using Project3Travelin.Entities;
using Project3Travelin.Entities.Project3Travelin.Entities;
using Project3Travelin.Settings;

namespace Project3Travelin.Services.BookingServices
{
    public class BookingService : IBookingService
    {
        private readonly IMongoCollection<Booking> _bookingCollection;
       
        private readonly IMongoCollection<Tour> _tourCollection;

        public BookingService(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _bookingCollection = database.GetCollection<Booking>("Bookings");
            _tourCollection = database.GetCollection<Tour>("Tours");
        }

        public async Task CreateBookingAsync(CreateBookingDto dto)
        {
            var booking = new Booking
            {
                TourId = dto.TourId,
                Name = dto.Name,
                Email = dto.Email,
                PersonCount = dto.PersonCount,
                Date = DateTime.Now,
                IsApproved = false
            };

            await _bookingCollection.InsertOneAsync(booking);
        }
        public async Task<List<ResultBookingDto>> GetAllBookingAsync()
        {
            var values = await _bookingCollection.Find(x => true).ToListAsync();

            return values.Select(x => new ResultBookingDto
            {
                BookingId = x.BookingId,
                TourId = x.TourId,
                Name = x.Name,
                Email = x.Email,
                PersonCount = x.PersonCount,
                Date = x.Date,
                IsApproved = x.IsApproved
            }).ToList();
        }
        public async Task ApproveBookingAsync(string id)
        {
            var filter = Builders<Booking>.Filter.Eq(x => x.BookingId, id);
            var update = Builders<Booking>.Update.Set(x => x.IsApproved, true);

            await _bookingCollection.UpdateOneAsync(filter, update);
        }
        public async Task DeleteBookingAsync(string id)
        {
            await _bookingCollection.DeleteOneAsync(x => x.BookingId == id);
        }
        public async Task<List<ResultBookingDto>> GetBookingsByTourIdAsync(string tourId)
        {
            var values = await _bookingCollection.Find(x => x.TourId == tourId).ToListAsync();

            var tour = await _tourCollection.Find(x => x.TourId == tourId).FirstOrDefaultAsync();

            return values.Select(x => new ResultBookingDto
            {
                BookingId = x.BookingId,
                TourId = x.TourId,
                Name = x.Name,
                Email = x.Email,
                PersonCount = x.PersonCount,
                Date = x.Date,
                IsApproved = x.IsApproved,
                TourImageUrl = tour != null ? tour.ImageUrl : ""
            }).ToList();
        }
    }
}