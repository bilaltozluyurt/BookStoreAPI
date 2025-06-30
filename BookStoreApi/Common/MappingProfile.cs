using AutoMapper;
using static BookStoreApi.BookOperation.CreateBook.CreateBookCommand;
using static BookStoreApi.BookOperation.GetBookDetail.GetBookDetailQuery;
using static BookStoreApi.BookOperation.GetBooks.GetBooksQuery;

namespace BookStoreApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
        }
    }
}
