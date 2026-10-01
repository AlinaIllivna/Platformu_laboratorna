using System.ComponentModel.DataAnnotations;

namespace LibraryMvcApp.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Display(Name = "Назва")]
        public string Title { get; set; } = string.Empty;

        [Display(Name = "Автор")]
        public string Author { get; set; } = string.Empty;

        [Display(Name = "Рік видання")]
        public int Year { get; set; }
    }
}