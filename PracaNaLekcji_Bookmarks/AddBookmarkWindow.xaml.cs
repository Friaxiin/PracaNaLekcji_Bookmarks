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

namespace PracaNaLekcji_Bookmarks
{
    /// <summary>
    /// Logika interakcji dla klasy AddBookmarkWindow.xaml
    /// </summary>
    public partial class AddBookmarkWindow : Window
    {
        public AddBookmarkWindow(Book book)
        {
            InitializeComponent();
            //bookmarkList.ItemsSource = book.Bookmarks;
        }
        private void bookmarkListDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Bookmark bookmark = bookmarkList.SelectedItem as Bookmark;
            string message = "Opis: " + bookmark.Description;
            MessageBox.Show(message);
        }

        private void AddBookmark(object sender, RoutedEventArgs e)
        {
            //Bookmark addedBookmark = new Bookmark(int.Parse(pageEntry.Text), descEntry.Text);
            //(DataContext as Book).AddBookmark(addedBookmark);
            //bookmarkList.ItemsSource = (DataContext as Book).Bookmarks;
        }
    }
}
