using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BooksDatabase
{
    /// <summary>
    /// shoppingCart.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class shoppingCart : Window
    {
        private List<Book> adddedBooks;
        public shoppingCart()
        {
            InitializeComponent();
        }

        private void goToShopping(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
