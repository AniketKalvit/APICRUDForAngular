using APICRUDForAngular.Models;

namespace APICRUDForAngular.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooks();
        Task<Book> GetBookById(int id);
        Task<int> AddBook(Book book); 
        Task<int> UpdateBook(Book book);
        Task<int> DeleteBook(int id);
    }
}
