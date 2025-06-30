using BookStoreApi.DbOperations;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Linq;
using BookStoreApi.Common;
using BookStoreApi;
using AutoMapper;

namespace BookStoreApi.BookOperation.GetBookDetail
{
    public class GetBookDetailQuery(BookStoreDbContext dbContext,IMapper mapper)
    {
        private readonly IMapper _mapper=mapper;
        private readonly BookStoreDbContext _dbContext = dbContext;
        public int BookId { get; set; }

        public BookDetailViewModel Handle()
        {
            var book = _dbContext.Books.Where(book => book.Id == BookId).SingleOrDefault() ?? throw new InvalidOperationException("Kitap Bulunamadı");
            BookDetailViewModel vm = _mapper.Map<BookDetailViewModel>(book); // new()
            //{
            //    Title = book.Title,
            //    PageCount = book.PageCount,
            //    PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy"),
            //    Genre = ((GenreEnum)book.GenreId).ToString()
            //};
            return vm;

            
        }
        public class BookDetailViewModel
        {
            public  string? Title { get; set; }
            public string? Genre { get; set; }
            public int PageCount { get; set; }
            public string? PublishDate { get; set; }
        }
    }
}
