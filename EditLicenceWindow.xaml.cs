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

namespace GIBDD
{
    /// <summary>
    /// Логика взаимодействия для EditLicenceWindow.xaml
    /// </summary>
    public partial class EditLicenceWindow : Window
    {
        Licences _licence;

        public EditLicenceWindow(Licences licence)
        {
            InitializeComponent();
            _licence = licence;
        }
    }
}
