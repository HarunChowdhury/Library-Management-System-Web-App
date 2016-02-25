using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DropDownListPractice.DAL.Gateway;
using DropDownListPractice.Models;

namespace DropDownListPractice.BLL
{
    public class BookBLL
    {
        private BookGateway aBookGateWay;
        private Book aBook;
        private List<Book> books;
        public List<Book> GetAllBooks()
        {
            aBookGateWay = new BookGateway();
            return aBookGateWay.GetAllBook();
        }

   
        public Book GetBookByTitle(string title)
        {
            aBook = new Book();
            aBookGateWay = new BookGateway();

           aBook=aBookGateWay.GetBookByTitle(title);
            return aBook;


        }

        public List<Book> GetAllBooksByNumber(string number)
        {
            aBookGateWay = new BookGateway();
            books = new List<Book>();
            books = aBookGateWay.GetAllBooksByNumber(number);
            return books;
        }
    }
}