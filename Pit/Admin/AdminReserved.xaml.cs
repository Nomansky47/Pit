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

namespace Pit
{
    
    public partial class AdminReserved : Page
    {
        public AdminReserved()
        {
            InitializeComponent();
        }
        private void EditClick(object sender, RoutedEventArgs e)
        {
            Navigator.MainFrame.Navigate(new EditReserved((sender as Button).DataContext as Reserved,false));
        }
        public void AddClick(object sender, RoutedEventArgs e)
        {
            Navigator.MainFrame.Navigate(new EditReserved(null,true));
        }
        private void DelClick(object sender, RoutedEventArgs e) 
        {
            var Removing = MyGrid.SelectedItems.Cast<Reserved>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить {Removing.Count} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try 
                {
                    PitContext.GetContext().Reserved.RemoveRange(Removing);
                    PitContext.GetContext().SaveChanges();
                    MessageBox.Show("Успешно удалено");
                    MyGrid.ItemsSource = PitContext.GetContext().Reserved.ToList();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility==Visibility.Visible) 
            {
                PitContext.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                MyGrid.ItemsSource = PitContext.GetContext().Reserved.ToList();
            }
        }
    }
    
}
