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

namespace Biblioteka
{
    /// <summary>
    /// Логика взаимодействия для LoansPage.xaml
    /// </summary>
    public partial class LoansPage : Page
    {
        private readonly Entities.Readers _currentUser;
        public LoansPage(Entities.Readers user)
        {
            InitializeComponent();
            this._currentUser = user;
            if (_currentUser.Rol == 2)
            {
                LL.ItemsSource = App.Context.Loans
             .Select(l => new
             {
                 l.LoanID,
                 l.Date,
                 BookTitle = l.Books.Title,
                 Names = l.Readers.Name
             })
             .ToList();
            }
            else
            {
                LL.ItemsSource = App.Context.Loans
           .Where(l => l.ReaderID == _currentUser.ReaderID)
           .Select(l => new
           {
               l.LoanID,
               l.Date,
               BookTitle = l.Books.Title
           })
           .ToList();
            }
            
        }
    }
}
