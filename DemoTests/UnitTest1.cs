namespace DemoTests;

using BookLibraryApp.Models;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        MyLinkedList<Book> list = new MyLinkedList<Book>();
        var book = new Book
                {
                    Title = "Beloved",
                    Author = "Toni Morrison",
                    Year = 1987
                };

        list.Add(book);
        var result = list.Find(b => b.Title.ToLower() == "beloved");
        Assert.NotNull(result);


    }
}