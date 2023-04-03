using System.Windows;

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
            Password.Password = "inspector";
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var user = new Functions().Autorization(Login.Text, Password.Password);
                if (user != null)
                {
                    new Profile(user).Show();
                    Hide();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }
    }
}
