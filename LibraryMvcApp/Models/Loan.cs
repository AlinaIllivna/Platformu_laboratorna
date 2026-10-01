using System.ComponentModel.DataAnnotations;

namespace LibraryMvcApp.Models
{
    public class Loan
    {
        public int Id { get; set; }

        [Display(Name = "Книга")]
        public int BookId { get; set; }
        [Display(Name = "Книга")]
        public Book? Book { get; set; }

        [Display(Name = "Читач")]
        public int ReaderId { get; set; }
        [Display(Name = "Читач")]
        public Reader? Reader { get; set; }

        [Display(Name = "Дата видачі")]
        [DataType(DataType.Date)]
        public DateTime IssueDate { get; set; }

        [Display(Name = "Дата повернення")]
        [DataType(DataType.Date)]
        public DateTime? ReturnDate { get; set; }
    }
}