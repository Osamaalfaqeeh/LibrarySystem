using LibrarySystem.Domain.Entities;
using LibrarySystem.Domain.Interfaces;
using LibrarySystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Infrastructure.Repositories
{
    public class BorrowRecordRepository : IBorrowRecordRepository
    {
        private readonly LibraryDbContext _context;

        public BorrowRecordRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<List<BorrowRecord>> GetAllAsync()
        {
            return await _context.BorrowRecords
                .Include(br => br.Book)
                .Include(br => br.Member)
                .ToListAsync();
        }

        public async Task<BorrowRecord?> GetByIdAsync(Guid id)
        {
            return await _context.BorrowRecords
                .Include(br => br.Book)
                .Include(br => br.Member)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<List<BorrowRecord>> GetByUserIdAsync(Guid userId)
        {
            return await _context.BorrowRecords
                .Where(br => br.MemberId == userId)
                .Include(br => br.Book)
                .ToListAsync();
        }

        public async Task<List<BorrowRecord>> GetByBookIdAsync(Guid bookId)
        {
            return await _context.BorrowRecords
                .Where(br => br.BookId == bookId)
                .Include(br => br.Member)
                .ToListAsync();
        }

        public async Task AddAsync(BorrowRecord record)
        {
            await _context.BorrowRecords.AddAsync(record);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(BorrowRecord record)
        {
            _context.BorrowRecords.Update(record);
            await _context.SaveChangesAsync();
        }
    }
}
