using LibrarySystem.Application.DTOs.BorrowRecords;

namespace LibrarySystem.Web.ViewModels
{
    public class BorrowRecordEditViewModel
    {
        public UpdateBorrowRecordDto UpdateDto { get; set; } = new();
        public string BookTitle { get; set; } = string.Empty;
        public string MemberFullName { get; set; } = string.Empty;
    }

}
