using Pit.Data;
using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;


namespace Pit
{
   
    public partial class Authorization : Page
    {
        public Authorization()
        {
            InitializeComponent();
        }
        private void Enter(object sender, RoutedEventArgs e)
        {
            if (Login.Text == "" || Password.Password == "")
             MessageBox.Show("Данные не были введены"); 
            else
            {
                var crypt = System.Security.Cryptography.SHA256.Create();
                var notfinal = crypt.ComputeHash(Encoding.UTF8.GetBytes(Password.Password));
                var final = Convert.ToBase64String(notfinal);
                Employee user = PitContext.GetContext().Employee.FirstOrDefault(p => p.Login == Login.Text&&p.Password==final);
                if (user == null)
                {
                    MessageBox.Show("Неправильно введены данные или пользователя не существует");
                }
                else
                { 
                if (user.isAdmin==true)
                {
                        Password.Password = "";
                        Login.Text = "";
                        Navigator.MainFrame.Navigate(new AdminPage());
                }
                if(user.isAdmin==false)
                {
                        UserData.EmployeeID=user.EmployeeID;
                        Password.Password = "";
                        Login.Text = "";
                    Navigator.MainFrame.Navigate(new PlanePage());
                }
                }
            }
        }
        private void Register(object sender, RoutedEventArgs e)
        {
            Navigator.MainFrame.Navigate(new Register());
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox.IsChecked == true)
            {
                Password.Visibility = Visibility.Hidden;
                TextPassword.Text = Password.Password;
                TextPassword.Visibility = Visibility.Visible;
            }
            else
            {
                TextPassword.Visibility = Visibility.Hidden;
                Password.Visibility = Visibility.Visible;
            }
        }
    }
   
}
