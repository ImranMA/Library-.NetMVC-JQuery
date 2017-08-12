using Library.Common;
using Library.DomainModel;
using Library.Interface;
using Library.Web.Models.JqTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Web.Models
{
    public partial class BooksModel : ModelBase 
    { 
        
        //Books Interface
        protected IBooks booksRep;



        //IOC in action and we are implementing Dependency injection using Contructor
        //we are resolving the interface 
        public BooksModel()
        {
            this.booksRep = this.Resolve<IBooks>();           
        }
        

        /// <summary>
        /// Getting all books based on Filter
        /// </summary>          
        /// <param> SearchCriteria</param>  
        ///   <returns>IList<BooksModel></returns>  
        ///   

        //Here we need to convert the DomainModel to Model , and only take those entities to view which     
        //Are necessary . We are keeping the DomainModel and Repository seperate from Model Logic. The Repository class is
        //Generic and return all the fields, while every class can later transform the required DomainModel
        //Fields in Model Fields
        //This approach keeps the business logic seprated from DB/Repository logic
        public IList<BooksModel> GetAllBooks(SearchCriteria criteria)
        {
            return
                   Common.Transform
                       .FromObjectToObject<BooksModel, BooksDomainModel>(
                           this.booksRep.GetAllBooks(criteria));
        }
        

        /// <summary>
        /// Save New Book
        /// </summary>          
        /// <param> BooksModel</param>  
        ///   <returns>bool<BooksModel></returns>  
        public bool AddNewBook(BooksModel obj)
        {            
            return this.booksRep.AddNewBook(Common.Transform.FromObjectToObject<BooksDomainModel, BooksModel>(obj)); 
        }
                


        /// <summary>
        /// Count for Pagination
        /// </summary>          
        /// <param> SearchCriteria</param>  
        ///   <returns>int<BooksModel></returns>  
        public int TotalBooks(SearchCriteria criteria)
        {
            return this.booksRep.TotalBooksCount(criteria);
        }
    }
}