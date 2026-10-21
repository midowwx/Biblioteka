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
    /// Логика взаимодействия для ProfilPage.xaml
    /// </summary>
    public partial class ProfilPage : Page
    {
        private readonly Entities.Readers _currentUser;
        public ProfilPage(Entities.Readers user)
        {
            InitializeComponent();
            _currentUser = user;
            this.DataContext = _currentUser;
            if ( _currentUser.Email != null && _currentUser.NumberPhone == null)
            {

                em1.Visibility = Visibility.Hidden;
                em2.Visibility = Visibility.Visible;
            }
            else if (_currentUser.Email == null && _currentUser.NumberPhone != null)
            {
                ph1.Visibility = Visibility.Hidden;
                ph2.Visibility = Visibility.Visible;
            }
            else if (_currentUser.Email != null && _currentUser.NumberPhone != null)
            {
                em1.Visibility = Visibility.Hidden;
                em2.Visibility = Visibility.Visible;
                ph1.Visibility = Visibility.Hidden;
                ph2.Visibility = Visibility.Visible;
                save.Visibility = Visibility.Hidden;
            }
            else
            {
                em1.Visibility = Visibility.Visible;
                em2.Visibility = Visibility.Hidden;
                ph1.Visibility = Visibility.Visible;
                ph2.Visibility = Visibility.Hidden;
                save.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ph2.ToString().Length < 11)
            {
                MessageBox.Show($"Номер телефона должен состоять из 11 цифр");
                return;
            }
            try
            {
                App.Context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return; 
            }

            MessageBox.Show("Данные успешно сохранены!", "Готово", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
