using LibrarySystem.Application.DTOs.BorrowRecords;
using LibrarySystem.Application.Interfaces.Services;
using LibrarySystem.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BorrowRecordController : Controller
    {
        private readonly IBorrowRecordService _borrowService;
        private readonly IMemberService _memberService;
        private readonly IBookService _bookService;

        public BorrowRecordController(IBorrowRecordService borrowService, IMemberService memberService, IBookService bookService)
        {
            _borrowService = borrowService;
            _memberService = memberService;
            _bookService = bookService;
        }

        // GET: /BorrowRecord/
        public async Task<IActionResult> Index()
        {
            var records = await _borrowService.GetAllAsync();
            return View(records);
        }

        // GET: /BorrowRecord/Create
        public async Task<IActionResult> Create()
        {
            var viewModel = new BorrowRecordCreateViewModel
            {
                Books = await _bookService.GetAvailableAsync(),
                Members = await _memberService.GetAllAsync(),
                CreateDto = new() { DueDate = DateTime.Now.AddDays(1) }
            };

            return View(viewModel);
        }

        // POST: /BorrowRecord/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BorrowRecordCreateViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Books = await _bookService.GetAvailableAsync();
                viewModel.Members = await _memberService.GetAllAsync();
                return View(viewModel);
            }

            await _borrowService.CreateAsync(viewModel.CreateDto);
            return RedirectToAction(nameof(Index));
        }

        // GET: /BorrowRecord/Details/{id}
        public async Task<IActionResult> Details(Guid id)
        {
            var record = await _borrowService.GetByIdAsync(id);
            if (record == null) return NotFound();

            return View(record);
        }

        // GET: /BorrowRecord/Edit/{id}
        public async Task<IActionResult> Edit(Guid id)
        {
            var record = await _borrowService.GetByIdAsync(id);
            if (record == null) return NotFound();

            var viewModel = new BorrowRecordEditViewModel
            {
                UpdateDto = new UpdateBorrowRecordDto
                {
                    Id = record.Id,
                    DueDate = record.DueDate
                },
                MemberFullName = record.MemberFullName,
                BookTitle = record.BookTitle
            };

            return View(viewModel);
        }

        // POST: /BorrowRecord/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BorrowRecordEditViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            var success = await _borrowService.UpdateAsync(viewModel.UpdateDto);
            if (!success) return NotFound();

            return RedirectToAction(nameof(Index));
        }

        // POST: /BorrowRecord/Return/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Return(ReturnBorrowRecordDto dto)
        {
            var success = await _borrowService.MarkAsReturnedAsync(dto);
            if (!success)
                return NotFound();

            return RedirectToAction(nameof(Index));
        }
    }
}
