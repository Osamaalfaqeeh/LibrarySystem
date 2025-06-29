using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Application.DTOs.BorrowRecords
{
    public class CreateBorrowRecordDto
    {
        [Required(ErrorMessage = "Please select a book.")]
        public Guid BookId { get; set; }

        [Required(ErrorMessage = "Please select a member.")]
        public Guid MemberId { get; set; }

        [Required(ErrorMessage = "Borrow date is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Borrow Date")]
        public DateTime BorrowedAt { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Due date is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Due Date")]
        public DateTime DueDate { get; set; }
        
    }
}
