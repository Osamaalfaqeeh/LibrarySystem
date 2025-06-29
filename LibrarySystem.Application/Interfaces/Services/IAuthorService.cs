using LibrarySystem.Application.DTOs.Authors;

namespace LibrarySystem.Application.Interfaces.Services
{
    public interface IAuthorService
    {
        Task<List<AuthorDto>> GetAllAsync();
        Task<AuthorDto?> GetByIdAsync(Guid id);

        Task<Guid> CreateAsync(CreateAuthorDto dto);
        Task<bool> UpdateAsync(Guid id, UpdateAuthorDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
