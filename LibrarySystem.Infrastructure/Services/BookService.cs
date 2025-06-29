using AutoMapper;
using LibrarySystem.Application.DTOs.Books;
using LibrarySystem.Application.Interfaces.Services;
using LibrarySystem.Domain.Entities;
using LibrarySystem.Domain.Interfaces;

namespace LibrarySystem.Infrastructure.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepo;
        private readonly IAuthorRepository _authorRepo;
        private readonly IGenreRepository _genreRepo;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepo, IAuthorRepository authorRepo, IGenreRepository genreRepo, IMapper mapper) 
        {
            _bookRepo = bookRepo;
            _authorRepo = authorRepo;
            _genreRepo = genreRepo;
            _mapper = mapper;
        }

        public async Task<List<BookDto>> GetAllAsync()
        {
            var books = await _bookRepo.GetAllAsync();
            return _mapper.Map<List<BookDto>>(books);
        }

        public async Task<List<BookDto>> GetAvailableAsync()
        {
            var books = await _bookRepo.GetAllAsync();
            return books
                .Where(b => b.IsAvailable)
                .Select(b => _mapper.Map<BookDto>(b))
                .ToList();
        }


        public async Task<BookDto?> GetByIdAsync(Guid id)
        {
            var book = await _bookRepo.GetByIdAsync(id);
            return book is null ? null : _mapper.Map<BookDto>(book);
        }

        public async Task<Guid> CreateAsync(CreateBookDto dto)
        {
            var authorExists = await _authorRepo.GetByIdAsync(dto.AuthorId) is not null;
            var genreExists = await _genreRepo.GetByIdAsync(dto.GenreId) is not null;

            if (!authorExists || !genreExists)
                throw new Exception("Invalid author or genre ID.");

            var book = _mapper.Map<Book>(dto);
            book.CreatedAt = DateTime.UtcNow;

            await _bookRepo.AddAsync(book);
            return book.Id;
        }

        public async Task<bool> UpdateAsync(Guid id, UpdateBookDto dto)
        {
            var book = await _bookRepo.GetByIdAsync(id);
            if (book is null)
                return false;

            var author = await _authorRepo.GetByIdAsync(dto.AuthorId);
            var genre = await _genreRepo.GetByIdAsync(dto.GenreId);
            if (author is null || genre is null)
                return false;

            _mapper.Map(dto, book);
            await _bookRepo.UpdateAsync(book);
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var book = await _bookRepo.GetByIdAsync(id);
            if (book is null)
                return false;

            await _bookRepo.DeleteAsync(book);
            return true;
        }
    }
}
