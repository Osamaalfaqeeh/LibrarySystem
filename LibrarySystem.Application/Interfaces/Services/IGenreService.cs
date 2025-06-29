using LibrarySystem.Application.DTOs.Genres;

namespace LibrarySystem.Application.Interfaces.Services
{
    public interface IGenreService
    {
        Task<List<GenreDto>> GetAllAsync();
        Task<GenreDto?> GetByIdAsync(Guid id);

        Task<Guid> CreateAsync(CreateGenreDto dto);
        Task<bool> UpdateAsync(Guid id, UpdateGenreDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
