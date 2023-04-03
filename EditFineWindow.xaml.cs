using System.Linq;
using System.Windows;

namespace GIBDD
{
    /// <summary>
    /// Логика взаимодействия для EditFineWindow.xaml
    /// </summary>
    public partial class EditFineWindow : Window
    {
        Users _user;

        Fine _fine;

        Entities db = new Entities();

        public EditFineWindow(Users user, Fine fine)
        {
            InitializeComponent();
            _user = user;
            _fine = fine;
            IdStatus.ItemsSource = db.FineStatuses.ToList();
            IdStatus.DisplayMemberPath = "Name";
            IdDriver.Content = fine.Drivers.Fio;
            RegionNameRU.Content = fine.RegionNameRU;
            LicenceNumber.Content = fine.LicenceNumber;
            CarNumber.Content = fine.CarNumber;
            IdStatus.SelectedItem = db.FineStatuses.Where(x => x.Id == fine.IdStatus).FirstOrDefault();
            CreateDate.Content = fine.CreateDate.Value.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new FinesWindow(_user).Show();
            Hide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                var fine = db.Fine.Find(_fine.Id);
                fine.IdStatus = ((FineStatuses)(IdStatus.SelectedItem)).Id;
                db.SaveChanges();
                MessageBox.Show("Успешно!");
            }
            catch
            {
                MessageBox.Show("Ошибка!");
            }
        }
    }
}
