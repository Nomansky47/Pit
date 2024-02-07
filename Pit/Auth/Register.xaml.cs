using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Pit
{
    public partial class Register : Page
    {
        public Register()
        {
            InitializeComponent();
        }
        private Employee _currentUser = new Employee();
        private void Registration(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();
        if (PitContext.GetContext().Employee.ToList().Exists(p => p.Login == Login.Text))
                error.AppendLine("Данный пользователь уже существует, попробуйте поменять логин");
            if (string.IsNullOrEmpty(Nname.Text) || string.IsNullOrEmpty(SecondName.Text)|| string.IsNullOrEmpty(ThirdName.Text)|| string.IsNullOrEmpty(Password.Text)|| string.IsNullOrEmpty(Login.Text))
                error.AppendLine("Ошибка ввода, данные не были введены");
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }
            try
            {
                _currentUser.Surname= SecondName.Text.ToString();
                _currentUser.Name = Nname.Text.ToString();
                _currentUser.Patronymic=ThirdName.Text.ToString();
                var login= Login.Text.ToString();
                _currentUser.Login = login;
                if (login == "admin")
                    _currentUser.isAdmin = true;
                else
                    _currentUser.isAdmin = false;
                var crypt = System.Security.Cryptography.SHA256.Create();
                var final = crypt.ComputeHash(Encoding.UTF8.GetBytes(Password.Text.ToString()));
                _currentUser.Password = Convert.ToBase64String(final);
                PitContext.GetContext().Employee.Add(_currentUser);
                PitContext.GetContext().SaveChanges();
                Navigator.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + " " + ex.GetType() + " " + ex.StackTrace);
            }
          
        }
        
    }
}
