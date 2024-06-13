using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BooksStoreDAL;
using Entities;

namespace BooksStoreBL
{
    public class BookStoreBL
    {
        List<BookDetails> ListOfBooks;
        DBConnection fileConnection;
        public BookStoreBL()
        {
            fileConnection = new DBConnection();
            ListOfBooks = fileConnection.GetAllBooks();
        }

        public IEnumerable<BookDetails> GetAllBooks()
        {
            return ListOfBooks;
        }
        public void AddNewBook(int id, string FName, string LName, string city, string country, string phone)
        {
            Entities.BookDetails b = new Entities.BookDetails(id, FName, LName, city, country, phone);
            fileConnection.AddNewBook(b);
        }
    }
}