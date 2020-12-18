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
using System.Data.Entity;

namespace Tort
{
    /// <summary>
    /// Логика взаимодействия для Avtorizaciya.xaml
    /// </summary>
    public partial class Avtorizaciya : Page
    {
        public Avtorizaciya()
        {
            InitializeComponent();
        }

        private void Registraciya(object sender, RoutedEventArgs e)
        {
            NavigationService navigate;
            navigate = NavigationService.GetNavigationService(this);
            navigate.Navigate(new System.Uri("Registraciya.xaml", UriKind.RelativeOrAbsolute)); //Переход к странице регистрации
        }

        private void Avtorizacia_Click(object sender, RoutedEventArgs e)
        {
            TortyEntities torty = new TortyEntities();
            User user = torty.Users.Find(tbLogin, pbPassword);
            if (user != null)
            {
                NavigationService navigate;
                navigate = NavigationService.GetNavigationService(this);
                navigate.Navigate(new System.Uri("Ukrasheniya.xaml", UriKind.RelativeOrAbsolute));
            }
            else
            {
                MessageBox.Show("Неправильно введён логин или пароль");
            }
        }
    }
}
