using Biblioteka.Entities;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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

namespace Biblioteka
{
    /// <summary>
    /// Логика взаимодействия для BooksPage.xaml
    /// </summary>
    public partial class BooksPage : Page
    {
        private readonly Entities.Readers _currentUser;
        public BooksPage(Entities.Readers user)
        {
            InitializeComponent();
            LV.ItemsSource = App.Context.Books
           .Select(b => new
           {
               b.Photo,
               b.Title,
               Authorss = b.Authors.LastName,
               b.DataPublic
           })
           .ToList();
            this._currentUser = user;
            if (_currentUser.Rol == 2)
            {
                AddBookButton.Visibility = Visibility.Visible;
                AddBook.Visibility = Visibility.Hidden;
            }
            else
            {
                AddBookButton.Visibility = Visibility.Hidden;
                AddBook.Visibility = Visibility.Visible;
            }
        }

        private void AddBookButtonCL(object sender, RoutedEventArgs e)
        {
                Books book = new Books
                {
                   
                    DataPublic = DateTime.Parse("22.02.1900"),
                    Title = "книга",
                    AuthorID = 5,
                    CategoryID = 1
                };
                App.Context.Books.Add(book);
                App.Context.SaveChanges();
                LoadBooks();
            }
        private void LoadBooks()
        {
            LV.ItemsSource = App.Context.Books
                .Select(b => new
                {
                    b.Photo,
                    b.Title,
                    Authorss = b.Authors.LastName,
                    DataPublic = b.DataPublic
                })
                .ToList();
        }

        private void AddBookBtn(object sender, RoutedEventArgs e)
        {
            if (LV.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите книгу из списка.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            dynamic selectedBook = LV.SelectedItem;
            string title = selectedBook.Title;
            Books bookToLoan = App.Context.Books.FirstOrDefault(b => b.Title == title);
            if (bookToLoan != null)
            {
                Loans loan = new Loans
                {
                    BookID = bookToLoan.BookID, 
                    ReaderID = _currentUser.ReaderID, 
                    Date = DateTime.Now
                };
                App.Context.Loans.Add(loan);
                App.Context.SaveChanges();
                MessageBox.Show($"Книга «{title}» успешно добавлена в вашу историю выдач.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
