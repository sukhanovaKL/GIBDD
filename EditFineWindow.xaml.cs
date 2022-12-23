using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }
    }
}
