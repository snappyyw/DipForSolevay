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
    /// Логика взаимодействия для AcceptDateWindow.xaml
    /// </summary>
    public partial class AcceptDateWindow : Window
    {
        DatabaseEntities databaseEntities = new DatabaseEntities();
        int id;
        string type;
        public AcceptDateWindow(int _id, string _type)
        {
            InitializeComponent();
            id = _id;
            type = _type;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (isChecked())
            {
                try
                {
                    if (type == "Vacation")
                    {
                        Vacation vacationCurrent = databaseEntities.Vacation.FirstOrDefault(v => v.id == id);
                        vacationCurrent.end_date = date.SelectedDate;
                        vacationCurrent.is_active = true;
                    }
                    if(type == "ProfessionalDevelopment")
                    {
                        ProfessionalDevelopment professionalDevelopmentCurrent = databaseEntities.ProfessionalDevelopment.FirstOrDefault(v => v.id == id);
                        professionalDevelopmentCurrent.end_date = date.SelectedDate;
                        professionalDevelopmentCurrent.is_active = true;
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
    }
}
