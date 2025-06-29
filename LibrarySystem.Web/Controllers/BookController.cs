using LibrarySystem.Application.DTOs.Books;
using LibrarySystem.Application.Interfaces.Services;
using LibrarySystem.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        private readonly IGenreService _genreService;
        public BookController(IBookService bookService, IAuthorService authorService, IGenreService genreService)
        {
            _bookService = bookService;
            _authorService = authorService;
            _genreService = genreService;
        }

        // GET: /Book/
        public async Task<IActionResult> Index()
        {
            var books = await _bookService.GetAllAsync();
            return View(books);
        }

        // GET: /Book/Details/{id}
        public async Task<IActionResult> Details(Guid id)
        {
            var book = await _bookService.GetByIdAsync(id);
            if (book == null)
                return NotFound();
            return View(book);
        }

        // GET: /Book/Create
        public async Task<IActionResult> Create()
        {
            var viewModel = new BookCreateViewModel
            {
                Authors = await _authorService.GetAllAsync(),
                Genres = await _genreService.GetAllAsync(),
                CreateDto = new CreateBookDto() // 💡 Prevents binding errors
            };

            return View(viewModel);
        }

        // POST: /Book/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookCreateViewModel dto)
        {
            if (!ModelState.IsValid)
            {
                dto.Authors = await _authorService.GetAllAsync();
                dto.Genres = await _genreService.GetAllAsync();
                return View(dto);
            }
            await _bookService.CreateAsync(dto.CreateDto);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Book/Edit/{id}
        public async Task<IActionResult> Edit(Guid id)
        {
            var book = await _bookService.GetByIdAsync(id);
            if (book == null)
                return NotFound();

            var authors = await _authorService.GetAllAsync();
            var genres = await _genreService.GetAllAsync();

            var viewModel = new BookUpdateViewModel
            {
                Id = book.Id,
                UpdateDto = new UpdateBookDto
                {
                    Title = book.Title,
                    AuthorId = authors.FirstOrDefault(a => a.FullName == book.AuthorName)?.Id ?? Guid.Empty,
                    GenreId = genres.FirstOrDefault(g => g.Name == book.GenreName)?.Id ?? Guid.Empty,
                    Description = book.Description
                },
                Authors = authors,
                Genres = genres
            };

            return View(viewModel);
        }

        // POST: /Book/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, BookUpdateViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Authors = await _authorService.GetAllAsync();
                viewModel.Genres = await _genreService.GetAllAsync();
                return View(viewModel);
            }

            var result = await _bookService.UpdateAsync(id, viewModel.UpdateDto);
            if (!result)
                return NotFound();

            return RedirectToAction(nameof(Index));
        }

        // GET: /Book/Delete/{id}
        public async Task<IActionResult> Delete(Guid id)
        {
            var book = await _bookService.GetByIdAsync(id);
            if (book == null)
                return NotFound();

            return View(book);
        }

        // POST: /Book/Delete/{id}
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _bookService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }


    }
}
