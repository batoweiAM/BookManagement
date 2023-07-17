using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookManagement.Model
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Author { get; set; }
        public BookStatus BookStatus { get; set; }
        public DateTime PublishedDate { get; set; }
    }
    public enum BookStatus
    {
        Published = 1, Unpublished = 2

    }
}

