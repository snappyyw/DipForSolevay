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
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        DatabaseEntities databaseEntities = new DatabaseEntities();
        public RegistrationWindow()
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
            try
            {
                if (isChecked())
                {
                    User user = new User();
                    user.FIO = FIO.Text;
                    user.password = Password.Password;
                    user.login = Login.Text;
                    user.role = "Пользователь";
                    user.start_date = DateTime.Now;
                    databaseEntities.User.Add(user);
                    databaseEntities.SaveChanges();

                    MessageBox.Show("Пользователь зарегистрирован","Внимание!");
                    LoginWindow loginWindow = new LoginWindow();
                    loginWindow.Show();
                    this.Close();
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Внимание!");
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

            if (string.IsNullOrEmpty(FIO.Text))
            {
                sb.AppendLine("Введите ФИО");
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
