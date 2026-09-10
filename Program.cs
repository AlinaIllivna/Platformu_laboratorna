using System;
using MySql.Data.MySqlClient;

namespace LibraryConsoleApp
{
    class Program
    {
        private static string connectionString = "Server=localhost;Database=library_db;Uid=root;Pw=;";

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                // 1. Отримання ВСІХ читачів
                Console.WriteLine("=== ВСІ ЧИТАЧІ ===");
                ExecuteQuery(conn, "SELECT TicketNumber, FullName, Address, Phone FROM Readers");

                // 2. Історія видачі (виправлено b.BookID -> b.ID та r.ReaderID -> r.ID)
                Console.WriteLine("\n=== ІСТОРІЯ ВИДАЧІ ===");
                ExecuteQuery(conn, @"
                    SELECT r.FullName, b.Title, l.IssueDate, IFNULL(l.ReturnDate, 'Ще в читача') AS Returned
                    FROM Loans l
                    JOIN Readers r ON l.ReaderID = r.ID
                    JOIN Books b ON l.BookID = b.ID");
            }
        }

        static void ExecuteQuery(MySqlConnection conn, string sql)
        {
            using (var cmd = new MySqlCommand(sql, conn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                        Console.Write($"{reader.GetName(i)}: {reader[i]} | ");
                    Console.WriteLine();
                }
            }
        }
    }
}