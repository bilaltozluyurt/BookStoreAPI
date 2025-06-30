using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookStoreApi.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new BookStoreDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>());
            if (context.Books.Any()) return;

            context.Books.AddRange(
                new Book
                { //Id = 1,
                    Title = "Ulysses",
                    GenreId = 3,
                    PageCount = 652,
                    PublishDate = new DateTime(1920, 02, 02)
                },
                new Book
                { //Id = 2,
                    Title = "Faust",
                    GenreId = 2,
                    PageCount = 354,
                    PublishDate = new DateTime(1829, 01, 19)
                },
                new Book
                { //Id = 3,
                    Title = "Suç ve Ceza",
                    GenreId = 3,
                    PageCount = 424,
                    PublishDate = new DateTime(1866, 01, 01)
                },
                new Book
                { //Id = 4,
                    Title = "Demir Ökçe",
                    GenreId =3 ,
                    PageCount = 380,
                    PublishDate = new DateTime(1907, 01, 01)
                }
            );

            context.SaveChanges();
        }
    }
}
