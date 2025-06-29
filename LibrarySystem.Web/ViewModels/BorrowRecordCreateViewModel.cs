using LibrarySystem.Application.DTOs.Books;
using LibrarySystem.Application.DTOs.BorrowRecords;
using LibrarySystem.Application.DTOs.Members;

namespace LibrarySystem.Web.ViewModels
{
    public class BorrowRecordCreateViewModel
    {
        public CreateBorrowRecordDto CreateDto { get; set; } = new();

        public List<BookDto> Books { get; set; } = new();
        public List<MemberDto> Members { get; set; } = new();
    }
}
