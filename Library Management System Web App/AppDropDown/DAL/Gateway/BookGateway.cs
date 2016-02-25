using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DropDownListPractice.Models;

namespace DropDownListPractice.DAL.Gateway
{
    public class BookGateway:Gateway
    {
        public BookGateway()
            : base("ConnecString")
        {

        }

        public List<Book> GetAllBook()
        {

            List<Book> books = new List<Book>();

            var query = "SELECT * FROM Book";

            Command.CommandText = query;

            Connection.Open();
            SqlDataReader dataReader = Command.ExecuteReader();

            while (dataReader.Read())
            {
                Book aBook = new Book();


                aBook.Title = dataReader["Title"].ToString();
                aBook.Author = dataReader["Author"].ToString();
                aBook.Publisher = dataReader["Publisher"].ToString();
                aBook.Id = Convert.ToInt32(dataReader["ID"]);

                books.Add(aBook);
            }

            dataReader.Close();
            Connection.Close();

            return books;
        }

        public Book GetBookByTitle(string title)
        {
           Connection.Open();
           Book aBook = new Book();
            var query="SELECT *  FROM Book WHERE Title='"+title+"'";
            Command.CommandText = query;
            SqlDataReader aReader = Command.ExecuteReader();

            while (aReader.Read())
            {
                aBook.Author = aReader["Author"].ToString();
                aBook.Publisher = aReader["Publisher"].ToString();
            }
            aReader.Close();
            Connection.Close();
            return aBook;

        }

        public List<Book> GetAllBooksByNumber(string number)
        {
            Connection.Open();
          
            var query = "SELECT * FROM BorrowBook WHERE MemberNo='" + number + "'";
            Command.CommandText = query;
            SqlDataReader aReader = Command.ExecuteReader();
            List<Book> books = new List<Book>();
            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                        Book aBook = new Book();
                        aBook.Title = aReader["BookName"].ToString();
                        books.Add(aBook);
                            
                }   
            }
            
            aReader.Close();
            Connection.Close();
            return books;
        }
    }
}