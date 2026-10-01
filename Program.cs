// using System;
// using System.Linq;
// using Microsoft.EntityFrameworkCore;

// namespace LibraryConsoleApp
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             Console.OutputEncoding = System.Text.Encoding.UTF8;

//             using (var db = new LibraryContext())
//             {
//                 // 1. Отримання ВСІХ читачів
//                 Console.WriteLine("=== ВСІ ЧИТАЧІ ===");
//                 var readers = db.Readers.ToList();
                
//                 foreach (var r in readers)
//                 {
//                     Console.WriteLine($"TicketNumber: {r.TicketNumber} | FullName: {r.FullName} | Address: {r.Address} | Phone: {r.Phone} |");
//                 }

//                 // 2. Історія видачі (LINQ-запит замість JOIN SQL)
//                 Console.WriteLine("\n=== ІСТОРІЯ ВИДАЧІ ===");
//                 var loans = db.Loans
//                     .Include(l => l.Reader)
//                     .Include(l => l.Book)
//                     .Select(l => new
//                     {
//                         FullName = l.Reader.FullName,
//                         Title = l.Book.Title,
//                         IssueDate = l.IssueDate,
//                         Returned = l.ReturnDate.HasValue ? l.ReturnDate.Value.ToString("yyyy-MM-dd") : "Ще в читача"
//                     })
//                     .ToList();

//                 foreach (var item in loans)
//                 {
//                     Console.WriteLine($"FullName: {item.FullName} | Title: {item.Title} | IssueDate: {item.IssueDate:yyyy-MM-dd} | Returned: {item.Returned} |");
//                 }
//             }
//         }
//     }
// }
