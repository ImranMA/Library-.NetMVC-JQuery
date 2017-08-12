using Library.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Common
{
    public class AssignedList
    {

        //Dummy Data
        public static List<AssignBookDomainModel> GetAssignedList()
        {
            return new List<AssignBookDomainModel>()
            {
                new AssignBookDomainModel()
                { 
                     BookID= 1,
                     BorrowerID = 1,
                     isCurrentlyAssigned = true,
                     AssignedDate = DateTime.Now.AddDays(-10),
                     DueDate= DateTime.Now.AddDays(-3)                  
                },
                new AssignBookDomainModel()
                { 
                     BookID= 12,
                     BorrowerID = 1,
                     isCurrentlyAssigned = false,
                     AssignedDate = DateTime.Now.AddDays(-1),
                     DueDate= DateTime.Now.AddDays(6)                  
                },

                new AssignBookDomainModel()
                { 
                     BookID= 2,
                     BorrowerID = 10,
                     isCurrentlyAssigned = true,
                     AssignedDate = DateTime.Now.AddDays(-20),
                     DueDate= DateTime.Now.AddDays(-13)                  
                },
                
                new AssignBookDomainModel()
                { 
                     BookID= 3,
                     BorrowerID = 7,
                     isCurrentlyAssigned = false,
                     AssignedDate = DateTime.Now.AddDays(-21),
                     DueDate= DateTime.Now.AddDays(-14)                  
                },


                new AssignBookDomainModel()
                { 
                     BookID= 10,
                     BorrowerID = 9,
                     isCurrentlyAssigned = true,
                     AssignedDate = DateTime.Now.AddDays(-3),
                     DueDate= DateTime.Now.AddDays(4)                  
                },
                                
                new AssignBookDomainModel()
                { 
                     BookID= 14,
                     BorrowerID = 7,
                     isCurrentlyAssigned = true,
                     AssignedDate = DateTime.Now.AddDays(-5),
                     DueDate= DateTime.Now.AddDays(2)                  
                },


            };
        }
    }
}
