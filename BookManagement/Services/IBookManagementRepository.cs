using BookManagement.DTO;
using BookManagement.Model;

namespace BookManagement.Services
{
    public interface IBookManagementRepository
    {
        string AddBook(BookDto book);
        List<Book> GetBooks();
        string DeleteBook(int bookId);
        Task<Book> UpdateBook(BookDto bookDto);
        Task<Book> GetBookById(int bookId);
    }
}
