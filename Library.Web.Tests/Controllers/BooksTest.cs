using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library.Web;
using Library.Web.Controllers;
using Library.Web.Models;
using Library.IOCContainer;
using Library.DomainModel;
using System.Collections.Generic;

namespace Library.Web.Tests.Controllers
{
    [TestClass]
    public class BooksTest
    {
        public static bool isInitailized = false;
       
        
        public BooksTest()
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
        public void AddNewBook()
        {
           
            BooksModel classObj = new BooksModel();
            BooksModel obj = new BooksModel();
            obj.Author = "Test Author";
            obj.Title = "Test Title";
            Assert.IsTrue(classObj.AddNewBook(obj));
        }


        [TestMethod]
        public void GetAllBooks()
        {            
            // Arrange
            BooksModel model = new BooksModel();
            Common.SearchCriteria obj = new Common.SearchCriteria();
            obj.StartIndex = 0;
            obj.EndIndex = 10;
            obj.Text = string.Empty;
            Assert.IsNotNull(model.GetAllBooks(obj));
            Assert.AreEqual(10, model.GetAllBooks(obj).Count);
        }
        
      


    }
}
