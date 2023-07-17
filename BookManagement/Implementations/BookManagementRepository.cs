using BookManagement.DatabaseContext;
using BookManagement.DTO;
using BookManagement.Model;
using BookManagement.Services;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Implementations
{
    public class BookManagementRepository : IBookManagementRepository
    {
        private readonly ApplicationConext _conext;
        public BookManagementRepository(ApplicationConext conext)
        {
            _conext = conext;
        }
        public string AddBook(BookDto book)
        {
            var addBook = new Book
            {
                Name = book.Name,
                Author = book.Author,
                PublishedDate = book.PublishedDate,
                BookStatus = BookStatus.Published,
            };

            _conext.Books.Add(addBook);
            var saveChanges = _conext.SaveChanges();
            
            if(saveChanges > 0)
            {
                return "Book successfully added to the db";
            }

            return "Book failed to add to the db";
        }

        public string DeleteBook(int bookId)
        {
            var book = _conext.Books.FirstOrDefault(x => x.Id == bookId);

            if (book == null)
                return "Book does not exist";

            _conext.Books.Remove(book);
            _conext.SaveChanges();
            return $"{book.Name} has been deleted from the database";
        }

        public async Task<Book> GetBookById(int bookId)
        {
            var book = await _conext.Books?.FirstOrDefaultAsync(x => x.Id == bookId);

            if(book == null)
            {
                return null;
            }
            return book;
            
        }

        public List<Book> GetBooks()
        {
            var books =  _conext.Books.ToList();
            return books;
        }

        public async Task<Book> UpdateBook(BookDto bookDto)
        {
            var book = await _conext.Books?.FirstOrDefaultAsync(x => x.Name == bookDto.Name);
            if (book == null)
            {
                return null;
            }
            book.Author = bookDto.Author;
            book.Name = bookDto.Name;
            book.PublishedDate = bookDto.PublishedDate;

            _conext.Books.Update(book);
            _conext.SaveChanges();

            return book;
        }
    }
}
