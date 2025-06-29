namespace LibrarySystem.Application.DTOs.BorrowRecords
{
    public class BorrowRecordDto
    {
        public Guid Id { get; set; }
        
        public Guid BookId { get; set; }
        public string BookTitle { get; set; } = string.Empty;

        public Guid MemberId { get; set; }
        public string MemberFullName { get; set; } = string.Empty;

        public DateTime BorrowedAt { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnedAt { get; set; }

        public bool IsReturned => ReturnedAt.HasValue;
    }
}
