using System.Windows;
using System.Windows.Controls;

namespace Biblioteka
{
    /// <summary>
    /// Логика взаимодействия для BibliotekaGlav.xaml
    /// </summary>
    public partial class BibliotekaGlav : Window
    {
        private readonly Entities.Readers _currentUser;
        public BibliotekaGlav(Entities.Readers user)
        {
            InitializeComponent();
            _currentUser = user;
            AppFrame.Navigate(new BooksPage(_currentUser));

        }


        private void MenuItem_Clikc(object sender, RoutedEventArgs e)
        {
            MenuItem menuitem = sender as MenuItem;
            if (menuitem == null) return;
            string pageTag = menuitem.Tag.ToString();
            if (pageTag == "ProfilPage")
                AppFrame.Navigate(new ProfilPage(_currentUser));
            else if (pageTag == "LoansPage")
                AppFrame.Navigate(new LoansPage(_currentUser));
            else
                AppFrame.Navigate(new BooksPage(_currentUser));

        }
    }
}
