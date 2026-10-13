using Microsoft.AspNetCore.Mvc;
using Movie.Domain.DTOs;
using Movie.Service.Interfaces;
using Movie.Web.MVC.Models;

namespace Movie.Web.MVC.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] MovieFilterDTO filter)
        {
            var vm = new MovieIndexViewModel { Filter = filter };
            try
            {
                vm.Movies = await _movieService.FilterMoviesAsync(filter);
            }
            catch (ArgumentException ex)
            {
                vm.Error = ex.Message;
            }
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var dto = await _movieService.GetMovieForUpdateAsync(id);
                ViewData["MovieId"] = id;
                return View(dto);
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateMovieDTO dto)
        {
            try
            {
                await _movieService.UpdateMovieAsync(id, dto);
                return RedirectToAction(nameof(Index));
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                ViewData["MovieId"] = id;
                return View(dto);
            }
        }
    }
}