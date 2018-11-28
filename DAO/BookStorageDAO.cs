using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoQuanLyThuVien.DAO
{
    public class BookStorageDAO
    {
        private static BookStorageDAO instance;

        public static BookStorageDAO Instance
        {
            get { if (instance == null) instance = new BookStorageDAO(); return BookStorageDAO.instance; }
            private set { BookStorageDAO.instance = value; }
        }
        public BookStorageDAO() { }
    }
}
