using System;
using System.Linq;
using System.Windows;

namespace Biblioteka
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            var registerWin = new Window1();
            registerWin.Owner = this;
            registerWin.ShowDialog();
            this.IsEnabled = true;

        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text.Trim();
            string password = PaswordTextBox.Password;
            if (string.IsNullOrWhiteSpace(login))
            {
                MessageBox.Show("Логин обязателен.");
                return;
            }
            try
            {
                var user = App.Context.Readers.FirstOrDefault(u => u.Login == login);

                if (user is null)
                    MessageBox.Show("Пользователь с таким логином не найден!");
                else if (password != user.Pasword)
                    MessageBox.Show("Неверный пароль!");
                else
                {
                    MessageBox.Show($"Добро пожаловать, {user.Name} {user.LastName}.");

                    var mainApp = new BibliotekaGlav(user);
                    mainApp.Show();
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

