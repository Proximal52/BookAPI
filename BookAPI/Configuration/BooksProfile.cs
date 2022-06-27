using AutoMapper;
using BookAPI.Common.Models;
using BookAPI.Common.Models.DTO;

namespace BookAPI.Configuration
{
    public class BooksProfile : Profile
    {
        public BooksProfile()
        {
            CreateMap<Book, BookDto>()
                .ForPath(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForPath(dest => dest.Author, opt => opt.MapFrom(src => src.Author))
                .ForPath(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<BookCreateDto, Book>()
                .ForPath(dest => dest.Author, opt => opt.MapFrom(src => src.Author))
                .ForPath(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<BookUpdateDto, Book>()
                .ForPath(dest => dest.Author, opt => opt.MapFrom(src => src.Author))
                .ForPath(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}
