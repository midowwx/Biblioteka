using System.Windows;

namespace Biblioteka
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Entities.LibreryEntities Context { get; set; } = new Entities.LibreryEntities();

    }

}
