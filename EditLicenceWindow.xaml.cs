using System.Linq;
using System.Windows;

namespace GIBDD
{
    /// <summary>
    /// Логика взаимодействия для EditLicenceWindow.xaml
    /// </summary>
    public partial class EditLicenceWindow : Window
    {
        Licences _licence;

        Users _user;

        Entities db = new Entities();

        public EditLicenceWindow(Licences licence, Users user)
        {
            InitializeComponent();
            _licence = licence;
            _user = user;
            Color.ItemsSource = db.CarColors.Select(x => x.ColorName).ToList();
            IdStatus.ItemsSource = db.LicenceStatus.Select(x => x.Name).ToList();
            IdRegion.ItemsSource = db.Regions.Select(x => x.RegionNameRU).ToList();

            LicenceDate.SelectedDate = _licence.LicenceDate;
            ExpireDate.SelectedDate = _licence.ExpireDate;
            Categories.Text = _licence.Categories;
            LicenceSeries.Text = _licence.LicenceSeries.ToString();
            LicenceNumber.Text = _licence.LicenceNumber.ToString();
            VIN.Text = _licence.VIN;
            Manufacturer.Text = _licence.Manufacturer;
            Model.Text = _licence.Model;
            Year.Text = _licence.Year.ToString();
            Weight.Text = _licence.Weight.ToString();
            Color.SelectedItem = _licence.CarColors.ColorName;
            TypeOfDrive.Text = _licence.TypeOfDrive;
            IdStatus.SelectedItem = _licence.LicenceStatus.Name;
            CarNumber.Text = _licence.CarNumber;
            IdRegion.SelectedItem = _licence.Regions.RegionNameRU;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new LicencesWindow(_user).Show();
            Hide();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var updateLicence = db.Licences.Find(_licence.Id);

                updateLicence.LicenceDate = LicenceDate.SelectedDate.Value;
                updateLicence.ExpireDate = ExpireDate.SelectedDate.Value;
                updateLicence.Categories = Categories.Text;
                updateLicence.LicenceSeries = int.Parse(LicenceSeries.Text);
                updateLicence.LicenceNumber = int.Parse(LicenceNumber.Text);
                updateLicence.VIN = VIN.Text;
                updateLicence.Manufacturer = Manufacturer.Text;
                updateLicence.Model = Model.Text;
                updateLicence.Year = int.Parse(Year.Text);
                updateLicence.Weight = int.Parse(Weight.Text);
                updateLicence.Color = db.CarColors.Where(x => x.ColorName == Color.SelectedItem).FirstOrDefault().ColorNum;
                updateLicence.TypeOfDrive = TypeOfDrive.Text;
                updateLicence.IdStatus = db.LicenceStatus.Where(x => x.Name == IdStatus.SelectedItem).FirstOrDefault().Id;
                updateLicence.CarNumber = CarNumber.Text;
                updateLicence.IdRegion = db.Regions.Where(x => x.RegionNameRU == IdRegion.SelectedItem).FirstOrDefault().Id;

                db.SaveChanges();
                MessageBox.Show("Изменения сохранены!");
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }
    }
}
