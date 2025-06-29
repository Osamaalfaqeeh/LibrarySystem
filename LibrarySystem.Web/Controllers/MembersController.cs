using LibrarySystem.Application.DTOs.Members;
using LibrarySystem.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Web.Controllers
{
    public class MembersController : Controller
    {
        private readonly IMemberService _memberService;
        private readonly IBorrowRecordService _borrowService;

        public MembersController(IMemberService memberService, IBorrowRecordService borrowService)
        {
            _memberService = memberService;
            _borrowService = borrowService;
        }

        public async Task<IActionResult> Index()
        {
            var members = await _memberService.GetAllAsync();

            foreach (var user in members)
            {
                var borrows = await _borrowService.GetByUserIdAsync(user.Id);
                var activeBorrows = borrows.Where(b => !b.ReturnedAt.HasValue).ToList();

                user.HasActiveBorrows = activeBorrows.Any();
                user.ActiveBorrowsCount = activeBorrows.Count;
            }
            return View(members);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateMemberDto dto)
        {
            if (!ModelState.IsValid) return View(dto);
            await _memberService.CreateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var member = await _memberService.GetByIdAsync(id);
            if (member == null)
                return NotFound();

            return View(member);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var member = await _memberService.GetByIdAsync(id);
            if (member == null)
                return NotFound();

            var dto = new UpdateMemberDto
            {
                Id = member.Id,
                FirstName = member.FirstName,
                LastName = member.LastName,
                Email = member.Email,
                PhoneNumber = member.PhoneNumber
            };
            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateMemberDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var result = await _memberService.UpdateAsync(dto);
            if (!result)
                return NotFound();

            return RedirectToAction(nameof(Index));
        }
    }

}
