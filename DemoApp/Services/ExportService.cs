using System.Collections.Generic;
using System.IO;
using System.Text;
using BookLibraryApp.Models;

namespace BookLibraryApp.Services
{
    public class ExportService : IExportService
    {
        public void ExportBooks(IEnumerable<Book> books, string filePath)
        {
            var sb = new StringBuilder();
            foreach (var book in books)
            {
                sb.AppendLine($"\"{book.Title}\",\"{book.Author}\",{book.Year}");
            }
            File.WriteAllText(filePath, sb.ToString());
        }
    }
}
