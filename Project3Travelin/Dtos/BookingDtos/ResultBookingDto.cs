namespace Project3Travelin.Dtos.BookingDtos
{
    public class ResultBookingDto
    {
        public string BookingId { get; set; }
        public string TourId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int PersonCount { get; set; }
        public DateTime Date { get; set; }
        public bool IsApproved { get; set; }
        public string TourImageUrl { get; set; }
    }
}