using BookManagement.DTO;
using BookManagement.Model;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.DatabaseContext
{
    public class ApplicationConext : DbContext
    {
        public ApplicationConext(DbContextOptions options) : base(options){}

        public DbSet<Book> Books { get; set; }
    }
}
