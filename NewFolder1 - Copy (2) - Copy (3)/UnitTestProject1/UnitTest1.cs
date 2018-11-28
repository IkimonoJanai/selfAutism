using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DemoQuanLyThuVien.DAO;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

        }
        [TestMethod]
        public void TestBook_Insert()
        {
            string name, nameAuthor, nameNXB , Pic;
            int cateId, yearrl , SL;
            float price;
            name = "Doremon";
            cateId = 2;
            yearrl = 2010;
            SL = 1;
            nameAuthor = "Fujiko Fujio";
            nameNXB = "Shogakukan";
            price = 2000;
            Pic = "LN_Index_1.jpg";
            // idBook, cateId, name, SL, yearrl, nameAuthor, nameNXB, price, Pic
            bool acctual = BookDAO.Instance.InsertBook(cateId, name, SL, yearrl, nameAuthor, nameNXB, price, Pic);
            Assert.AreEqual(true, acctual);
        }
        [TestMethod]
        public void TestBook_Update()
        {
            string name, nameAuthor, nameNXB, Pic;
            int cateId, yearrl, SL, idBook;
            float price;
            idBook = 1;
            name = "Doremon 98";
            cateId = 3;
            yearrl = 2018;
            SL = 500;
            nameAuthor = "Fujiko Fujio gay";
            nameNXB = "Shogakukan con meo";
            price = 992000;
            Pic = "LN_Index_2.jpg";
            //idBook, cateId, name, SL, yearrl, nameAuthor, nameNXB, price, Pic)
            bool acctual = BookDAO.Instance.UpdateBook(idBook, cateId, name, SL, yearrl, nameAuthor, nameNXB, price, Pic);
            Assert.AreEqual(true, acctual);
        }
        [TestMethod]
        public void TestBook_DeleteIdBook()
        {
            int idBook;
            idBook = 7;
            var actual = BookDAO.Instance.DeleteBookById(idBook);
            Assert.AreEqual(true,actual);
        }




    }
}
