using BookStoreApi.DbOperations;

namespace BookStoreApi.BookOperation.UpdateBook
{
    public class UpdateBookCommand(BookStoreDbContext context)
    {
        private readonly BookStoreDbContext _context = context;
        public int BookId { get; set; }
        public UpdateBookModel? Model { get; set; }
        public void Handle()
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == BookId);
            if (book is null) { throw new InvalidOperationException("Güncellenecek Kitap Bulunamadı"); }


            book.GenreId = Model?.GenreId != default ? Model.GenreId : book.GenreId;
           
            book.Title = Model?.Title != default ? Model.Title : book.Title;
            _context.SaveChanges();

        }
        public class UpdateBookModel 
        {
            public string? Title { get; set; }
            public int GenreId { get; set; }


        }
    }
}
