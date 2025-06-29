using LibrarySystem.Application.DTOs.Genres;
using LibrarySystem.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class GenreController : Controller
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        // GET: /Genre/
        public async Task<IActionResult> Index()
        {
            var genres = await _genreService.GetAllAsync();
            return View(genres);
        }

        // GET: /Genre/Details/{id}
        public async Task<IActionResult> Details(Guid id)
        {
            var genre = await _genreService.GetByIdAsync(id);
            if (genre == null)
                return NotFound();

            return View(genre);
        }

        // GET: /Genre/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Genre/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateGenreDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            dto.CreatedAt = DateTime.Now;

            await _genreService.CreateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Genre/Edit/{id}
        public async Task<IActionResult> Edit(Guid id)
        {
            var genre = await _genreService.GetByIdAsync(id);
            if (genre == null)
                return NotFound();

            return View(genre);
        }

        // POST: /Genre/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, UpdateGenreDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var result = await _genreService.UpdateAsync(id, dto);
            if (!result)
                return NotFound();

            return RedirectToAction(nameof(Index));
        }

        // GET: /Genre/Delete/{id}
        public async Task<IActionResult> Delete(Guid id)
        {
            var genre = await _genreService.GetByIdAsync(id);
            if (genre == null)
                return NotFound();

            return View(genre);
        }

        // POST: /Genre/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _genreService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
