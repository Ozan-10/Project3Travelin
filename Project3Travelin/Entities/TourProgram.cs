using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Project3Travelin.Entities
{
    public class TourProgram
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string TourProgramId { get; set; }

        public string TourId { get; set; }

        public string DayTitle { get; set; }

        public string Description { get; set; }
    }
}