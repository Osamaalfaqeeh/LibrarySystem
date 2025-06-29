using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Application.DTOs.Genres
{
    public class CreateGenreDto
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
    }
}
