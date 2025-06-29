using LibrarySystem.Application.DTOs.BorrowRecords;

namespace LibrarySystem.Application.Interfaces.Services
{
    public interface IBorrowRecordService
    {
        Task<List<BorrowRecordDto>> GetAllAsync();
        Task<BorrowRecordDto?> GetByIdAsync(Guid id);

        Task<List<BorrowRecordDto>> GetByUserIdAsync(Guid userId);
        Task<List<BorrowRecordDto>> GetByBookIdAsync(Guid bookId);

        Task<Guid> CreateAsync(CreateBorrowRecordDto dto);
        Task<bool> UpdateAsync(UpdateBorrowRecordDto dto);
        Task<bool> MarkAsReturnedAsync(ReturnBorrowRecordDto dto);
    }
}
