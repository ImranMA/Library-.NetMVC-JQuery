using Library.DomainModel;
using Library.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Interface
{
    public interface IAssignBook
    {
        bool AssignBook(AssignBookDomainModel aModel);

        IList<AssignBookDomainModel> GetAllAssignedBooks(SearchCriteria criteria);

        int TotalAssigned(SearchCriteria criteria);

        bool DeAssignBook(AssignBookDomainModel obj);
    }
}
