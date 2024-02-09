using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Pit.Data
{
    public static class EditData
    {
        public static void Save<T>(T selected, bool _EditOrNot) where T:class
        {
            if (_EditOrNot)
                PitContext.GetContext().Set<T>().Add(selected);
            PitContext.GetContext().SaveChanges();
            MessageBox.Show("Успешно");
            Navigator.MainFrame.GoBack();
        }
    }
}
