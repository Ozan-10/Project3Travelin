using Microsoft.AspNetCore.Mvc;
using Project3Travelin.Dtos.BookingDtos;
using Project3Travelin.Services.BookingServices;
using Project3Travelin.Services.TourServices;

namespace Project3Travelin.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly ITourService _tourService;

        public BookingController(IBookingService bookingService, ITourService tourService)
        {
            _bookingService = bookingService;
            _tourService = tourService;
        }

        [HttpGet]
        public async Task<IActionResult> CreateBooking(string id)
        {
            var tour = await _tourService.GetTourByIdAsync(id);

            ViewBag.TourTitle = tour.Title;
            ViewBag.TourImage = tour.ImageUrl;
            ViewBag.Price = 9500;

            var dto = new CreateBookingDto
            {
                TourId = id
            };

            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking(CreateBookingDto dto)
        {
            await _bookingService.CreateBookingAsync(dto);
            return RedirectToAction("TourList", "Tour");
        }
    }
}