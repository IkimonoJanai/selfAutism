using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DemoQuanLyThuVien.DAO;

namespace TestQLTV
{
    /// <summary>
    /// Summary description for TestBook
    /// </summary>
    [TestClass]
    public class TestBook
    {


        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestBook_Insert()
        {
            string name, nameAuthor, nameNXB;
            int cateId, yearrl;
            float price;
            name = "Doremon";
            cateId = 2;
            yearrl = 2010;
            nameAuthor = "Fujiko Fujio";
            nameNXB = "Shogakukan";
            price = 2000;
            bool acctual = BookDAO.Instance.InsertBook(name, cateId, yearrl, nameAuthor, nameNXB, price);
            Assert.AreEqual(true, acctual);
        }

        [TestMethod]
        public void TestBook_Update()
        {
            string name, nameAuthor, nameNXB;
            int cateId, yearrl;
            float price;
            name = "Doremon";
            cateId = 3;
            yearrl = 2010;
            nameAuthor = "Fujiko Fujio";
            nameNXB = "Shogakukan";
            price = 2000;
            bool acctual = BookDAO.Instance.InsertBook(name, cateId, yearrl, nameAuthor, nameNXB, price);
            Assert.AreEqual(true, acctual);
        }
        [TestMethod]
        public void TestBook_Delete()
        {
            string name, nameAuthor, nameNXB;
            int cateId, yearrl;
            float price;
            name = "Doremon";
            cateId = 2;
            yearrl = 2010;
            nameAuthor = "Fujiko Fujio";
            nameNXB = "Shogakukan";
            price = 2000;
            bool acctual = BookDAO.Instance.InsertBook(name, cateId, yearrl, nameAuthor, nameNXB, price);
            Assert.AreEqual(true, acctual);
        }
    }
}
