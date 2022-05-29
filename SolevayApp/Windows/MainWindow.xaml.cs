using Dip.Model;
using SolevayApp.Windows;
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

namespace SolevayApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DatabaseEntities databaseEntities = new DatabaseEntities();
        public MainWindow()
        {
            InitializeComponent();

            User user = databaseEntities.User.FirstOrDefault(u => u.login == "Admin123");
            if (user == null)
            {
                User user1 = new User();
                user1.start_date = DateTime.Now;
                user1.password = "Admin123";
                user1.login = "Admin123";
                user1.role = "Админ";

                databaseEntities.User.Add(user1);
                databaseEntities.SaveChanges();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
            this.Close();
        }
    }
}
