namespace Project3Travelin.Dtos.BookingDtos
{
    
        public class CreateBookingDto
        {
            public string TourId { get; set; }

            public string Name { get; set; }

            public string Email { get; set; }

            public int PersonCount { get; set; }

            public DateTime Date { get; set; }
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string ExpireMonth { get; set; }
        public string ExpireYear { get; set; }
        public string Cvv { get; set; }
    }
    }
