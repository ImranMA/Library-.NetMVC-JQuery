using Library.Web.Models;
using Library.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Web.Controllers
{
    public class AutoCompleteController : Controller
    {
        // GET: AutoComplete


        /// <summary>
        /// AutoComplete Book Suggestions
        /// </summary>          
        /// <param>term</param>        
        ///   <returns>JsonResult</returns>  
        public JsonResult AutoCompleteBook(string term)
        {
            try
            {
                BooksModel obj = new BooksModel();
                SearchCriteria sc = new SearchCriteria();
                SearchCriteria Count = new SearchCriteria();
                Count.Text = string.Empty;
                sc.Text = term;
                sc.StartIndex = 0;
                sc.EndIndex = obj.TotalBooks(Count);
                return Json(obj.GetAllBooks(sc), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Logging.Error(ex.Message);
                return null;

            }

        }


        /// <summary>
        /// AutoComplete Borrowers Suggestions
        /// </summary>          
        /// <param>term</param>        
        ///   <returns>JsonResult</returns>  
        public JsonResult AutoCompleteBorrowers(string term)
        {
            try
            {
                BorrowersModel obj = new BorrowersModel();
                SearchCriteria sc = new SearchCriteria();
                SearchCriteria Count = new SearchCriteria();
                Count.Text = string.Empty;
                sc.Text = term;
                sc.StartIndex = 0;
                sc.EndIndex = obj.TotalBorrowers(Count);
                return Json(obj.GetAllBorrowers(sc), JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                Logging.Error(ex.Message);
                return null;

            }
        }


    }
}