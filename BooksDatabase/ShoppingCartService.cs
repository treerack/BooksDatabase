using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksDatabase
{
    // new global variable to keep items in a list
    public static class ShoppingCartService
    {
        public static List<Book> ShoppingCart1 {  get; set; } = new List<Book>();
    }
}
