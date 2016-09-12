using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestTestCRUD
{
    interface IBookRepository
    {
        List<Book> GetAllBooks();
        Book GetBookById(int id);
        Book AddNewBook(Book item);
        bool DeleteABook(int id);
        bool UpdateABook(Book item);
    }
}
