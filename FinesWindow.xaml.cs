using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace GIBDD
{
    /// <summary>
    /// Логика взаимодействия для FinesWindow.xaml
    /// </summary>
    public partial class FinesWindow : Window
    {
        Users _user;

        Entities db = new Entities();

        public FinesWindow(Users user)
        {
            InitializeComponent();
            _user = user;
            Fines.Background = new SolidColorBrush(Color.FromArgb(100, 181, 213, 202));
            BackButton.Background = new SolidColorBrush(Color.FromArgb(100, 224, 169, 175));
            data.Background = new SolidColorBrush(Color.FromArgb(100, 224, 169, 175));
            data.ItemsSource = db.Fine.ToList();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            new Profile(_user).Show();
            Hide();
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
