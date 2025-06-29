using AutoMapper;
using LibrarySystem.Application.DTOs.Books;
using LibrarySystem.Domain.Entities;

namespace LibrarySystem.Application.MappingProfiles
{
    public class BookProfile : Profile
    {
        public BookProfile() 
        {
            // Book -> BookDto
            CreateMap<Book, BookDto>()
                .ForMember(dest => dest.AuthorName, opt =>
                    opt.MapFrom(src => src.Author.FirstName + " " + src.Author.LastName))
                .ForMember(dest => dest.GenreName, opt =>
                    opt.MapFrom(src => src.Genre.Name));

            // CreateBookDto -> Book
            CreateMap<CreateBookDto, Book>();

            // UpdateBookDto -> Book
            CreateMap<UpdateBookDto, Book>();
        }
    }
}
