using LibrarySystem.Application.DTOs.Dashboard;
using LibrarySystem.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
       
        private readonly IBookService _bookService;
        private readonly IBorrowRecordService _borrowRecordService;
        private readonly IAuthorService _authorService;
        private readonly IGenreService _genreService;
        private readonly IMemberService _memberService;

        public HomeController(
            IBookService bookService,
            IBorrowRecordService borrowRecordService,
            IAuthorService authorService,
            IGenreService genreService,
            IMemberService memberService)
        {
            _bookService = bookService;
            _borrowRecordService = borrowRecordService;
            _authorService = authorService;
            _genreService = genreService;
            _memberService = memberService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var dashboard = await GetDashboardDataAsync();
                return View(dashboard);
            }
            catch (Exception ex)
            {
                // Log the exception here
                // _logger.LogError(ex, "Error loading dashboard data");

                // Return a basic dashboard with error message
                var errorDashboard = new DashboardDto();
                TempData["Error"] = "Unable to load some dashboard data. Please try refreshing the page.";
                return View(errorDashboard);
            }
        }

        private async Task<DashboardDto> GetDashboardDataAsync()
        {
            // Get all books
            var books = await _bookService.GetAllAsync();

            // Get authors and genres count
            var authors = await _authorService.GetAllAsync();
            var genres = await _genreService.GetAllAsync();
            var members = await _memberService.GetAllAsync();

            var dashboard = new DashboardDto
            {
                TotalBooks = books.Count(),
                AvailableBooks = books.Count(b => b.IsAvailable),
                BorrowedBooks = books.Count(b => !b.IsAvailable),
                TotalAuthors = authors.Count(),
                TotalGenres = genres.Count(),
                TotalMembers = members.Count()
            };

            return dashboard;
        }
    }
}
