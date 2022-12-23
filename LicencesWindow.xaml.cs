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
            Search.ItemsSource = db.Licences.Select(x => x.VIN).ToList();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            new Profile(_user).Show();
            Hide();
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            var licence = (sender as Button).DataContext as Licences;
            new EditLicenceWindow(licence, _user).Show();
            Hide();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if(Search.Text.Length != 0)
                data.ItemsSource = db.Licences.Where(x => x.VIN.Contains(Search.Text)).ToList();
            Search.ItemsSource = db.Licences.Select(x => x.VIN).ToList();

        }

        private void СancellationButton_Click(object sender, RoutedEventArgs e)
        {
            data.ItemsSource = db.Licences.ToList();
        }

        private void BackButton_Click_1(object sender, RoutedEventArgs e)
        {
            new Profile(_user).Show();
            Hide();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            new CreateLicenceWindow(_user).Show();
            Hide();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var licence = (sender as Button).DataContext as Licences;
                db.Licences.Remove(licence);
                db.SaveChanges();
                data.ItemsSource = db.Licences.ToList();
            }
            catch
            {
                MessageBox.Show("Нельзя удалить данное водительское удостоверение!");
            }
        }
    }
}
