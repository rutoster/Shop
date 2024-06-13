using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace BooksStoreDAL
{
    public class DBConnection
    {
        public List<BookDetails> GetAllBooks()
        {
            string conStr =
                ConfigurationManager.ConnectionStrings["Shop"].ConnectionString;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = conStr;


            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandText = "SELECT * from Customer";

            SqlDataReader reader;

            List<BookDetails> listOfBooks = new List<BookDetails>();
            try
            {
                con.Open();

                reader = com.ExecuteReader();

                while (reader.Read())
                {
                    int id = int.Parse(reader["Id"].ToString());
                    string name = reader["FirstName"].ToString();
                    string LastName = reader["LastName"].ToString();
                    string City = reader["City"].ToString();
                    string Country = reader["Country"].ToString();
                    string Phone = reader["Phone"].ToString();
                    var newBook = new BookDetails(id, name, LastName, City, Country, Phone);
                    listOfBooks.Add(newBook);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return listOfBooks;
        }
        public bool AddNewBook(BookDetails book)
        {
            bool res = false;
            string conStr =
               ConfigurationManager.ConnectionStrings["Shop"].ConnectionString;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = conStr;


            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandText = string.Format("INSERT INTO Shop (Id, FirstName, LastName, City, Country, Phone) VALUES ('{0}', N'{1}', N'{2}', N'{3}', N'{4}', '{5}')"
                , book.Id, book.FirstName, book.LastName, book.City, book.Country, book.Phone);
            try
            {
                con.Open();
                int numberRow = com.ExecuteNonQuery();
                if (numberRow > 0)
                {
                    res = true;
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
            return res;
        }
        //string filePath = Directory.GetCurrentDirectory() + @"\..\..\..\Src\BookList.txt";
        //public List<BookDetails> ReadAllBooks()
        //{
        //    var allLines = File.ReadAllLines(filePath);
        //    List<BookDetails> listOfBooks = new List<BookDetails>();
        //    foreach (var text in allLines)
        //    {
        //        string [] detailsAsString = text.Split(',');
        //        int id = int.Parse(detailsAsString[0]);
        //        string name = detailsAsString[1];
        //        int price = int.Parse(detailsAsString[2]);
        //        int numberOfPages = int.Parse(detailsAsString[3]);
        //        int minAge = int.Parse(detailsAsString[4]);
        //        int maxAge = int.Parse(detailsAsString[5]);
        //        bool isComics = bool.Parse(detailsAsString[6]);
        //        var newBook = new BookDetails(id, name, price, numberOfPages,
        //            minAge, maxAge, isComics);
        //        listOfBooks.Add(newBook);
        //    }
        //    return listOfBooks;
        //}
    }
}