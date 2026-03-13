using Microsoft.AspNetCore.Mvc;
using Project3Travelin.Dtos.TourDtos;
using Project3Travelin.Models;
using Project3Travelin.Services.TourProgramServices;
using Project3Travelin.Services.TourServices;

namespace Project3Travelin.Controllers
{
    public class TourController : Controller
    {
        private readonly ITourService _tourService;
        private readonly ITourProgramService _tourProgramService;

        public TourController(ITourService tourService, ITourProgramService tourProgramService)
        {
            _tourService = tourService;
            _tourProgramService = tourProgramService;
        }

        [HttpGet]
        public IActionResult CreateTour()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTour(CreateTourDto createTourDto)
        {
            await _tourService.CreateTourAsync(createTourDto);
            return RedirectToAction("CreateTour");
        }

        public async Task<IActionResult> TourList(int page = 1)
        {
            int pageSize = 8;

            var result = await _tourService.GetPagedAsync(page, pageSize);

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)result.TotalCount / pageSize);

            return View(result.Tours);
        }

        public async Task<IActionResult> TourDetail(string id)
        {
            id = id?.Trim();

            if (string.IsNullOrEmpty(id))
                return RedirectToAction("TourList");

            var tour = await _tourService.GetTourByIdAsync(id);

            if (tour == null)
                return NotFound();

            var programs = await _tourProgramService.GetTourProgramsByTourIdAsync(id);

            var model = new TourDetailViewModel
            {
                Tour = tour,
                TourPrograms = programs
            };

            return View(model);
        }
    }
}