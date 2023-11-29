using System.Data.SQLite;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BooksDatabase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Setting a connection up with DB
        private SQLiteConnection connection;
        private List<Book> bookList;
        public MainWindow()
        {
            InitializeComponent();
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            // Initializing 
            connection = new SQLiteConnection(@"Data Source=C:\BooksDatabase\BooksDatabase\books.db;Version=3");
            connection.Open();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            // Removing useless part of the text
            string searchTxt = searchTextBox.Text.Trim();

            if(string.IsNullOrEmpty(searchTxt) )
            {
                MessageBox.Show("Please enter a book name to search...");
                return;
            }

            // Searching by name and getting info from the DB
            string query = "SELECT * FROM departmentTBl WHERE Name LIKE @Name";
            SQLiteCommand command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@Name", "%" + searchTxt + "%");

            bookList = new List<Book>();

            SQLiteDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                bookList.Add(new Book
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    Author = reader["Author"].ToString(),
                    Edition = reader["Edition"].ToString(),
                    Genre = reader["Genre"].ToString(),
                    Price = Convert.ToInt32(reader["Price"])
                });
            }
            reader.Close();

            // Showing the result as a list
            resultListView.ItemsSource = bookList;
        }

        private void goToCart(object sender, RoutedEventArgs e)
        {
            shoppingCart shoppingCartWindow = new shoppingCart();
            shoppingCartWindow.Show();
            this.Close();
        }
    }
}