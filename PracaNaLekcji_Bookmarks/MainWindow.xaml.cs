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

namespace PracaNaLekcji_Bookmarks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //bookList.ItemsSource = Database.Books;
            Database.CreateTables();
            bookList.ItemsSource = Database.ReadBooks();
        }

        private void DeleteBook(object sender, RoutedEventArgs e)
        {
            Book selectedbook = (sender as Button).CommandParameter as Book;
            Database.DeleteBook(selectedbook);
            bookList.ItemsSource = Database.ReadBooks();
        }

        private void Bookmarks(object sender, RoutedEventArgs e)
        {
            Book selectedbook = (sender as Button).CommandParameter as Book;

            AddBookmarkWindow bookmarks = new AddBookmarkWindow(selectedbook);
            bookmarks.DataContext = selectedbook;
            bookmarks.ShowDialog();

        }
        private void AddBook(object sender, RoutedEventArgs e)
        {
            new AddBookWindow().ShowDialog();
            bookList.ItemsSource = Database.ReadBooks();
        }
    }
}