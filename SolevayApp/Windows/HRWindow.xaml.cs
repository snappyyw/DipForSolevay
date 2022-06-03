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
    /// Логика взаимодействия для HRWindow.xaml
    /// </summary>
    public partial class HRWindow : Window
    {
        DatabaseEntities databaseEntities = new DatabaseEntities();

        // Событие инициализации окна

        public HRWindow(User _user)
        {
            InitializeComponent();
            dateGrid1.ItemsSource = databaseEntities.User.Where(u => u.role == "Пользователь").ToList();
            dateGrid2.ItemsSource = databaseEntities.Vacation.ToList();
            dateGrid3.ItemsSource = databaseEntities.SickDay.ToList();
            dateGrid4.ItemsSource = databaseEntities.ProfessionalDevelopment.ToList();
            lable.Content = "Привет " + _user.login;
        }

        // Кнопка обновления данных

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            databaseEntities.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            dateGrid1.ItemsSource = databaseEntities.User.Where(u => u.role == "Пользователь").ToList();
            dateGrid2.ItemsSource = databaseEntities.Vacation.ToList();
            dateGrid3.ItemsSource = databaseEntities.SickDay.ToList();
            dateGrid4.ItemsSource = databaseEntities.ProfessionalDevelopment.ToList();
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddedUserHRWindow addedUserHRWindow = new AddedUserHRWindow();
            addedUserHRWindow.Show();
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            if (dateGrid1.SelectedItems.Count == 1)
            {
                User user = (User)dateGrid1.SelectedItems[0];
                AddedUserHRWindow addedUserHRWindow = new AddedUserHRWindow(user);
                addedUserHRWindow.Show();
            }
        }

        // Кнопка удаления данных

        private void Button_Click5(object sender, RoutedEventArgs e)
        {
            if (dateGrid2.SelectedItems.Count == 1)
            {
                Vacation vacation = (Vacation)dateGrid2.SelectedItems[0];
                if (MessageBox.Show("Удалить?", "Внимание!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    try
                    {
                        databaseEntities.Vacation.Remove(vacation);
                        databaseEntities.SaveChanges();
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
        }

        private void Button_Click7(object sender, RoutedEventArgs e)
        {
            if (dateGrid2.SelectedItems.Count == 1)
            {
                Vacation vacation = (Vacation)dateGrid2.SelectedItems[0];

                AcceptDateWindow acceptDateWindow = new AcceptDateWindow(vacation.id, "Vacation");
                acceptDateWindow.Show();
            }
        }

        private void Button_Click6(object sender, RoutedEventArgs e)
        {
            if (dateGrid3.SelectedItems.Count == 1)
            {
                try
                {
                    SickDay sickDay = (SickDay)dateGrid3.SelectedItems[0];

                    SickDay sickDayCurrent = databaseEntities.SickDay.FirstOrDefault(s => s.id == sickDay.id);
                    sickDayCurrent.is_active = true;
                    databaseEntities.SaveChanges();
                    MessageBox.Show("Больничный одобрен", "Внимание!");
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Внимание!");
                }
            }
        }

        // Кнопка удаления данных

        private void Button_Click8(object sender, RoutedEventArgs e)
        {
            if (dateGrid3.SelectedItems.Count == 1)
            {
                SickDay sickDay = (SickDay)dateGrid3.SelectedItems[0];
                if (MessageBox.Show("Удалить?", "Внимание!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
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

        // Кнопка удаления данных

        private void Button_Click9(object sender, RoutedEventArgs e)
        {
            if (dateGrid4.SelectedItems.Count == 1)
            {
                ProfessionalDevelopment professionalDevelopment = (ProfessionalDevelopment)dateGrid4.SelectedItems[0];
                if (MessageBox.Show("Удалить?", "Внимание!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
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

        private void Button_Click10(object sender, RoutedEventArgs e)
        {
            if (dateGrid4.SelectedItems.Count == 1)
            {
                ProfessionalDevelopment professionalDevelopment = (ProfessionalDevelopment)dateGrid4.SelectedItems[0];

                AcceptDateWindow acceptDateWindow = new AcceptDateWindow(professionalDevelopment.id, "ProfessionalDevelopment");
                acceptDateWindow.Show();
            }
        }

        private void Button_Click11(object sender, RoutedEventArgs e)
        {
            if (dateGrid1.SelectedItems.Count == 1)
            {
                User user = (User)dateGrid1.SelectedItems[0];
                InfoUserWindow addedUserHRWindow = new InfoUserWindow(user);
                addedUserHRWindow.Show();
            }
        }
    }
}
