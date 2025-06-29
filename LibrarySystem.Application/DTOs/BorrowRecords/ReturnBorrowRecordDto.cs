namespace LibrarySystem.Application.DTOs.BorrowRecords
{
    public class ReturnBorrowRecordDto
    {
        public Guid BorrowRecordId { get; set; }
        public DateTime ReturnedAt { get; set; } = DateTime.Now;
    }
}
