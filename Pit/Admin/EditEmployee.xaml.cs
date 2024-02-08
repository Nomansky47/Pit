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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pit
{
    
    public partial class EditEmployee : Page
    {
        private Employee _current = new Employee();
        bool _EditOrNot;
        public EditEmployee(Employee selected, bool EditOrNot)
        {
            InitializeComponent();
            _EditOrNot = EditOrNot;
            if (selected != null)
            {
                Login.IsEnabled = false;
                Password.IsEnabled = false;
                _current = selected;
            }
            DataContext = _current;
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();
            if (string.IsNullOrEmpty(Patronymic.Text) || string.IsNullOrEmpty(Name.Text))
                error.AppendLine("Ошибка ввода, данные не были введены");
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }
            try
            {
                if (_EditOrNot)
                    PitContext.GetContext().Employee.Add(_current);
                PitContext.GetContext().SaveChanges();
                MessageBox.Show("Успешно");
                Navigator.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + " " + ex.GetType() + " " + ex.StackTrace);
            }
        }

    }
    
}
