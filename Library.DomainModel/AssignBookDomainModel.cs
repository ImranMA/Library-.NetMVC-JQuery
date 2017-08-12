using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DomainModel
{
    public class AssignBookDomainModel
    {
        public int BorrowerID { get; set; }
        public int BookID { get; set; }
        public DateTime AssignedDate { get; set; }
        public DateTime DueDate { get; set; }
        public bool isCurrentlyAssigned { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; } 
    }
}
