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
    /// Логика взаимодействия для InfoUserWindow.xaml
    /// </summary>
    public partial class InfoUserWindow : Window
    {
        DatabaseEntities databaseEntities = new DatabaseEntities();
        User user;
        public InfoUserWindow(User _user)
        {
            InitializeComponent();
            LableName.Content = "Пользователь " + _user.FIO;
            PersonalDate personalDate = databaseEntities.PersonalDate.FirstOrDefault(p=>p.user_id == _user.id);
            if(personalDate != null)
            {
                Post.Text = personalDate.post;
                Education.Text = personalDate.education;
                Salary.Text = personalDate.salary.ToString();
                Address.Text = personalDate.address;
            }
            user = _user;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (isChecked())
            {
                try
                {
                    PersonalDate personalDateCurrent = databaseEntities.PersonalDate.FirstOrDefault(p => p.user_id == user.id);
                    if(personalDateCurrent != null)
                    {
                        personalDateCurrent.education = Education.Text;
                        personalDateCurrent.salary = decimal.Parse(Salary.Text);
                        personalDateCurrent.address = Address.Text;
                        personalDateCurrent.post = Post.Text;
                    }
                    else
                    {
                        PersonalDate personalDate = new PersonalDate();
                        personalDate.education = Education.Text;
                        personalDate.salary = decimal.Parse(Salary.Text);
                        personalDate.address = Address.Text;
                        personalDate.post = Post.Text;
                        personalDate.user_id = user.id;
                        databaseEntities.PersonalDate.Add(personalDate);
                    }
                 
                    databaseEntities.SaveChanges();
                    MessageBox.Show("Данные сохранены", "Внимание!");
                    this.Close();
                } catch(Exception ex) 
                { 
                    MessageBox.Show(ex.Message, "Внимание!"); 
                }
              
            }
        }

        private bool isChecked()
        {
            StringBuilder sb = new StringBuilder();

            if (string.IsNullOrEmpty(Post.Text))
            {
                sb.AppendLine("Введите должность");
            }

            if (string.IsNullOrEmpty(Education.Text))
            {
                sb.AppendLine("Введите образование");
            }

            if (string.IsNullOrEmpty(Salary.Text))
            {
                sb.AppendLine("Введите зарплату");
            }

            if (string.IsNullOrEmpty(Address.Text))
            {
                sb.AppendLine("Введите адрес");
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
