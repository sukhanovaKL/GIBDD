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
            var driver = (sender as Button).DataContext as Drivers;
            new EditDriverWindow(driver, _user).Show();
            Hide();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            new Profile(_user).Show();
            Hide();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var driver = (sender as Button).DataContext as Drivers;
                db.Drivers.Remove(driver);
                db.SaveChanges();
                data.ItemsSource = db.Drivers.ToList();
            }
            catch
            {
                MessageBox.Show("Данного водителя нельзя удалить!");
            }
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            new CreateDriverWindow(_user).Show();
            Hide();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (Search.Text.Length != 0)
                data.ItemsSource = db.Drivers.Where(x => x.Address.Contains(Search.Text)).ToList();
            Search.ItemsSource = db.Drivers.Select(x => x.Address).ToList();
        }

        private void СancellationButton_Click(object sender, RoutedEventArgs e)
        {
            data.ItemsSource = db.Drivers.ToList();
        }
    }
}
