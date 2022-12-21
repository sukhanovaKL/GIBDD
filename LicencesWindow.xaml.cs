using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GIBDD
{
    /// <summary>
    /// Логика взаимодействия для LicencesWindow.xaml
    /// </summary>
    public partial class LicencesWindow : Window
    {
        Users _user;

        Entities db = new Entities();

        public LicencesWindow(Users user)
        {
            InitializeComponent();
            _user = user;
            data.ItemsSource = db.Licences.ToList();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            new Profile(_user).Show();
            Hide();
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            var f = (sender as Button).DataContext as Licences;
            new EditLicenceWindow(f).Show();
            Hide();
        }
    }
}
