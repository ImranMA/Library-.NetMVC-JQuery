using Library.DomainModel;
using Library.Interface;
using Library.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Web.Models
{
    public partial class AssignBookModel : ModelBase
    {

        protected IAssignBook assignbookRep;


        //IOC in action and we are implementing Dependency injection using Contructor
        //we are resolving the interface 
        public AssignBookModel()
        {
            this.assignbookRep = this.Resolve<IAssignBook>();
        }


        /// <summary>
        /// Book is Assigned to the Borrower
        /// </summary>          
        /// <param> AssignBookModel</param>
        ///   <returns>bool<BorrowersModel> </returns>  
        public bool AssignBook(AssignBookModel obj)
        {
            return this.assignbookRep.AssignBook(Common.Transform.FromObjectToObject<AssignBookDomainModel, AssignBookModel>(obj));
        }


        ///<summary>
        ///All Issued books History
        ///</summary>          
        ///<param> jQueryDataTableParamModel</param>
        ///<param> searchCriteria</param>
        ///<returns>bool<BorrowersModel> </returns>  
        

        //Here we need to convert the DomainModel to Model , and only take those entities to view which     
        //Are necessary . We are keeping the DomainModel and Repository seperate from Model Logic. The Repository class is
        //Generic and return all the fields, while every class can later transform the required DomainModel
        //Fields in Model Fields
        //This approach keeps the business logic seprated from DB/Repository logic
        public IList<AssignBookModel> GetAllAssignedBooks(SearchCriteria criteria)
        {
            return
                   Common.Transform
                       .FromObjectToObject<AssignBookModel, AssignBookDomainModel>(
                           this.assignbookRep.GetAllAssignedBooks(criteria));
        }

        ///<summary>
        /// Total count For Pagination
        ///</summary>          
        ///<param> SearchCriteria</param>
        ///<returns>int<BorrowersModel> </returns>  
        public int TotalAssigned(SearchCriteria criteria)
        {
            return this.assignbookRep.TotalAssigned(criteria);
        }


        ///<summary>
        /// DeAssign the Book incase user has retruned it
        ///</summary>          
        ///<param> BorrowersModel</param>
        ///<returns>bool<BorrowersModel> </returns>  
        public bool DeAssignBook(AssignBookModel obj)
        {
            return this.assignbookRep.DeAssignBook(Common.Transform.FromObjectToObject<AssignBookDomainModel, AssignBookModel>(obj));
        }

    }
}