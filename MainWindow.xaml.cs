using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GIBDD
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Login.Text = "inspector";
            Password.Text = "inspector";
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var user = new Functions().Autorization(Login.Text, Password.Text);
            if (user != null)
            {
                new Profile(user).Show();
                Hide();
            }
        }
    }
}
