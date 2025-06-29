using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Application.DTOs.Authors
{
    public class UpdateAuthorDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last Name is required.")]
        [StringLength(100)]
        public string LastName { get; set; } = string.Empty;
    }
}
