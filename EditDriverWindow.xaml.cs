using System.Windows;

namespace GIBDD
{
    /// <summary>
    /// Логика взаимодействия для EditDriverWindow.xaml
    /// </summary>
    public partial class EditDriverWindow : Window
    {
        Drivers _driver;

        Users _user;

        Entities db = new Entities();

        public EditDriverWindow(Drivers driver, Users user)
        {
            InitializeComponent();
            _driver = driver;
            _user = user;
            Driver.DataContext = _driver;

            Surname.Text = _driver.Surname;
            Name.Text = _driver.Name;
            Middlename.Text = _driver.Middlename;
            PassportSerial.Text = _driver.PassportSerial.ToString();
            PassportNumber.Text = _driver.PassportNumber.ToString();
            Email.Text = _driver.Email;
            Address.Text = _driver.Address;
            AddressLife.Text = _driver.AddressLife;
            Company.Text = _driver.Company;
            Jobname.Text = _driver.Jobname;
            Phone.Text = _driver.Phone;
            Postcode.Text = _driver.Postcode.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var updatedDriver = db.Drivers.Find(_driver.IdGuid);
                updatedDriver.Surname = Surname.Text;
                updatedDriver.Name = Name.Text;
                updatedDriver.Middlename = Middlename.Text;
                updatedDriver.PassportSerial = int.Parse(PassportSerial.Text);
                updatedDriver.PassportNumber = int.Parse(PassportNumber.Text);
                updatedDriver.Email = Email.Text;
                updatedDriver.Address = Address.Text;
                updatedDriver.AddressLife = AddressLife.Text;
                updatedDriver.Company = Company.Text;
                updatedDriver.Jobname = Jobname.Text;
                updatedDriver.Phone = Phone.Text;
                updatedDriver.Postcode = int.Parse(Postcode.Text);

                db.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new DriversWindow(_user).Show();
            Hide();
        }
    }
}
