using System.Windows;

namespace GIBDD
{
    /// <summary>
    /// Логика взаимодействия для Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {
        Users _user;
        public Profile(Users user)
        {
            InitializeComponent();
            _user = user;
        }

        private void Exist_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Hide();
        }

        private void Drivers_Click(object sender, RoutedEventArgs e)
        {
            new DriversWindow(_user).Show();
            Hide();
        }

        private void Licences_Click(object sender, RoutedEventArgs e)
        {
            new LicencesWindow(_user).Show();
            Hide();
        }

        private void Fines_Click(object sender, RoutedEventArgs e)
        {
            new FinesWindow(_user).Show();
            Hide();
        }
    }
}
