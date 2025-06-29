using LibrarySystem.Application.DTOs.Authors;
using LibrarySystem.Application.DTOs.Books;
using LibrarySystem.Application.DTOs.Genres;

namespace LibrarySystem.Web.ViewModels
{
    public class BookUpdateViewModel
    {
        public Guid Id { get; set; }
        public UpdateBookDto UpdateDto { get; set; } = new();

        // These are used to render <select> dropdowns
        public List<AuthorDto> Authors { get; set; } = new();
        public List<GenreDto> Genres { get; set; } = new();
    }
}
