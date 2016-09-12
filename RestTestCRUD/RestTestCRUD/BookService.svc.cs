using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RestTestCRUD
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BookService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select BookService.svc or BookService.svc.cs at the Solution Explorer and start debugging.
    public class BookService : IBookService
    {
        static IBookRepository repository = new BookRepository();

        public List<Book> GetBookList()
        {
            return repository.GetAllBooks();    
        }

        public Book GetBookById(string id)
        {
            return repository.GetBookById(int.Parse(id));
        }

        public string AddBook(Book book)
        {
            Book newBook = repository.AddNewBook(book);
            return "id=" + newBook.BookId;
        }

        public string UpdateBook(Book book)
        {
            bool updated = repository.UpdateABook(book);
            if (updated)
                return "Book with id = " + book.BookId + "updated successfully";
            else
                return "Unable to update book with id = " + book.BookId;
        }



        public string DeleteBook(string id)
        {
            bool deleted = repository.DeleteABook(int.Parse(id));
            if (deleted)
                return "Book with id = " + id + "deleted successfully";
            else
                return "Unable to delete book with id = " + id;
        }






    }
}
