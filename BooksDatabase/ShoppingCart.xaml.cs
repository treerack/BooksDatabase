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
    public partial class ShoppingCart : Window
    {
        // list of books, and book counter

        int CartItems;

        // update and keep items in the shopping cart
        public ShoppingCart()
        {
            InitializeComponent();
            UpdateShoppingCart();
        }


        private void UpdateShoppingCart()
        {
            cartView.ItemsSource = null;
            cartView.ItemsSource = ShoppingCartService.ShoppingCart1;
            CartItems = cartView.Items.Count;
            totalItems.Text = CartItems.ToString();
        }

        private void goToMain(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void removeFromCard_Click(object sender, RoutedEventArgs e)
        {
            if (cartView.Items.Count == 0)
            {
                MessageBox.Show("Your cart is empty.");
                return;
            }

            foreach (var item in cartView.SelectedItems)
            {
                Book selectedBook = (Book)item;
                ShoppingCartService.ShoppingCart1.Remove(selectedBook);
            }
            UpdateShoppingCart();
        }
    }
}
