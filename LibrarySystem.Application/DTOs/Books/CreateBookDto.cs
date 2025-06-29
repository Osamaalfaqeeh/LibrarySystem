using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Application.DTOs.Books
{
    public class CreateBookDto
    {
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(50)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        public Guid AuthorId { get; set; }
        public Guid GenreId { get; set; }
    }
}
