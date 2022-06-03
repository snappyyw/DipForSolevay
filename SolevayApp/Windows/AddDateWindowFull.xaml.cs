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
    /// Логика взаимодействия для AddDateWindowFull.xaml
    /// </summary>
    public partial class AddDateWindowFull : Window
    {
        DatabaseEntities databaseEntities = new DatabaseEntities();
        int user_id;

        // Событие инициализации окна
        public AddDateWindowFull(int _user_id)
        {
            InitializeComponent();
            user_id = _user_id;
        }

        // Кнопка сохранения

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (isChecked())
            {
                try
                { 
                    SickDay sickDay = new SickDay();
                    sickDay.start_date = dateStart.SelectedDate;
                    sickDay.end_date = dateEnd.SelectedDate;
                    sickDay.is_active = false;
                    sickDay.user_id = user_id;
                    databaseEntities.SickDay.Add(sickDay);

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

        // Вспомогательная функция валидации данных

        private bool isChecked()
        {
            StringBuilder sb = new StringBuilder();

            if (dateStart.SelectedDate == null)
            {
                sb.AppendLine("Введите дату начала");
            }

            if (dateEnd.SelectedDate == null)
            {
                sb.AppendLine("Введите дату конца");
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
