using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DomainModel
{
    public class BooksDomainModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int TotalInStock { get; set; }
        public int TotalAssigned { get; set; }  
    }
}
