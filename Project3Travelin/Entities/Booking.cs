namespace Project3Travelin.Entities
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    namespace Project3Travelin.Entities
    {
        public class Booking
        {
            [BsonId]
            [BsonRepresentation(BsonType.ObjectId)]
            public string BookingId { get; set; }

            public string TourId { get; set; }

            public string Name { get; set; }

            public string Email { get; set; }

            public int PersonCount { get; set; }

            public DateTime Date { get; set; }

            public bool IsApproved { get; set; }
        }
    }
}
