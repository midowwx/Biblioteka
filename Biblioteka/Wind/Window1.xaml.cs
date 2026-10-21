using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        private void BtnZaRegister_Click(object sender, RoutedEventArgs e)
        {

            string name = NameTextBox.Text.Trim();
            string lastName = LastNameTextBox.Text.Trim();
            string login = LoginTextBox.Text.Trim();
            string password = PaswordTextBox.Password;
            if (string.IsNullOrEmpty(name)) {MessageBox.Show("Имя обязательно."); return; }
            if (string.IsNullOrEmpty(lastName)) {MessageBox.Show("Фамилия обязательна."); return; }
            if (string.IsNullOrEmpty(login)){ MessageBox.Show("Логин обязателен."); return; }
            try
            {
                var user = App.Context.Readers.FirstOrDefault(r => r.Login == login);
            if (user != null)
                {MessageBox.Show("Такой логин уже занят!"); return; }
            var newReader = new  Entities.Readers
            {
                Name = name,
                LastName = lastName,
                Login = login,
                Pasword = password,
                Rol = 1
            };
            App.Context.Readers.Add(newReader);
                App.Context.SaveChanges();
                this.Close();
        }
            catch (DbUpdateException ex)
        {
                MessageBox.Show("Ошибка базы данных:\n" + ex.Message);
            }
        }
    }
}
