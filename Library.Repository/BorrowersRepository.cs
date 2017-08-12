using Library.Common;
using Library.DomainModel;
using Library.Interface;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Repository
{
    //Interface method are implemented in Repository
    public class BorrowersRepository : IBorrowers 
    {

        /// <summary>
        /// Getting back all the Borrowers
        /// </summary>          
        /// <param> SearchCriteria</param>
        ///   <returns>IList<BorrowersDomainModel><BorrowersModel> </returns>  
        public IList<BorrowersDomainModel> GetAllBorrowers(SearchCriteria criteria)
        {
            IList<BorrowersDomainModel> ListFromMemory = FilterResultsFromBorrowersList(criteria);
            ListFromMemory = ListFromMemory.Skip(criteria.StartIndex - 1).Take(criteria.EndIndex - criteria.StartIndex).ToList();
            return ListFromMemory;
        }



        /// <summary>
        /// Total Count for Pagination
        /// </summary>          
        /// <param> SearchCriteria</param>
        ///   <returns>int </returns>  
        public int TotalBorrowersCount(SearchCriteria criteria)
        {
            return FilterResultsFromBorrowersList(criteria).ToList().Count;
        }

        

        /// <summary>
        /// Results are filterd from Memory Cache 
        /// </summary>          
        /// <param> SearchCriteria</param>
        ///   <returns>IList<BorrowersDomainModel> </returns>  
        private IList<BorrowersDomainModel> FilterResultsFromBorrowersList(SearchCriteria criteria)
        {
            IList<BorrowersDomainModel> ListFromMemory = MemoryCache.Get<IList<BorrowersDomainModel>>("BorrowersList").ToList();
            IList<BorrowersDomainModel> ListFromMemoryFiltered = (from t in ListFromMemory

                                                              where (
                                                              t.FirstName.ToLower().Contains(criteria.Text.ToLower()) ||
                                                              t.LastName.ToLower().Contains(criteria.Text.ToLower()))
                                                              select t).ToList();

            return ListFromMemoryFiltered;
        }



        /// <summary>
        /// New Borrower is added in the memory cache
        /// </summary>          
        /// <param> BorrowersDomainModel</param>
        ///   <returns>bool </returns>  
        public bool AddBorrower(BorrowersDomainModel obj)
        {
            IList<BorrowersDomainModel> ListFromMemory = MemoryCache.Get<IList<BorrowersDomainModel>>("BorrowersList").ToList();
            int NextID = ListFromMemory.Max(i => i.ID) + 1;
            obj.ID = NextID;
            ListFromMemory.Add(obj);

            Common.InMemoryOperations.UpdateList(ListFromMemory, "BorrowersList");
          
            return true; 
        }

    }
}
