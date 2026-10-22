using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryRazorApp.Models
{
    [Table("readers")]
    public class Reader
    {
        [Key]
        [Column("Id")]
        public int ID { get; set; }

        [Column("TicketNumber")]
        [Required(ErrorMessage = "Вкажіть номер квитка")]
        [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Номер квитка має бути додатним числом")]
        public string TicketNumber { get; set; } = string.Empty;

        [Column("FullName")]
        [Required(ErrorMessage = "Введіть ПІБ читача")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "ПІБ має містити від 3 до 100 символів")]
        public string FullName { get; set; } = string.Empty;

        [Column("Email")]
        [EmailAddress(ErrorMessage = "Некоректний формат Email")]
        public string? Email { get; set; }

        [Column("Address")]
        public string? Address { get; set; }

        [Column("Phone")]
        public string? Phone { get; set; }

        public List<Loan> Loans { get; set; } = new();
    }
}