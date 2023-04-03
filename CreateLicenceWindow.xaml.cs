using System.Linq;
using System.Windows;

namespace GIBDD
{
    /// <summary>
    /// Логика взаимодействия для CreateLicenceWindow.xaml
    /// </summary>
    public partial class CreateLicenceWindow : Window
    {
        Users _user;

        Entities db = new Entities();

        public CreateLicenceWindow(Users user)
        {
            InitializeComponent();
            _user = user;

            Color.ItemsSource = db.CarColors.Select(x => x.ColorName).ToList();
            IdStatus.ItemsSource = db.LicenceStatus.Select(x => x.Name).ToList();
            IdRegion.ItemsSource = db.Regions.Select(x => x.RegionNameRU).ToList();
            IdGuidDriver.ItemsSource = db.Drivers.ToList();
            IdGuidDriver.DisplayMemberPath = "Fio";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var newLicence = new Licences
                {
                    Id = db.Licences.Count() + 1,
                    LicenceDate = LicenceDate.SelectedDate.Value,
                    ExpireDate = ExpireDate.SelectedDate.Value,
                    Categories = Categories.Text,
                    LicenceSeries = int.Parse(LicenceSeries.Text),
                    LicenceNumber = int.Parse(LicenceNumber.Text),
                    VIN = VIN.Text,
                    Manufacturer = Manufacturer.Text,
                    Model = Model.Text,
                    Year = int.Parse(Year.Text),
                    Weight = int.Parse(Weight.Text),
                    Color = db.CarColors.Where(x => x.ColorName == Color.SelectedItem).FirstOrDefault().ColorNum,
                    TypeOfDrive = TypeOfDrive.Text,
                    IdStatus = db.LicenceStatus.Where(x => x.Name == IdStatus.SelectedItem).FirstOrDefault().Id,
                    CarNumber = CarNumber.Text,
                    IdRegion = db.Regions.Where(x => x.RegionNameRU == IdRegion.SelectedItem).FirstOrDefault().Id,
                    IdGuidDriver = ((Drivers)(IdGuidDriver.SelectedItem)).IdGuid
                };

                db.Licences.Add(newLicence);
                db.SaveChanges();
                MessageBox.Show("Успешно добавлено!");
                new LicencesWindow(_user).Show();
                Hide();
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new LicencesWindow(_user).Show();
            Hide();
        }
    }
}
