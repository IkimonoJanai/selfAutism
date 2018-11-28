using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DemoQuanLyThuVien.DAO;

namespace TestQLTV
{
    /// <summary>
    /// Summary description for TestLogin
    /// </summary>
    [TestClass]
    public class TestLogin
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
        public void TestLoginAdmin()
        {
            string user, pass;
            user = "GiaLai";
            pass = "123";
            bool acctual = AccountDAO.Instance.Login(user, pass);

            Assert.AreEqual(true, acctual);
        }
        [TestMethod]
        public void TestLogin_SaiUser()
        {
            string user, pass;
            user = "dna";
            pass = "123";
            bool acctual = AccountDAO.Instance.Login(user, pass);

            Assert.AreEqual(false, acctual);
        }
        [TestMethod]
        public void TestLogin_SaiPass()
        {
            string user, pass;
            user = "GiaLai";
            pass = "111";
            bool acctual = AccountDAO.Instance.Login(user, pass);

            Assert.AreEqual(false, acctual);
        }
        [TestMethod]
        public void TestLogin_TrongUser()
        {
            string user, pass;
            user = "";
            pass = "123";
            bool acctual = AccountDAO.Instance.Login(user, pass);

            Assert.AreEqual(false, acctual);
        }
        [TestMethod]
        public void TestLogin_TrongPass()
        {
            string user, pass;
            user = "GiaLai";
            pass = "";
            bool acctual = AccountDAO.Instance.Login(user, pass);

            Assert.AreEqual(false, acctual);
        }
        [TestMethod]
        public void TestLogin_SaiUserPass()
        {
            string user, pass;
            user = "zxc";
            pass = "111";
            bool acctual = AccountDAO.Instance.Login(user, pass);

            Assert.AreEqual(false, acctual);
        }
        [TestMethod]
        public void TestLoginUser()
        {
            string user, pass;
            user = "16510100451";
            pass = "111";
            bool acctual = AccountDAO.Instance.Login(user, pass);

            Assert.AreEqual(false, acctual);
        }
        [TestMethod]
        public void TestLogin_UserPassTrong()
        {
            string user, pass;
            user = "";
            pass = "";
            bool acctual = AccountDAO.Instance.Login(user, pass);

            Assert.AreEqual(false, acctual);
        }
    }
}
