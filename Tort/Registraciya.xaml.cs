using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для Registraciya.xaml
    /// </summary>
    public partial class Registraciya : Page
    {
        
        public Registraciya()
        {
            InitializeComponent();
            
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService navigation;
            navigation = NavigationService.GetNavigationService(this);
            navigation.Navigate(new System.Uri("Avtorizaciya.xaml", UriKind.RelativeOrAbsolute));
        }
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var inputPass = pbPassword.Password;
            CheckPassword(inputPass); // вызов метода, проверяющего пароль
        }
        private bool CheckPassword(string inputPass) // метод для проверки условий пароля 
        {
            if (string.IsNullOrWhiteSpace(inputPass))
            {
                MessageBox.Show ("Пароль должен сожержать от 5 до 20 символов, хотя бы одну заглавную букву и не содержать логин.");
                return false;
            }
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{5,20}");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");
            if (!hasLowerChar.IsMatch(inputPass))
            {
                MessageBox.Show ("Пароль должен содержать хотя бы одну строчную букву.");
                return false;
            }
            else if (!hasUpperChar.IsMatch(inputPass))
            {
                MessageBox.Show ("Пароль должен содержать хотя бы одну заглавную букву.");
                return false;
            }
            else if (!hasMiniMaxChars.IsMatch(inputPass))
            {
                MessageBox.Show ("Пароль не должен быть меньше 5 и больше 20 символов.");
                return false;
            }
            else if (!hasNumber.IsMatch(inputPass))
            {
                MessageBox.Show ("Пароль должен содержать хотя бы одну цифру");
                return false;
            }
            else if (!hasSymbols.IsMatch(inputPass))
            {
                MessageBox.Show ("Пароль должен содержать хотя бы один символ специального регистра.");
                return false;
            }
            else
            {
                return true;
            }
        }

        // Добавление данных регистрирующегося пользователя в базу данных
        private void formRegistraciya_Click(object sender, RoutedEventArgs e)
        {
            TortyEntities torty = new TortyEntities();
            torty.Users.Load();
            bool checkLogin = torty.Users.Any(User => User.Login == login.Text);
            User user = new User();
            user.Familia = LName.Text;
            user.Name = IO.Text;
            user.Login = login.Text;
            user.Role = "Заказчик";
            user.Password = pbPassword.Password;
            torty.Users.Add(user);
            torty.SaveChanges();
        }
        private void Login_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckLogin();
        }

        private void CheckLogin() // метод, проверяющий логин на совпадения в базе данных
        {
            TortyEntities torty = new TortyEntities();
            torty.Users.Load();
            var checkedLogin = torty.Users.FirstOrDefault(users => users.Login == login.Text);
            if (checkedLogin == null)
            {

            }
            else
            {
                MessageBox.Show ("Пользователь с таким логином уже существует. Используйте другой логин.");
            }
        }
    }
}
