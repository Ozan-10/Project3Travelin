using Microsoft.AspNetCore.Mvc;
using Project3Travelin.Services.BookingServices;

namespace Project3Travelin.Controllers
{
    public class AdminBookingController : Controller
    {
        private readonly IBookingService _bookingService;

        public AdminBookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _bookingService.GetAllBookingAsync();
            return View(values);
        }
        public async Task<IActionResult> ApproveBooking(string id)
        {
            await _bookingService.ApproveBookingAsync(id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteBooking(string id)
        {
            await _bookingService.DeleteBookingAsync(id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> CustomersByTour(string id)
        {
            var values = await _bookingService.GetBookingsByTourIdAsync(id);
            return View(values);
        }
    }
}