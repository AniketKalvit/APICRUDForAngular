using APICRUDForAngular.Data;
using APICRUDForAngular.Models;
using Microsoft.EntityFrameworkCore;

namespace APICRUDForAngular.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext db;
        public BookRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<int> AddBook(Book book)
        {
            int result = 0;
             await db.Books.AddAsync(book);
           result=  await db.SaveChangesAsync();
            return result;
        }

        public async Task<int> DeleteBook(int id)
        {
            int result = 0;
            var book = await db.Books.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (book != null)
            {
                db.Books.Remove(book);
               result=  await db.SaveChangesAsync();
            }
            return result;
        }

        public async Task<Book> GetBookById(int id)
        {
            var book = await db.Books.Where(x => x.Id == id).FirstOrDefaultAsync();
            return book;
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await db.Books.ToListAsync();
        }

        public async Task<int> UpdateBook(Book book)
        {
            int result = 0;
            var b = await db.Books.Where(x => x.Id == book.Id).FirstOrDefaultAsync();
            if (b != null)
            {
                b.Name = book.Name;
                b.Author = book.Author;
                b.Price = book.Price;
                result = await db.SaveChangesAsync();
            }
            return result;
        }
    }
}
