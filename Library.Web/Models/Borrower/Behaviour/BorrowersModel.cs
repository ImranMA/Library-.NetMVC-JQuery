using Library.DomainModel;
using Library.Interface;
using Library.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Web.Models
{
    public partial class BorrowersModel : ModelBase
    {
       
        protected IBorrowers borrowRep;


        //IOC in action and we are implementing Dependency injection using Contructor
        //we are resolving the interface 
        public BorrowersModel()
        {
            this.borrowRep = this.Resolve<IBorrowers>();           
        }


        /// <summary>
        /// Brings The Data Back to Borrowers Table Based on Filter
        /// </summary>          
        /// <param> SearchCriteria</param>
        ///   <returns>IList<BorrowersModel> </returns>   
        ///   
        //Here we need to convert the DomainModel to Model , and only take those entities to view which     
        //Are necessary . We are keeping the DomainModel and Repository seperate from Model Logic. The Repository class is
        //Generic and return all the fields, while every class can later transform the required DomainModel
        //Fields in Model Fields
        //This approach keeps the business logic seprated from DB/Repository logic
        public IList<BorrowersModel> GetAllBorrowers(SearchCriteria criteria)
        {
            return
                   Common.Transform
                       .FromObjectToObject<BorrowersModel, BorrowersDomainModel>(
                           this.borrowRep.GetAllBorrowers(criteria));
        }


        /// <summary>
        ///Total Count for pagination
        /// </summary>          
        /// <param> SearchCriteria</param>
        ///   <returns>int<BorrowersModel> </returns>   
        public int TotalBorrowers(SearchCriteria criteria)
        {
            return this.borrowRep.TotalBorrowersCount(criteria);
        }


        /// <summary>
        ///Adds New Borrower
        /// </summary>          
        /// <param> BorrowersModel</param>
        ///   <returns>bool<BorrowersModel> </returns>   
        public bool AddBorrower(BorrowersModel obj)
        {
            return this.borrowRep.AddBorrower(Common.Transform.FromObjectToObject<BorrowersDomainModel, BorrowersModel>(obj));
        }


    }
}