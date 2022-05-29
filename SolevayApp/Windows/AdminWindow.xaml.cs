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
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        DatabaseEntities databaseEntities = new DatabaseEntities();
        public AdminWindow(User _user)
        {
            InitializeComponent();
            dateGrid1.ItemsSource = databaseEntities.User.Where(u=>u.role != "Админ").ToList();
            lable.Content = "Привет " + _user.login;
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddedUserAdminWindow addedUserAdminWindow = new AddedUserAdminWindow();
            addedUserAdminWindow.Show();
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            databaseEntities.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            dateGrid1.ItemsSource = databaseEntities.User.Where(u => u.role != "Админ").ToList();
        }

        private void Button_Click4(object sender, RoutedEventArgs e)
        {
            if (dateGrid1.SelectedItems.Count == 1)
            {
                User user = (User)dateGrid1.SelectedItems[0];
                if (MessageBox.Show("Удалить?", "Внимание!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    try
                    {
                        databaseEntities.User.Remove(user);
                        databaseEntities.SaveChanges();
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            if (dateGrid1.SelectedItems.Count == 1)
            {
                User user = (User)dateGrid1.SelectedItems[0];
                AddedUserAdminWindow addedUserAdminWindow = new AddedUserAdminWindow(user);
                addedUserAdminWindow.Show();
            }
        }
    }
}
