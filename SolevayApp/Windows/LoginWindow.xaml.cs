using Dip.Model;
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

namespace SolevayApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        DatabaseEntities databaseEntities = new DatabaseEntities();
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();  
            this.Close();
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            if (isChecked())
            {
                User user = databaseEntities.User.FirstOrDefault(u => u.login == Login.Text && u.password == Password.Password);
                if (user != null)
                {
                    switch (user.role)
                    {
                        case "Пользователь":
                            UserWindow userWindow = new UserWindow(user);
                            userWindow.Show();
                            this.Close();
                            break;
                        case "HR":
                            HRWindow hrWindow = new HRWindow(user);
                            hrWindow.Show();
                            this.Close();
                            break;
                        case "Админ":
                            AdminWindow adminWindow = new AdminWindow(user);
                            adminWindow.Show();
                            this.Close();
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Пользователь не найден", "Внимание!");
                }
            }
        }

        private bool isChecked()
        {
            StringBuilder sb = new StringBuilder();

            if (string.IsNullOrEmpty(Login.Text))
            {
                sb.AppendLine("Введите логин");
            }

            if (string.IsNullOrEmpty(Password.Password))
            {
                sb.AppendLine("Введите пароль");
            }

            if (sb.Length > 0)
            {
                MessageBox.Show(sb.ToString(), "Внимание!");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
