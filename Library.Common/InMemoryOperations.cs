using Library.DomainModel;
using Library.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Common
{
    public class InMemoryOperations
    {

        //Initialing The Memory Cache
        public static void InitializeDataList()
        {
            IList<BooksDomainModel> bookList = BooksList.GetBooksList();
            MemoryCache.Add("BooksList", bookList);

            IList<BorrowersDomainModel> bList = BorrowersList.GetBorrowersList();
            MemoryCache.Add("BorrowersList", bList);

            IList<AssignBookDomainModel> AssignList = AssignedList.GetAssignedList();
            MemoryCache.Add("AssignBookList", AssignList);
        }


        //Memory Cache Updates
        public static void UpdateList<J>(IList<J> list, string ListName)
        {
            Common.MemoryCache.Remove<IList<J>>(ListName);
            MemoryCache.Add(ListName, list);
        }

    }
}
