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

namespace Pit.Main
{
    public partial class ChoosePage : Page
    {
        public ChoosePage()
        {
            InitializeComponent();
        }

        private void Find_Click(object sender, RoutedEventArgs e)
        {
            Visitors client;
            if (Surname.Text != null && Surname.Text != "" && ClientName.Text != "" && ClientName.Text != null)
            {
                if (Patronymic.Text != null || Patronymic.Text != "")
                    client = PitContext.GetContext().Visitors.FirstOrDefault(p => p.Surname == Surname.Text && p.Name == ClientName.Text && p.Patronymic == Patronymic.Text);
                else client = PitContext.GetContext().Visitors.FirstOrDefault(p => p.Surname == Surname.Text && p.Name == ClientName.Text);
                if (client != null)
                {
                    if (client.isBanned)
                    {
                        MessageBox.Show("Пользователь заблокирован");
                    }
                    else
                    {
                        MessageBox.Show("Пользователь найден!");
                        Navigator.MainFrame.Navigate(new SeatsPage(client.VisitorID));
                    }
                }
                else MessageBox.Show("Пользователь не найден!");
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Visitors visitor = new Visitors();
            if (Surname.Text != null && Surname.Text != "" && ClientName.Text != "" && ClientName.Text != null)
            {
                if (Patronymic.Text != "" && Patronymic.Text != null)
                    visitor.Patronymic = Patronymic.Text;
                visitor.Name= ClientName.Text;
                visitor.Surname= Surname.Text;
                PitContext.GetContext().Visitors.Add(visitor);
                PitContext.GetContext().SaveChanges();
            }
        }
    }
}
