using LibrarySystem.Application.DTOs.Authors;
using LibrarySystem.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        // GET: /Author/
        public async Task<IActionResult> Index()
        {
            var authors = await _authorService.GetAllAsync();
            return View(authors);
        }

        // GET: /Author/Details/{id}
        public async Task<IActionResult> Details(Guid id)
        {
            var author = await _authorService.GetByIdAsync(id);
            if (author == null)
                return NotFound();

            return View(author);
        }

        // GET: /Author/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Author/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateAuthorDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            dto.CreatedAt = DateTime.Now;

            await _authorService.CreateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Author/Edit/{id}
        public async Task<IActionResult> Edit(Guid id)
        {
            var author = await _authorService.GetByIdAsync(id);
            if (author == null)
                return NotFound();

            var dto = new UpdateAuthorDto
            {
                Id = id,
                FirstName = author.FirstName,
                LastName = author.LastName
            };

            return View(dto);
        }

        // POST: /Author/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, UpdateAuthorDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var result = await _authorService.UpdateAsync(id, dto);
            if (!result)
                return NotFound();

            return RedirectToAction(nameof(Index));
        }

        // GET: /Author/Delete/{id}
        public async Task<IActionResult> Delete(Guid id)
        {
            var author = await _authorService.GetByIdAsync(id);
            if (author == null)
                return NotFound();

            return View(author);
        }

        // POST: /Author/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _authorService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
