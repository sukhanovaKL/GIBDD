using Microsoft.Win32;
using System.IO;
using System.Linq;
using System.Windows;


namespace GIBDD
{
    /// <summary>
    /// Логика взаимодействия для CreateFineWindow.xaml
    /// </summary>
    public partial class CreateFineWindow : Window
    {
        byte[] _imageBytes;

        Users _user;

        Entities db = new Entities();

        public CreateFineWindow(Users user)
        {
            InitializeComponent();
            SuccessLabel.Visibility = Visibility.Hidden;
            _user = user;
            IdStatus.ItemsSource = db.FineStatuses.ToList();
            IdStatus.DisplayMemberPath = "Name";
            IdDriver.ItemsSource = db.Drivers.ToList();
            IdDriver.DisplayMemberPath = "Fio";
            RegionNameRU.ItemsSource = db.Regions.ToList();
            RegionNameRU.DisplayMemberPath = "RegionNameRU";
            LicenceNumber.ItemsSource = db.Licences.ToList();
            LicenceNumber.DisplayMemberPath = "LicenceNumber";
        }

        private void AddPhoto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.ShowDialog();
                var imag = openFileDialog.FileName;
                _imageBytes = File.ReadAllBytes(openFileDialog.FileName);
                AddPhoto.Visibility = Visibility.Hidden;
                SuccessLabel.Content = Path.GetFileName(imag);
                SuccessLabel.Visibility = Visibility.Visible;
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                var newFine = new Fine
                {
                    Id = db.Fine.Count(),
                    CarNumber = CarNumber.Text,
                    RegionNameRU = ((Regions)(RegionNameRU.SelectedItem)).RegionNameRU,
                    LicenceNumber = ((Licences)(LicenceNumber.SelectedItem)).LicenceNumber,
                    CreateDate = CreateDate.SelectedDate,
                    Photo = _imageBytes,
                    IdStatus = ((FineStatuses)(IdStatus.SelectedItem)).Id,
                    IdDriver = ((Drivers)(IdDriver.SelectedItem)).IdGuid
                };
                db.Fine.Add(newFine);
                db.SaveChanges();

                new FinesWindow(_user).Show();
                Hide();
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new FinesWindow(_user).Show();
            Hide();
        }
    }
}
