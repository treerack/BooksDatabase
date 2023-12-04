using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksDatabase
{
    // class for each part of the result 
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public string Author { get; set; }
        public string Edition { get; set; }
        public string Genre { get; set; }
        public int Price { get; set; }
        public string Introduction { get; set; }
    }
}
