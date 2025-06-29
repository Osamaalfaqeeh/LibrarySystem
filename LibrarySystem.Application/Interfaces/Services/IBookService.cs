using LibrarySystem.Application.DTOs.Books;

namespace LibrarySystem.Application.Interfaces.Services
{
    public interface IBookService
    {
        Task<List<BookDto>> GetAllAsync();
        Task<List<BookDto>> GetAvailableAsync();
        Task<BookDto?> GetByIdAsync(Guid id);

        Task<Guid> CreateAsync(CreateBookDto dto);
        Task<bool> UpdateAsync(Guid id, UpdateBookDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
