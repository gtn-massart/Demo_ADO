using Demo_ADO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_ADO.Interfaces
{
    internal interface IBookRepository
    {
        IEnumerable<Book> GetAll();
        Book? GetById(int id);
        int Count();
        int create(Book b);
        bool Update(int id, Book b);
        bool delete(int id);
    }
}
