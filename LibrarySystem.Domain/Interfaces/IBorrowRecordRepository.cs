using LibrarySystem.Domain.Entities;

namespace LibrarySystem.Domain.Interfaces
{
    public interface IBorrowRecordRepository
    {
        Task<List<BorrowRecord>> GetAllAsync();
        Task<BorrowRecord?> GetByIdAsync(Guid id);
        Task<List<BorrowRecord>> GetByUserIdAsync(Guid userId);
        Task<List<BorrowRecord>> GetByBookIdAsync(Guid bookId);

        Task AddAsync(BorrowRecord record);
        Task UpdateAsync(BorrowRecord record);
    }
}
