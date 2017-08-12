using Library.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Repository
{
    public class BooksList
    {
        public static List<BooksDomainModel> GetBooksList()
        {
            //Dummy Data
            return new List<BooksDomainModel>()
            {
                new BooksDomainModel()
                { 
                     ID= 1,
                     Title = "SunderLand",
                     Author = "Raybon Petro",
                     TotalInStock = 5,
                     TotalAssigned =3
                  
                },

                
                new BooksDomainModel()
                { 
                     ID= 2,
                     Title = "A Road to Sky",
                     Author = "Jason Matt",
                     TotalInStock = 15,
                     TotalAssigned =8
                  
                },
                
                
                new BooksDomainModel()
                { 
                     ID= 3,
                     Title = "Moon And the Sea",
                     Author = "Micheal Bay",
                     TotalInStock = 5,
                     TotalAssigned =5
                  
                },
                
                new BooksDomainModel()
                { 
                     ID= 4,
                     Title = "Mathematics",
                     Author = "Private Publisher",
                     TotalInStock = 10,
                     TotalAssigned =7
                  
                },

                new BooksDomainModel()
                { 
                     ID= 5,
                     Title = "We are Lost",
                     Author = "Ana Maria",
                     TotalInStock = 20,
                     TotalAssigned =12
                  
                },
                
                
                new BooksDomainModel()
                { 
                     ID= 6,
                     Title = "Mathematics",
                     Author = "Private Publisher",
                     TotalInStock = 17,
                     TotalAssigned =9
                  
                },

                new BooksDomainModel()
                { 
                     ID= 7,
                     Title = "Physics",
                     Author = "The New Publisher",
                     TotalInStock = 10,
                     TotalAssigned =10
                  
                },
                
                new BooksDomainModel()
                { 
                     ID= 8,
                     Title = "The Bay of Nile",
                     Author = "Andrew Coff",
                     TotalInStock = 20,
                     TotalAssigned =10
                  
                },

                new BooksDomainModel()
                { 
                     ID= 9,
                     Title = "History of Mankind",
                     Author = "Stephan Hawking",
                     TotalInStock = 30,
                     TotalAssigned =15
                  
                },

                new BooksDomainModel()
                { 
                     ID= 10,
                     Title = "Into the Jungle",
                     Author = "Rayn Crow",
                     TotalInStock = 10,
                     TotalAssigned =10
                  
                },
                 
                new BooksDomainModel()
                { 
                     ID= 11,
                     Title = "Bye Bye World!",
                     Author = "Steve Jason",
                     TotalInStock = 18,
                     TotalAssigned =5
                  
                },

                new BooksDomainModel()
                { 
                     ID= 12,
                     Title = "I'm Truth",
                     Author = "Maria John",
                     TotalInStock = 18,
                     TotalAssigned = 9
                  
                },

                  new BooksDomainModel()
                { 
                     ID= 13,
                     Title = "Moon Go",
                     Author = "Kathrine Byer",
                     TotalInStock = 27,
                     TotalAssigned = 20
                  
                },

                
                  new BooksDomainModel()
                { 
                     ID= 13,
                     Title = "The Ray",
                     Author = "Red Publishers",
                     TotalInStock = 20,
                     TotalAssigned = 13
                  
                },

                
                new BooksDomainModel()
                { 
                     ID= 14,
                     Title = "I am John",
                     Author = "Mason Bob",
                     TotalInStock = 25,
                     TotalAssigned = 25
                  
                },

                
                  new BooksDomainModel()
                { 
                     ID= 15,
                     Title = "The Jounrey to Australia",
                     Author = "Bay Publishers",
                     TotalInStock = 22,
                     TotalAssigned = 5
                  
                },
                
                  new BooksDomainModel()
                { 
                     ID= 16,
                     Title = "The Hill",
                     Author = "Crown Title",
                     TotalInStock = 10,
                     TotalAssigned = 2
                  
                },

            };
        }
    }
}
