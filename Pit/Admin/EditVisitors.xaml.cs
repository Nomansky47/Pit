using Pit.Data;
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
    
    public partial class EditVisitors : Page
    {
        private Visitors _current = new Visitors();
        bool _EditOrNot;
        public EditVisitors(Visitors selected, bool EditOrNot)
        {
            InitializeComponent();
            _EditOrNot = EditOrNot;
            if (selected != null)
            {
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
                EditData.Save(_current,_EditOrNot);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + " " + ex.GetType() + " " + ex.StackTrace);
            }
        }

    }
    
}
