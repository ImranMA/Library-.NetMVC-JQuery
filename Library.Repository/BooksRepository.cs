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
    public class BooksRepository : IBooks
    {

        /// <summary>
        /// Getting back all the Books based on filter
        /// </summary>          
        /// <param> SearchCriteria</param>
        ///   <returns>IList<BooksDomainModel> </returns>  
        public IList<BooksDomainModel> GetAllBooks(SearchCriteria criteria)
        {
            //Actual Database logic goes here , we have implemented our own method to return List of books 
            IList<BooksDomainModel> ListFromMemory = FilterResultsFromBooksList(criteria);
            ListFromMemory = ListFromMemory.Skip(criteria.StartIndex-1).Take(criteria.EndIndex - criteria.StartIndex).ToList();
            return ListFromMemory;
        }


        /// <summary>
        /// Total Count for Pagination
        /// </summary>          
        /// <param> SearchCriteria</param>
        ///   <returns>int </returns>  
        public int TotalBooksCount(SearchCriteria criteria)
        {
            return FilterResultsFromBooksList(criteria).ToList().Count;
        }



        /// <summary>
        /// New book is added in the memory cache
        /// </summary>          
        /// <param> BooksDomainModel</param>
        ///   <returns>bool </returns>  
        public bool AddNewBook(BooksDomainModel obj)
        {

            IList<BooksDomainModel> ListFromMemory = MemoryCache.Get<IList<BooksDomainModel>>("BooksList").ToList();
            int NextID = ListFromMemory.Max(i => i.ID) + 1;
            obj.ID = NextID;
            ListFromMemory.Add(obj);

            Common.InMemoryOperations.UpdateList(ListFromMemory, "BooksList");
            
            return true; 
        }



        /// <summary>
        /// Results are filterd from Memory Cached Data 
        /// </summary>          
        /// <param> SearchCriteria</param>
        ///   <returns>IList<BorrowersDomainModel> </returns> 
        private IList<BooksDomainModel> FilterResultsFromBooksList(SearchCriteria criteria)
        {
            IList<BooksDomainModel> ListFromMemory = MemoryCache.Get<IList<BooksDomainModel>>("BooksList").ToList();
            IList<BooksDomainModel> ListFromMemoryFiltered = (from t in ListFromMemory

                                                              where (
                                                              t.Author.ToLower().Contains(criteria.Text.ToLower()) ||
                                                              t.Title.ToLower().Contains(criteria.Text.ToLower()))
                                                              select t).ToList();

            return ListFromMemoryFiltered;
        }
    }
}
