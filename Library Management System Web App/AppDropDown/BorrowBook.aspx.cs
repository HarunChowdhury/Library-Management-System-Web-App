using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppDropDown.BLL;
using DropDownListPractice.BLL;
using DropDownListPractice.Models;

namespace AppDropDown
{
    public partial class BorrowBook : System.Web.UI.Page
    {
        private MemberBLL aMemberBll;
        private BookBLL aBookBll;
        private Book aBook;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                aBook = new Book();
                aBookBll = new BookBLL();


                List<Book> books = aBookBll.GetAllBooks();

                selectBookDropDownList.DataTextField = "Title";
                selectBookDropDownList.DataValueField = "Id";
                selectBookDropDownList.DataSource = books;


                selectBookDropDownList.DataBind();
            }

        }

        private string author;
        private string publisher;
        private string title;
        protected void selectBookDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
              aBook = new Book();
             aBookBll = new BookBLL();
             title = selectBookDropDownList.SelectedItem.Text;

            aBook = aBookBll.GetBookByTitle(title);

            authorTextBox.Text = aBook.Author;
            publisherTextBox.Text = aBook.Publisher;

            aBook.Title = title;
            author = aBook.Author;
            publisher = aBook.Publisher;
        }

        protected void borrowButton_Click(object sender, EventArgs e)
        {
            aBook = new Book();
            aMemberBll = new MemberBLL();
            aBook.Title =selectBookDropDownList.SelectedItem.Text;
            aBook.Author = authorTextBox.Text;
            aBook.Publisher = publisherTextBox.Text;
           string number=numberTextBox.Text;
           string msg =aMemberBll.CheckAndSaveBorrowBook(aBook,number);

            messageLabel.Text = msg;

        }

        protected void showSelectedNumBooksButton_Click(object sender, EventArgs e)
        {
            List<Book> books = new List<Book>();
             aBook = new Book();
             aBookBll = new BookBLL();
           
            borrowedBookListDropDownList.DataTextField = "Title";
            string number = memberNumberTextBox0.Text;
           books = aBookBll.GetAllBooksByNumber(number);
            borrowedBookListDropDownList.Items.Clear();
            foreach (var book1 in books)
            {
                borrowedBookListDropDownList.Items.Add(book1.Title);
            }


        }

        protected void returnButton_Click(object sender, EventArgs e)
        {

        }
    }
}