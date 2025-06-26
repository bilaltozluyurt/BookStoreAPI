using BookStoreApi.DbOperations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BookStoreApi.BookOperation.CreateBook
{
    public class CreateBookCommand(BookStoreDbContext dbContext)
    {
        public CreateBookModel? Model { get; set; }
        private readonly BookStoreDbContext _dbContext = dbContext;

        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Title == Model.Title);
            if (book is not null)
            {throw new InvalidOperationException("Kitap Zaten Mevcut");}
            book = new Book
            {
                Title = Model.Title,
                PublishDate = Model.PublishDate,
                PageCount = Model.PageCount,
                GenreId = Model.GenreId
            };
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
           

        }
        public class CreateBookModel
        {
            public string? Title { get; set; }
            public int GenreId { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate  { get; set; }
        }
    }
}
