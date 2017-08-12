using Library.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Common
{
    public class BorrowersList
    {
        public static List<BorrowersDomainModel> GetBorrowersList()
        {
            //Dummy Data
            return new List<BorrowersDomainModel>()
            {
                new BorrowersDomainModel()
                { 
                     ID= 1,
                     FirstName = "Martin",
                     LastName = "Bay"
                  
                },
                   new BorrowersDomainModel()
                { 
                     ID= 2,
                     FirstName = "Alex",
                     LastName = "Joe"
                  
                },

                new BorrowersDomainModel()
                { 
                     ID= 3,
                     FirstName = "Micheal",
                     LastName = "Jordan"
                  
                },
                new BorrowersDomainModel()
                { 
                     ID= 4,
                     FirstName = "Tim",
                     LastName = "Ronaldo"
                  
                },

                 new BorrowersDomainModel()
                { 
                     ID= 5,
                     FirstName = "Jospeh",
                     LastName = "Link"
                  
                },

                new BorrowersDomainModel()
                { 
                     ID= 6,
                     FirstName = "Jospeh",
                     LastName = "Link"
                  
                },

                 new BorrowersDomainModel()
                { 
                     ID= 7,
                     FirstName = "Seena",
                     LastName = "Myre"
                  
                },

                new BorrowersDomainModel()
                { 
                     ID= 8,
                     FirstName = "Nandu",
                     LastName = "Pariti"
                  
                },
                 new BorrowersDomainModel()
                { 
                     ID= 9,
                     FirstName = "Mishel",
                     LastName = "Raina"
                  
                },

                 new BorrowersDomainModel()
                { 
                     ID= 10,
                     FirstName = "David",
                     LastName = "Woods"
                  
                },

                   new BorrowersDomainModel()
                { 
                     ID= 10,
                     FirstName = "Sofia",
                     LastName = "Bari"
                  
                },

                   new BorrowersDomainModel()
                { 
                     ID= 11,
                     FirstName = "Enna",
                     LastName = "Moeyer"
                  
                },

                   new BorrowersDomainModel()
                { 
                     ID= 12,
                     FirstName = "Maria",
                     LastName = "Sharlet"
                  
                },

                   new BorrowersDomainModel()
                { 
                     ID= 13,
                     FirstName = "Jenifer",
                     LastName = "Hoetz"
                  
                },
                   new BorrowersDomainModel()
                { 
                     ID= 14,
                     FirstName = "Kinder",
                     LastName = "Hale"
                  
                },


                   new BorrowersDomainModel()
                { 
                     ID= 15,
                     FirstName = "Alex",
                     LastName = "Timber"
                  
                },
            };
        }
    }
}
