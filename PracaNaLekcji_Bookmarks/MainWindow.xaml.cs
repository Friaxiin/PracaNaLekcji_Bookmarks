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
            List<Book> books = Database.LoadBooks();

            bookList.ItemsSource = books;
        }

        private void AddBook(object sender, RoutedEventArgs e)
        {
            Window window = new AddBookWindow();
            window.Show();
            this.Close();
        }
    }
}