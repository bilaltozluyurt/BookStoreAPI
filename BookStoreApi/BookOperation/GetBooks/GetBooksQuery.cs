using AutoMapper;
using BookStoreApi.Common;
using BookStoreApi.DbOperations;
using System.Security.AccessControl;

namespace BookStoreApi.BookOperation.GetBooks
{
    public class GetBooksQuery(BookStoreDbContext dbContext,IMapper mapper)
    {
        private readonly IMapper _mapper = mapper;
        private readonly BookStoreDbContext _dbContex = dbContext;

        public List<BooksViewModel> Handle()
        {
            var bookList = _dbContex.Books.OrderBy(x => x.Id).ToList();
            List<BooksViewModel> vm = _mapper.Map<List<BooksViewModel>>(bookList);
            return vm;

            //foreach (var book in bookList)
            //{
            //    vm.Add(new BooksViewModel()
            //    {
            //        Title = book.Title,
            //        Genre = ((GenreEnum)book.GenreId).ToString(),
            //        PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy"),
            //        PageCount = book.PageCount
            //    });
            //}


        }
        public class BooksViewModel 
        {
            public string? Title { get; set; }
            public int PageCount { get; set; }
            public string? PublishDate { get; set; }
            public string? Genre { get; set; }

        }
    }
}
