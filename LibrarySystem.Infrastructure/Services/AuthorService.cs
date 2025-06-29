using AutoMapper;
using LibrarySystem.Application.DTOs.Authors;
using LibrarySystem.Application.Interfaces.Services;
using LibrarySystem.Domain.Entities;
using LibrarySystem.Domain.Interfaces;

namespace LibrarySystem.Infrastructure.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepo;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepository authorRepo, IMapper mapper)
        {
            _authorRepo = authorRepo;
            _mapper = mapper;
        }

        public async Task<List<AuthorDto>> GetAllAsync()
        {
            var authors = await _authorRepo.GetAllAsync();
            return _mapper.Map<List<AuthorDto>>(authors);
        }

        public async Task<AuthorDto?> GetByIdAsync(Guid id)
        {
            var author = await _authorRepo.GetByIdAsync(id);
            return author is null ? null : _mapper.Map<AuthorDto>(author);
        }

        public async Task<Guid> CreateAsync(CreateAuthorDto dto)
        {
            var author = _mapper.Map<Author>(dto);
            await _authorRepo.AddAsync(author);
            return author.Id;
        }

        public async Task<bool> UpdateAsync(Guid id, UpdateAuthorDto dto)
        {
            var author = await _authorRepo.GetByIdAsync(id);
            if (author is null)
                return false;

            _mapper.Map(dto, author);
            await _authorRepo.UpdateAsync(author);
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var author = await _authorRepo.GetByIdAsync(id);
            if (author is null)
                return false;

            await _authorRepo.DeleteAsync(author);
            return true;
        }
    }
}
