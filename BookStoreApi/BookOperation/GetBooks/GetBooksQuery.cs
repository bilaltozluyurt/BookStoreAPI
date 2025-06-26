using BookStoreApi.Common;
using BookStoreApi.DbOperations;

namespace BookStoreApi.BookOperation.GetBooks
{
    public class GetBooksQuery(BookStoreDbContext dbContext)
    {
        private readonly BookStoreDbContext _dbContex = dbContext;

        public List<BooksViewModel> Handle()
        {
            var bookList = _dbContex.Books.OrderBy(x => x.Id).ToList();
            List<BooksViewModel> vm = [];

            foreach (var book in bookList)
            {
                vm.Add(new BooksViewModel()
                {
                    Title = book.Title,
                    Genre = ((GenreEnum)book.GenreId).ToString(),
                    PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy"),
                    PageCount = book.PageCount
                });
            }

            return vm; 
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
