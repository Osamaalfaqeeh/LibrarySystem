using AutoMapper;
using LibrarySystem.Application.DTOs.Members;
using LibrarySystem.Domain.Entities;

namespace LibrarySystem.Application.MappingProfiles
{
    public class MemberProfile : Profile
    {
        public MemberProfile()
        {
            CreateMap<Member, MemberDto>()
                .ForMember(dest => dest.FullName,
                opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));

            CreateMap<CreateMemberDto, Member>();
            CreateMap<UpdateMemberDto, Member>();
        }
    }
}
