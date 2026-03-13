using Microsoft.AspNetCore.Mvc;
using Project3Travelin.Dtos.TourDtos;
using Project3Travelin.Services.TourServices;

namespace Project3Travelin.Controllers
{
    public class AdminTourController : Controller
    {
        private readonly ITourService _tourservice;

        public AdminTourController(ITourService tourservice)
        {
            _tourservice = tourservice;
        }

        public async Task<IActionResult> TourList()
        {
            var values = await _tourservice.GetAllTourAsync();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateTour()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTour(CreateTourDto createTourDto)
        {
            await _tourservice.CreateTourAsync(createTourDto);
            return RedirectToAction("TourList");
        }
        public async Task<IActionResult> DeleteTour(string id)
        {
            await _tourservice.DeleteTourAsync(id);
            return RedirectToAction("Tourlist");
        }
        public async Task<IActionResult> UpdateTour(string id)
        {
            var value = await _tourservice.GetTourByIdAsync(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTour(UpdateTourDto updateTourDto)
        {
            await _tourservice.UpdateTourAsync(updateTourDto);
            return RedirectToAction("TourList");
        }    }
}
