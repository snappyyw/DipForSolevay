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
    /// Логика взаимодействия для AddedUserHRWindow.xaml
    /// </summary>
    public partial class AddedUserHRWindow : Window
    {
        DatabaseEntities databaseEntities = new DatabaseEntities();
        User user = new User();

        // Событие инициализации окна для добавления

        public AddedUserHRWindow()
        {
            InitializeComponent();
        }

        // Событие инициализации окна для изменения

        public AddedUserHRWindow(User _user)
        {
            InitializeComponent();
            button.Content = "Изменить";
            FIO.Text = _user.FIO;
            Password.Password = _user.password;
            Login.Text = _user.login;
            user = _user;
        }

        // Вспомогательная функция валидации данных

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

        // Кнопка сохранения/изменения

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (isChecked())
            {
                try
                {

                    if (user.id != 0)
                    {
                        // Изменение
                        User userCurrent = databaseEntities.User.FirstOrDefault(u => u.id == user.id);
                        userCurrent.FIO = FIO.Text;
                        userCurrent.password = Password.Password;
                        userCurrent.login = Login.Text;

                        MessageBox.Show("Данные изменены", "Внимание!");
                    }
                    else
                    {
                        // Добавление 
                        User user = new User();
                        user.FIO = FIO.Text;
                        user.password = Password.Password;
                        user.login = Login.Text;
                        user.role = "Пользователь";
                        user.start_date = DateTime.Now;
                        databaseEntities.User.Add(user);

                        MessageBox.Show("Пользователь добавлен", "Внимание!");
                    }
                    databaseEntities.SaveChanges();
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
