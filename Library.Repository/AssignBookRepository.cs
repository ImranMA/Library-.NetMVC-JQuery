using Library.Common;
using Library.DomainModel;
using Library.Interface;
using Library.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Repository
{
    public class AssignBookRepository : IAssignBook
    {
        /// <summary>
        /// Book is assigned to the Borrower
        /// </summary>          
        /// <param> AssignBookDomainModel</param>
        ///   <returns>bool<BorrowersDomainModel> </returns> 
        public bool AssignBook(AssignBookDomainModel obj)
        {
            //Assigning the book and updating the list
            IList<AssignBookDomainModel> AssignList = MemoryCache.Get<IList<AssignBookDomainModel>>("AssignBookList").ToList();
            obj.isCurrentlyAssigned = true;
            AssignList.Add(obj);

            //Updating the AssignList           
            Common.InMemoryOperations.UpdateList(AssignList, "AssignBookList");

            //Updating the TotalAssigned Books as it can be updated in list as reference
            IList<BooksDomainModel> bookList = MemoryCache.Get<IList<BooksDomainModel>>("BooksList").ToList();
            bookList.First(d => d.ID == obj.BookID).TotalAssigned +=1;
                        
            return true; 
        }


        /// <summary>
        /// Getting back all the Books that are assigned to the borrowers
        /// </summary>          
        /// <param> SearchCriteria</param>
        ///   <returns>IList<AssignBookDomainModel> </returns> 
        public IList<AssignBookDomainModel> GetAllAssignedBooks(SearchCriteria criteria)
        {
            IList<AssignBookDomainModel> ListFromMemory = FilterResultsFromAssignList(criteria);
            ListFromMemory = ListFromMemory.Skip(criteria.StartIndex - 1).Take(criteria.EndIndex - criteria.StartIndex).ToList();
            return ListFromMemory;            
        }


        /// <summary>
        /// Book is Deassigned if it is returned
        /// </summary>          
        /// <param> AssignBookDomainModel</param>
        ///   <returns>bool<BorrowersDomainModel> </returns> 
        public bool DeAssignBook(AssignBookDomainModel obj)
        {
            //Assigning the book and updating the list
            IList<AssignBookDomainModel> AssignList = MemoryCache.Get<IList<AssignBookDomainModel>>("AssignBookList").ToList();
            AssignList.Where(d => d.BookID == obj.BookID && d.BorrowerID==obj.BorrowerID).ToList().ForEach(i=> i.isCurrentlyAssigned = false);                  

            //Updating the TotalAssigned Books
            IList<BooksDomainModel> bookList = MemoryCache.Get<IList<BooksDomainModel>>("BooksList").ToList();
            bookList.First(d => d.ID == obj.BookID).TotalAssigned -= 1;             
            
            return true;
        }


        /// <summary>
        /// Total Count for Pagination
        /// </summary>          
        /// <param> SearchCriteria</param>
        ///   <returns>int </returns> 
        public int TotalAssigned(SearchCriteria criteria)
        {
            return FilterResultsFromAssignList(criteria).ToList().Count;
        }


        /// <summary>
        /// Results are filterd from Memory Cached Data 
        /// </summary>          
        /// <param> SearchCriteria</param>
        ///   <returns>IList<AssignBookDomainModel> </returns> 
        private IList<AssignBookDomainModel> FilterResultsFromAssignList(SearchCriteria criteria)
        {
            IList<AssignBookDomainModel> ListFromMemory = GetInnerJoinOfLists();         
            IList<AssignBookDomainModel> ListFromMemoryFiltered = (from t in ListFromMemory

                                                              where (
                                                              t.Title.ToLower().Contains(criteria.Text.ToLower()) ||
                                                              t.FirstName.ToLower().Contains(criteria.Text.ToLower())||
                                                              t.LastName.ToLower().Contains(criteria.Text.ToLower()))
                                                              select t).ToList();

            return ListFromMemoryFiltered;
        }




        /// <summary>
        /// Data is being joined from all the lists in Memory Cache
        /// </summary>          
        /// <param> SearchCriteria</param>
        ///   <returns>IList<AssignBookDomainModel> </returns> 
        private IList<AssignBookDomainModel> GetInnerJoinOfLists()
        {
            IList<AssignBookDomainModel> AssignList = MemoryCache.Get<IList<AssignBookDomainModel>>("AssignBookList").ToList();
            IList<BooksDomainModel> booksList = MemoryCache.Get<IList<BooksDomainModel>>("BooksList").ToList();
            IList<BorrowersDomainModel> borowerList = MemoryCache.Get<IList<BorrowersDomainModel>>("BorrowersList").ToList();


            var assignedList = from assign in AssignList

                               join bk in booksList
                               on assign.BookID equals bk.ID

                               join bl in borowerList
                                on assign.BorrowerID equals bl.ID
                               select new
                               {
                                   bk.Title,
                                   bl.FirstName,
                                   bl.LastName,
                                   assign.isCurrentlyAssigned,
                                   assign.AssignedDate,
                                   assign.DueDate,
                                   assign.BookID,
                                   assign.BorrowerID
                               };


            IList<AssignBookDomainModel> resList= new List<AssignBookDomainModel>();
           
            foreach (var v in assignedList)
            {
                AssignBookDomainModel m = new AssignBookDomainModel();
                m.BookID = v.BookID;
                m.BorrowerID = v.BorrowerID;
                m.DueDate = v.DueDate;
                m.FirstName = v.FirstName;
                m.LastName = v.LastName;
                m.isCurrentlyAssigned = v.isCurrentlyAssigned;
                m.Title = v.Title;
                m.AssignedDate = v.AssignedDate;

                resList.Add(m);
            }         
          

            return resList;
        }
        
    }
}
