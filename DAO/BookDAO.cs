using DemoQuanLyThuVien.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DemoQuanLyThuVien.DAO
{
    public class BookDAO
    {
        private static BookDAO instance;

        public static BookDAO Instance
       {
           get { if (instance == null) instance = new BookDAO(); return BookDAO.instance; }
           private set { BookDAO.instance = value; }
       }
        private BookDAO() { }
        // public get book by category id

        public List<Book> getBookById(int id) 
        {
            List<Book> list = new List<Book>();
            string sql = "SELECT * FROM Book WHERE idCategory = " + id;
            
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);

            foreach (DataRow item in data.Rows)
            {
                Book book = new Book(item);
                list.Add(book);
            }
            return list;
        }

        public List<Book> getBook()
        {
            List<Book> list = new List<Book>();
            string sql = "SELECT * FROM Book";

            DataTable data = DataProvider.Instance.ExecuteQuery(sql);

            foreach (DataRow item in data.Rows)
            {
                Book book = new Book(item);
                list.Add(book);
            }
            return list;
        }
        //name , cateId , yearrl , nameAuthor , nameNXB , price
        /*
         public bool InsertBook(int cateId, string name, int SL , int yearrl, string nameAuthor, string nameNXB, float price , string Pic)
        {
            string sql = string.Format("INSERT dbo.Book( idCategory , name , quantity , releaseYear , nameAuthor , nameNXB , price , bookPic ) VALUES  ( {0} , N'{1}' , {2} , {3} , N'{4}' , N'{5}' , {6} , N'{7}' )", cateId, name, SL, yearrl, nameAuthor, nameNXB, price, Pic);
            int result = DataProvider.Instance.ExecuteNonQuery(sql);

            return  result > 0;
        }

        public bool UpdateBook(int idBook, int cateId, string name, int SL, int yearrl, string nameAuthor, string nameNXB, float price, string Pic)
        {
            string sql = string.Format("UPDATE dbo.Book SET idCategory = {0} , name = N'{1}' , quantity = {2} , releaseYear = {3} , nameAuthor = N'{4}' , nameNXB = N'{5}' , price = {6} , bookPic = N'{7}' WHERE id = {8} ", cateId, name, SL, yearrl, nameAuthor, nameNXB, price, Pic );
            int result = DataProvider.Instance.ExecuteNonQuery(sql);

            return result > 0;
        }
         * */
        public bool InsertBook(int cateId, string name, int SL, int yearrl, string nameAuthor, string nameNXB, float price, string Pic)
        {
            string sql = string.Format("INSERT dbo.Book( idCategory , name , quantity , releaseYear , nameAuthor , nameNXB , price , bookPic ) VALUES  ( {0} , N'{1}' , {2} , {3} , N'{4}' , N'{5}' , {6} , N'{7}' )", cateId, name, SL, yearrl, nameAuthor, nameNXB, price, Pic);
            int result = DataProvider.Instance.ExecuteNonQuery(sql);

            return result > 0;
        }

        public bool UpdateBook(int idBook, int cateId, string name, int SL, int yearrl, string nameAuthor, string nameNXB, float price, string Pic)
        {
            string sql = string.Format("UPDATE dbo.Book SET idCategory = {0} , name = N'{1}' , quantity = {2} , releaseYear = {3} , nameAuthor = N'{4}' , nameNXB = N'{5}' , price = {6} , bookPic = N'{7}' WHERE id = {8} ", cateId, name, SL, yearrl, nameAuthor, nameNXB, price, Pic ,idBook);
            int result = DataProvider.Instance.ExecuteNonQuery(sql);

            return result > 0;
        }
        public bool DeleteBookById(int idBook)
        {
            //billinfoDAO
            string sql = string.Format("DELETE Book WHERE id = {0}", idBook);
            int result = DataProvider.Instance.ExecuteNonQuery(sql);

            return result > 0;
        }
    }
}
