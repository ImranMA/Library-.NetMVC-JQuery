using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Web.Models
{
    public partial class BooksModel
    {

        //Books Attributes

        public int ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int TotalInStock { get; set; }
        public int TotalAssigned { get; set; }  
    }
}