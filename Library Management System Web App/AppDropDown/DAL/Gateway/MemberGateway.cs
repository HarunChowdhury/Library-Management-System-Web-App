using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DropDownListPractice.Models;
using LibraryDonNetApp;

namespace DropDownListPractice.DAL.Gateway
{
    public class MemberGateway:Gateway
    {
        public MemberGateway()
            : base("ConnecString")
        {

        }

        public bool IsExistsNumber(string number)
        {
            Connection.Open();
            string query = "SELECT * FROM Member WHERE Number='"+number+"'";

            Command.CommandText = query;
            SqlDataReader aReader = Command.ExecuteReader();
            bool hasRows = aReader.HasRows;                   
            Connection.Close();         
            return hasRows;
           
        }

        public string Save(Book aBook, string number)
        {
            Connection.Open();
            string query = "INSERT INTO BorrowBook VALUES('" + number + "','" + aBook.Title + "','" + aBook.Author + "','" + aBook.Publisher + "')";
            Command.CommandText = query;

            int affectedRows = Command.ExecuteNonQuery();
            Connection.Close();
            if (affectedRows>0)
            {
                return "This Book is Borrowed By member whose number is: "+number;
            }
            else
            {
                return "Something Problem ";
            }

        }
    }
}