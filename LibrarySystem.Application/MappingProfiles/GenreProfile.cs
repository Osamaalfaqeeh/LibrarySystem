using AutoMapper;
using LibrarySystem.Application.DTOs.Genres;
using LibrarySystem.Domain.Entities;

namespace LibrarySystem.Application.MappingProfiles
{
    public class GenreProfile : Profile
    {
        public GenreProfile() 
        {
            // Entity to DTO
            CreateMap<Genre, GenreDto>();

            // DTOs to Entity
            CreateMap<CreateGenreDto, Genre>();
            CreateMap<UpdateGenreDto, Genre>();
        }
    }
}
