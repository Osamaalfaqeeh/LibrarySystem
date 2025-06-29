using LibrarySystem.Application.DTOs.Authors;
using LibrarySystem.Application.DTOs.Books;
using LibrarySystem.Application.DTOs.Genres;

namespace LibrarySystem.Web.ViewModels
{
    public class BookCreateViewModel
    {
        public CreateBookDto CreateDto { get; set; } = new();
        public List<AuthorDto> Authors { get; set; } = new();
        public List<GenreDto> Genres { get; set; } = new();
    }

}
