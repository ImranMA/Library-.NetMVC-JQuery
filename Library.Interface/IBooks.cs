using Library.DomainModel;
using Library.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Interface
{
    public interface IBooks
    {
        /// <summary>
        /// Get all books Interface
        /// /// </summary>       
      
        IList<BooksDomainModel> GetAllBooks(SearchCriteria criteria);

        bool AddNewBook(BooksDomainModel bModel);

        int TotalBooksCount(SearchCriteria criteria);

    }
}
