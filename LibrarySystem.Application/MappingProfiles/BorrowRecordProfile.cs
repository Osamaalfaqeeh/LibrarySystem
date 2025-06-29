using AutoMapper;
using LibrarySystem.Application.DTOs.BorrowRecords;
using LibrarySystem.Domain.Entities;

namespace LibrarySystem.Application.MappingProfiles
{
    public class BorrowRecordProfile : Profile
    {
        public BorrowRecordProfile() 
        {
            // Entity to DTO
            CreateMap<BorrowRecord, BorrowRecordDto>()
                .ForMember(dest => dest.BookTitle,
                    opt => opt.MapFrom(src => src.Book.Title))
                .ForMember(dest => dest.MemberFullName,
                    opt => opt.MapFrom(src => src.Member.FirstName + " " + src.Member.LastName));

            // DTOs to Entity
            CreateMap<CreateBorrowRecordDto, BorrowRecord>();
        }
    }
}
