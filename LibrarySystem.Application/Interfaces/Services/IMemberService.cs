using LibrarySystem.Application.DTOs.Members;

namespace LibrarySystem.Application.Interfaces.Services
{
    public interface IMemberService
    {
        Task<List<MemberDto>> GetAllAsync();
        Task<MemberDto?> GetByIdAsync(Guid id);
        Task CreateAsync(CreateMemberDto dto);
        Task<bool> UpdateAsync(UpdateMemberDto dto);
    }

}
