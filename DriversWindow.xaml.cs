using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GIBDD
{
    /// <summary>
    /// Логика взаимодействия для DriversWindow.xaml
    /// </summary>
    public partial class DriversWindow : Window
    {
        Entities db = new Entities();

        Users _user;

        public DriversWindow(Users user)
        {
            InitializeComponent();
            data.ItemsSource = db.Drivers.ToList();
            _user = user;
            Search.ItemsSource = db.Drivers.Select(x => x.Address).ToList();
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            var f = (sender as Button).DataContext as Drivers;
            new EditDriverWindow(f).Show();
            Hide();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            new Profile(_user).Show();
            Hide();
        }
    }
}
