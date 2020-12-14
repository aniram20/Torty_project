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

namespace Tort
{
    /// <summary>
    /// Логика взаимодействия для Ukrasheniya.xaml
    /// </summary>
    public partial class Ukrasheniya : Page
    {
        public Ukrasheniya()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService navigation;
            navigation = NavigationService.GetNavigationService(this);
            navigation.Navigate(new System.Uri("Avtorizaciya.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
