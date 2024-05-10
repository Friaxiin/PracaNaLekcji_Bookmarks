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
using System.IO;

namespace PracaNaLekcji_Bookmarks
{
    /// <summary>
    /// Logika interakcji dla klasy AddBookWindow.xaml
    /// </summary>
    public partial class AddBookWindow : Window
    {
        public AddBookWindow()
        {
            InitializeComponent();
        }
        private void AddBook(object sender, RoutedEventArgs e)
        {
            Book newbook = new Book(titleEntry.Text, authorEntry.Text, descEntry.Text, publishedEntry.DisplayDate);
            Database.AddBook(newbook);
            this.Close();
        }
    }
}
