using AutoMapper;
using LibrarySystem.Application.DTOs.BorrowRecords;
using LibrarySystem.Application.Interfaces.Services;
using LibrarySystem.Domain.Entities;
using LibrarySystem.Domain.Interfaces;

namespace LibrarySystem.Infrastructure.Services
{
    public class BorrowRecordService : IBorrowRecordService
    {
        private readonly IBorrowRecordRepository _recordRepo;
        private readonly IBookRepository _bookRepo;
        private readonly IMemberRepository _memberRepo;
        private readonly IMapper _mapper;

        public BorrowRecordService(IBorrowRecordRepository recordRepo, IBookRepository bookRepo, IMemberRepository memberRepo, IMapper mapper)
        {
            _recordRepo = recordRepo;
            _bookRepo = bookRepo;
            _memberRepo = memberRepo;
            _mapper = mapper;
        }

        public async Task<List<BorrowRecordDto>> GetAllAsync()
        {
            var records = await _recordRepo.GetAllAsync();
            return _mapper.Map<List<BorrowRecordDto>>(records);
        }

        public async Task<BorrowRecordDto?> GetByIdAsync(Guid id)
        {
            var record = await _recordRepo.GetByIdAsync(id);
            return record is null ? null : _mapper.Map<BorrowRecordDto>(record);
        }

        public async Task<List<BorrowRecordDto>> GetByUserIdAsync(Guid userId)
        {
            var records = await _recordRepo.GetByUserIdAsync(userId);
            return _mapper.Map<List<BorrowRecordDto>>(records);
        }

        public async Task<List<BorrowRecordDto>> GetByBookIdAsync(Guid bookId)
        {
            var records = await _recordRepo.GetByBookIdAsync(bookId);
            return _mapper.Map<List<BorrowRecordDto>>(records);
        }

        public async Task<Guid> CreateAsync(CreateBorrowRecordDto dto)
        {
            // Validate existence
            var book = await _bookRepo.GetByIdAsync(dto.BookId);
            var member = await _memberRepo.GetByIdAsync(dto.MemberId);

            if (book is null || member is null)
                throw new Exception("Invalid BookId or UserId");

            if (!book.IsAvailable)
                throw new Exception("Book is already borrowed.");

            var record = _mapper.Map<BorrowRecord>(dto);
            record.BorrowedAt = DateTime.UtcNow;

            book.IsAvailable = false;
            await _recordRepo.AddAsync(record);
            return record.Id;

        }

        public async Task<bool> UpdateAsync(UpdateBorrowRecordDto dto)
        {
            var record = await _recordRepo.GetByIdAsync(dto.Id);
            if (record == null)
                return false;

            record.DueDate = dto.DueDate;

            await _recordRepo.UpdateAsync(record);
            return true;
        }

        public async Task<bool> MarkAsReturnedAsync(ReturnBorrowRecordDto dto)
        {
            var record = await _recordRepo.GetByIdAsync(dto.BorrowRecordId);
            if (record is null || record.ReturnedAt != null)
                return false;

            record.ReturnedAt = DateTime.UtcNow;

            var book = await _bookRepo.GetByIdAsync(record.BookId);
            if (book != null)
            {
                book.IsAvailable = true;
                await _bookRepo.UpdateAsync(book);
            }

            await _recordRepo.UpdateAsync(record);
            return true;
        }
    }
}
