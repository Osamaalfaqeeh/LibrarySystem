using AutoMapper;
using LibrarySystem.Application.DTOs.Authors;
using LibrarySystem.Domain.Entities;

namespace LibrarySystem.Application.MappingProfiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            // Entity to DTO
            CreateMap<Author, AuthorDto>();

            // DTOs to Entity
            CreateMap<CreateAuthorDto, Author>();
            CreateMap<UpdateAuthorDto, Author>();
        }
    }
}
