using System.Windows;

namespace GIBDD
{
    /// <summary>
    /// Логика взаимодействия для EditDriverWindow.xaml
    /// </summary>
    public partial class EditDriverWindow : Window
    {
        Drivers _driver;

        public EditDriverWindow(Drivers driver)
        {
            InitializeComponent();
            _driver = driver;
        }
    }
}
