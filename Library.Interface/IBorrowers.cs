using Library.DomainModel;
using Library.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Interface
{
    public interface IBorrowers
    {
        IList<BorrowersDomainModel> GetAllBorrowers(SearchCriteria criteria);

        int TotalBorrowersCount(SearchCriteria criteria);

        bool AddBorrower(BorrowersDomainModel bModel);
    }
}
