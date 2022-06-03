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
    /// Логика взаимодействия для AddedUserAdminWindow.xaml
    /// </summary>
    public partial class AddedUserAdminWindow : Window
    {
        DatabaseEntities databaseEntities = new DatabaseEntities();
        List<string> list = new List<string>() { "Пользователь", "HR" };
        User user = new User();

        // Событие инициализации окна для добавления
        public AddedUserAdminWindow()
        {
            InitializeComponent();
            comboBox.ItemsSource = list;
            comboBox.SelectedIndex = 0;
        }

        // Событие инициализации окна для изменения

        public AddedUserAdminWindow(User _user)
        {
            InitializeComponent();
            comboBox.ItemsSource = list;
            button.Content = "Изменить";
            FIO.Text = _user.FIO;
            Password.Password = _user.password;
            Login.Text = _user.login;
            if (_user.role == "Пользователь")
            {
                comboBox.SelectedIndex = 0;
            }
            else
            {
                comboBox.SelectedIndex = 1;
            }
            user = _user;
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
                        User userCurrent = databaseEntities.User.FirstOrDefault(u=> u.id == user.id);
                        userCurrent.FIO = FIO.Text;
                        userCurrent.password = Password.Password;
                        userCurrent.login = Login.Text;
                        userCurrent.role = comboBox.Text;

                        MessageBox.Show("Данные изменены", "Внимание!");
                    }
                    else
                    {
                        // Добавление 
                        User user = new User();
                        user.FIO = FIO.Text;
                        user.password = Password.Password;
                        user.login = Login.Text;
                        user.role = comboBox.Text;
                        user.start_date = DateTime.Now;
                        databaseEntities.User.Add(user);

                        MessageBox.Show("Пользователь добавлен", "Внимание!");
                    }
                    databaseEntities.SaveChanges();
                    this.Close();
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,"Внимание!");
                }
            }
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

            if (string.IsNullOrEmpty(comboBox.Text))
            {
                sb.AppendLine("Выберите роль");
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
