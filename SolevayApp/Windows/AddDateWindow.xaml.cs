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
    /// Логика взаимодействия для AddDateWindow.xaml
    /// </summary>
    public partial class AddDateWindow : Window
    {
        DatabaseEntities databaseEntities = new DatabaseEntities();

        int user_id;
        string type;
        public AddDateWindow(string _type, int _user_id)
        {
            InitializeComponent();
            user_id = _user_id;
            type = _type;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (isChecked())
            {
                try
                {
                    if (type == "Vacation")
                    {
                        Vacation vacation = new Vacation();
                        vacation.start_date = date.SelectedDate;
                        vacation.is_active = false;
                        vacation.user_id = user_id;
                        databaseEntities.Vacation.Add(vacation);
                    }

                    if (type == "SickDay")
                    {
                        SickDay sickDay = new SickDay();
                        sickDay.start_date = date.SelectedDate;
                        sickDay.is_active = false;
                        sickDay.user_id = user_id;
                        databaseEntities.SickDay.Add(sickDay);
                    }

                    if (type == "ProfessionalDevelopment")
                    {
                        ProfessionalDevelopment professionalDevelopment = new ProfessionalDevelopment();
                        professionalDevelopment.start_date = date.SelectedDate;
                        professionalDevelopment.is_active = false;
                        professionalDevelopment.user_id = user_id;
                        databaseEntities.ProfessionalDevelopment.Add(professionalDevelopment);
                    }

                    databaseEntities.SaveChanges();
                    MessageBox.Show("Данные добавлены", "Внимание!");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Внимание!");
                }
            }

        }

        private bool isChecked()
        {
            StringBuilder sb = new StringBuilder();

            if (date.SelectedDate == null)
            {
                sb.AppendLine("Введите дату");
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
