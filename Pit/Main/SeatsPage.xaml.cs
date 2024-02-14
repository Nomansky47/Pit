using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;
namespace Pit
{
    
    public partial class SeatsPage : Page
    {
        private void ButtonsAdd(int j,Panel panel, List<Reserved> Reserved)
        {
            for (int i = 1; i < 6; i++)
            {
                Button button = new Button();
                button.Name = "b" + j.ToString() + i.ToString(); //наименование для кнопки, чтобы в будущем определять ряд и номер места
                button.Content = j.ToString() + " "+ i.ToString(); //отображение ряда и места
                if (Reserved.Exists(p =>p.Row ==j && p.Seat == i))
                {
                    button.Background = Brushes.Red; //если в базе данных уже зарезервировано место, то повторно купить не получится
                }
                else button.Click += ButtonOnClick; //иначе можно зарезервировать
                button.Width = 40;
                button.Height = 40;
                panel.Children.Add(button); // добавление кнопки на панель
            }
        }
        public SeatsPage(Visitors _selected)
        {
            InitializeComponent(); 
            DataContext = _selected;
            List<Reserved> Reserved= 
    PitContext.GetContext().Reserved.ToList();
            Panel[] panels = new Panel[15] {Panel1,Panel2, Panel3, Panel4, Panel5, Panel6, Panel7, Panel8, Panel9,
            Panel10, Panel11, Panel12, Panel13, Panel14, Panel15};
            for (int i = 0;i< 30 / 5; i++)
            {
                ButtonsAdd(i+1, panels[i], Reserved);
            }
        }
        private void ButtonOnClick(object sender, EventArgs eventArgs)
        {
            Button button = (Button)sender;
            button.Click -= ButtonOnClick;
            button.Background = Brushes.Red;
            Reserved Reserved = new Reserved();
            Reserved.Price = 1000;
            if (button.Name.Length==3)
            {
                Reserved.Row = int.Parse(button.Name[1].ToString());
                Reserved.Seat = int.Parse(button.Name[2].ToString());
            
            }
            else
            {
                Reserved.Row = int.Parse(button.Name[1].ToString() + button.Name[2]);
                Reserved.Seat = int.Parse(button.Name[3].ToString());
            }
            PitContext.GetContext().Reserved.Add(Reserved);
            PitContext.GetContext().SaveChanges();
        }
    }
}
