using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DemoQuanLyThuVien.DAO;

namespace UnitTestProject1
{
    /// <summary>
    /// Summary description for TestSumthing
    /// </summary>
    [TestClass]
    public class TestSumthing
    {





        public TestSumthing()
        {
            
        }
        #region Additional test attributes
        #endregion

        [TestMethod]
        public void TestLogin1()
        {
            string userName = "asd";
            string passWord = "123";
            bool actual = AccountDAO.Instance.Login(userName,passWord);

            Assert.AreEqual(false,actual);
        }

    }
}
