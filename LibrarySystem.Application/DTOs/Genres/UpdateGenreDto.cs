using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Application.DTOs.Genres
{
    public class UpdateGenreDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;
    }
}
