using System.Collections.Generic;
using BookLibraryApp.Models;

namespace BookLibraryApp.Services
{
    public interface IExportService
    {
        void ExportBooks(IEnumerable<Book> books, string filePath);
    }
}
