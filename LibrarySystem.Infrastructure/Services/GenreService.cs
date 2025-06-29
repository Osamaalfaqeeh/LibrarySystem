using AutoMapper;
using LibrarySystem.Application.DTOs.Genres;
using LibrarySystem.Application.Interfaces.Services;
using LibrarySystem.Domain.Entities;
using LibrarySystem.Domain.Interfaces;

namespace LibrarySystem.Infrastructure.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepo;
        private readonly IMapper _mapper;

        public GenreService(IGenreRepository genreRepo, IMapper mapper) 
        {
            _genreRepo = genreRepo;
            _mapper = mapper;
        }

        public async Task<List<GenreDto>> GetAllAsync()
        {
            var genres = await _genreRepo.GetAllAsync();
            return _mapper.Map<List<GenreDto>>(genres);
        }

        public async Task<GenreDto?> GetByIdAsync(Guid id)
        {
            var genre = await _genreRepo.GetByIdAsync(id);
            return genre is null ? null : _mapper.Map<GenreDto>(genre);
        }

        public async Task<Guid> CreateAsync(CreateGenreDto dto)
        {
            var genre = _mapper.Map<Genre>(dto);
            await _genreRepo.AddAsync(genre);
            return genre.Id;
        }

        public async Task<bool> UpdateAsync(Guid id, UpdateGenreDto dto)
        {
            var genre = await _genreRepo.GetByIdAsync(id);
            if (genre is null)
                return false;

            _mapper.Map(dto, genre);
            await _genreRepo.UpdateAsync(genre);
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var genre = await _genreRepo.GetByIdAsync(id);
            if (genre is null)
                return false;

            await _genreRepo.DeleteAsync(genre);
            return true;
        }
    }
}
