using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library.IOCContainer;
using Library.Web.Models;

namespace Library.Web.Tests.Controllers
{
    [TestClass]
    public class BorrowersTest
    {
        public static bool isInitailized = false;


        public BorrowersTest()
        {
            //Data should be initialzed one
            if (!isInitailized)
            {
                Common.InMemoryOperations.InitializeDataList();
                LibraryUnityManager.Register();
            }
            isInitailized = true;
        }


         [TestMethod]
        public void AddNewBorrower()
        {

            BorrowersModel classObj = new BorrowersModel();
            BorrowersModel obj = new BorrowersModel();
            obj.FirstName = "FirstName";
            obj.LastName = "Last Name";
            Assert.IsTrue(classObj.AddBorrower(obj));
        }


        [TestMethod]
        public void GetAllBorrower()
        {            
            // Arrange
            BorrowersModel model = new BorrowersModel();
            Common.SearchCriteria obj = new Common.SearchCriteria();
            obj.StartIndex = 0;
            obj.EndIndex = 10;
            obj.Text = string.Empty;
            Assert.IsNotNull(model.GetAllBorrowers(obj));
            Assert.AreEqual(10, model.GetAllBorrowers(obj).Count);
        }


    }
}
