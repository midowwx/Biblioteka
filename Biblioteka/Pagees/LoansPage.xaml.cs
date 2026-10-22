using System.Linq;
using System.Windows.Controls;

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
