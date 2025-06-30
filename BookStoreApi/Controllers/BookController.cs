using AutoMapper;
using BookStoreApi.BookOperation.CreateBook;
using BookStoreApi.BookOperation.DeleteBook;
using BookStoreApi.BookOperation.GetBookDetail;
using BookStoreApi.BookOperation.GetBooks;
using BookStoreApi.BookOperation.UpdateBook;
using BookStoreApi.DbOperations;
using Microsoft.AspNetCore.Mvc;
using static BookStoreApi.BookOperation.CreateBook.CreateBookCommand;
using static BookStoreApi.BookOperation.GetBookDetail.GetBookDetailQuery;
using static BookStoreApi.BookOperation.UpdateBook.UpdateBookCommand;

namespace BookStoreApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController(BookStoreDbContext context,IMapper mapper) : ControllerBase
    {   private readonly BookStoreDbContext _context = context;
        private readonly IMapper _mapper = mapper;

        //private static List<Book> BookList = new List<Book>()
        //{
        //    new Book{ Id=1, Name = "Ulysses", GenreId=1, PageCount=652,PublishDate =new DateTime(1920,02,02) },
        //    new Book{ Id=1, Name = "Faust", GenreId=2, PageCount=354,PublishDate =new DateTime(1829,01,19) },
        //    new Book{ Id=1, Name = "Suç ve Ceza", GenreId=3, PageCount=424,PublishDate =new DateTime(1866,01,01)},
        //    new Book{ Id=1, Name = "Demir Ökçe", GenreId=4, PageCount=380,PublishDate =new DateTime(1907,01,01) }
        //};
        [HttpGet]
        public IActionResult GetBooks() 
        {
            GetBooksQuery query= new GetBooksQuery(_context,_mapper);
            var result = query.Handle();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            BookDetailViewModel result;
            
            try
            {
                GetBookDetailQuery query = new(_context,_mapper)
                {
                    BookId = id
                };
                result= query.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok(result);

           
            //var book = _context.Books.Where(book=> book.Id == id).ToList(); 
            //return book;
        }
        //[HttpGet]  //Ýki tane HttpGet çaðrýsý olamaz

        //public List<Book> Get([FromQuery] string id)
        //{
        //    var book = BookList.Where(book => book.Id == Convert.ToInt32(id)).ToList();
        //    return book;
        //}
        //post
        [HttpPost]  
        public IActionResult AddBook([FromBody] CreateBookModel NewBook) 
        {
            CreateBookCommand command = new(_context,_mapper);
            try
            {
                command.Model = NewBook;
                command.Handle();

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
            
            return Ok();
        
        }
        //put
        [HttpPut("{id}")]
        public IActionResult UpdateBook (int id, [FromBody] UpdateBookModel updatedBook)
        {
            try
            {
                UpdateBookCommand command = new(_context);
                command.BookId = id;
                command.Model = updatedBook;
                command.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            

            return Ok();

            //var book = _context.Books.SingleOrDefault( x => x.Id == id);
            //if(book is null) { return BadRequest(); }

            //book.GenreId = UpdatedBook.GenreId != default ? UpdatedBook.GenreId : book.GenreId;
            //book.PageCount = UpdatedBook.PageCount != default ? UpdatedBook.PageCount : book.PageCount;
            //book.PublishDate= UpdatedBook.PublishDate != default ? UpdatedBook.PublishDate : book.PublishDate;
            //book.Title= UpdatedBook.Title != default ? UpdatedBook.Title : book.Title;
            //_context.SaveChanges();


        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            try
            {
                DeleteBookCommand command = new DeleteBookCommand(_context);
                command.BookId = id;
                command.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }

            //var book = _context.Books.SingleOrDefault(x => x.Id == id);
            //if (book is null) { return BadRequest(); }
            //_context.Books.Remove(book);
            //_context.SaveChanges();
            return Ok();
        }






    }
}
