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
