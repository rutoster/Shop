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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BooksStoreGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BooksStoreBL.BookStoreBL booksStoreBL;
        public MainWindow()
        {
            booksStoreBL = new BooksStoreBL.BookStoreBL();

            InitializeComponent();
            var res = booksStoreBL.GetAllBooks();
            Shop.ItemsSource = res;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(a.Text);
            string FName = b.Text;
            string LName = c.Text;
            string City = d.Text;
            string Country = e1.Text;
            string Phone = f.Text;
            booksStoreBL.AddNewBook(id, FName, LName, City, Country, Phone);
            var res = booksStoreBL.GetAllBooks();
            Shop.ItemsSource = res;

        }
    }
}
