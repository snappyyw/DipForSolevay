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
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        DatabaseEntities databaseEntities = new DatabaseEntities();
        User user;
        public UserWindow(User _user)
        {
            InitializeComponent();
            lable.Content = "Привет " + _user.login;
            dateGrid1.ItemsSource = databaseEntities.Vacation.Where(v=> v.user_id == _user.id).ToList();
            dateGrid2.ItemsSource = databaseEntities.SickDay.Where(v => v.user_id == _user.id).ToList();
            dateGrid3.ItemsSource = databaseEntities.ProfessionalDevelopment.Where(v => v.user_id == _user.id).ToList();

            user = _user;
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddDateWindow addDateWindow = new AddDateWindow("Vacation", user.id);
            addDateWindow.Show();
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            if (dateGrid1.SelectedItems.Count == 1)
            {
                Vacation vacation = (Vacation)dateGrid1.SelectedItems[0];
                if (MessageBox.Show("Отменить?", "Внимание!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    try
                    {
                        databaseEntities.Vacation.Remove(vacation);
                        databaseEntities.SaveChanges();
                    } catch(Exception ex) { 

                    }
                }
            }
        }

        private void Button_Click4(object sender, RoutedEventArgs e)
        {
            databaseEntities.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            dateGrid1.ItemsSource = databaseEntities.Vacation.Where(v => v.user_id == user.id).ToList();
            dateGrid2.ItemsSource = databaseEntities.SickDay.Where(v => v.user_id == user.id).ToList();
            dateGrid3.ItemsSource = databaseEntities.ProfessionalDevelopment.Where(v => v.user_id == user.id).ToList();
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            if (dateGrid2.SelectedItems.Count == 1)
            {
                SickDay sickDay = (SickDay)dateGrid2.SelectedItems[0];
                if (MessageBox.Show("Отменить?", "Внимание!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    try
                    {
                        databaseEntities.SickDay.Remove(sickDay);
                        databaseEntities.SaveChanges();
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
        }

        private void Button_Click5(object sender, RoutedEventArgs e)
        {
            AddDateWindowFull addDateWindowFull = new AddDateWindowFull( user.id);
            addDateWindowFull.Show();
        }

        private void Button_Click6(object sender, RoutedEventArgs e)
        {
            AddDateWindow addDateWindow = new AddDateWindow("ProfessionalDevelopment", user.id);
            addDateWindow.Show();
        }

        private void Button_Click7(object sender, RoutedEventArgs e)
        {
            if (dateGrid3.SelectedItems.Count == 1)
            {
                ProfessionalDevelopment professionalDevelopment = (ProfessionalDevelopment)dateGrid3.SelectedItems[0];
                if (MessageBox.Show("Отменить?", "Внимание!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    try
                    {
                        databaseEntities.ProfessionalDevelopment.Remove(professionalDevelopment);
                        databaseEntities.SaveChanges();
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
        }
    }
}
