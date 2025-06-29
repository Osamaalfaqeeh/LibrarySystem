using AutoMapper;
using LibrarySystem.Application.DTOs.Members;
using LibrarySystem.Application.Interfaces.Services;
using LibrarySystem.Domain.Entities;
using LibrarySystem.Domain.Interfaces;

namespace LibrarySystem.Infrastructure.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _repository;
        private readonly IMapper _mapper;

        public MemberService(IMemberRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<MemberDto>> GetAllAsync()
        {
            var members = await _repository.GetAllAsync();
            return _mapper.Map<List<MemberDto>>(members);
        }

        public async Task<MemberDto?> GetByIdAsync(Guid id)
        {
            var member = await _repository.GetByIdAsync(id);
            return member == null ? null : _mapper.Map<MemberDto>(member);
        }

        public async Task CreateAsync(CreateMemberDto dto)
        {
            var member = _mapper.Map<Member>(dto);
            member.CreatedAt = DateTime.UtcNow;
            await _repository.AddAsync(member);
        }

        public async Task<bool> UpdateAsync(UpdateMemberDto dto)
        {
            var member = await _repository.GetByIdAsync(dto.Id);
            if (member == null) return false;
            _mapper.Map(dto, member);

            await _repository.UpdateAsync(member);
            return true;
        }
    }

}
