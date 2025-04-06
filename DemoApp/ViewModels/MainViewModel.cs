using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using BookLibraryApp.Models;
using BookLibraryApp.Services;

namespace BookLibraryApp
{
    public partial class MainViewModel : ObservableObject
    {

        [ObservableProperty]
        private string newTitle = string.Empty;

        [ObservableProperty]
        private string newAuthor = string.Empty;

        [ObservableProperty]
        private string newYear = string.Empty;

        private MyLinkedList<Book> _bookList = new();
        private readonly IExportService _exportService;

        [ObservableProperty]
        private ObservableCollection<Book> books = new();

        [ObservableProperty]
        private string searchResult = string.Empty;

        public MainViewModel() : this(new ExportService()) { }

        public MainViewModel(IExportService exportService)
        {
            _exportService = exportService;
            RefreshBooks();
        }

        [RelayCommand]
        private void AddBook()
        {
            if (int.TryParse(NewYear, out int parsedYear))
            {
                var book = new Book
                {
                    Title = NewTitle,
                    Author = NewAuthor,
                    Year = parsedYear
                };

                _bookList.Add(book);
                RefreshBooks();

                // Optional: clear input
                NewTitle = "";
                NewAuthor = "";
                NewYear = "";
            }
            else
            {
                SearchResult = "Invalid year.";
            }
        }


        [RelayCommand]
        private void SearchBook(string title)
        {
            var result = _bookList.Find(b => b.Title.ToLower() == title.ToLower());
            SearchResult = result != null ? $"Found: {result.Title} by {result.Author}" : "Book not found.";
        }

        [RelayCommand]
        private void Export()
        {
            string path = "books_export.csv";
            _exportService.ExportBooks(_bookList.ToList(), path);
        }

        private void RefreshBooks()
        {
            Books = new ObservableCollection<Book>(_bookList.ToList());
        }
    }
}
