using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для CreateDriverWindow.xaml
    /// </summary>
    public partial class CreateDriverWindow : Window
    {
        Users _user;

        string ImagePath;

        Entities db = new Entities();

        public CreateDriverWindow(Users user)
        {
            InitializeComponent();
            _user = user;
            SuccessLabel.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new DriversWindow(_user).Show();
            Hide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                var driver = new Drivers
                {
                    IdGuid = Guid.NewGuid(),
                    Surname = Surname.Text,
                    Name = Name.Text,
                    Middlename = Middlename.Text,
                    PassportSerial = int.Parse(PassportSerial.Text),
                    PassportNumber = int.Parse(PassportNumber.Text),
                    Email = Email.Text,
                    Address = Address.Text,
                    AddressLife = AddressLife.Text,
                    Company = Company.Text,
                    Jobname = Jobname.Text,
                    Phone = Phone.Text,
                    Postcode = int.Parse(Postcode.Text),
                    Photo = ImagePath
                };
                db.Drivers.Add(driver);

                db.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void AddPhoto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog opFD = new OpenFileDialog();
                opFD.ShowDialog();
                var imag = opFD.FileName;
                string dest = "C:/Users/79393/source/repos/GIBDD/Resources/" + System.IO.Path.GetFileName(imag);
                File.Copy(imag, dest);
                ImagePath = "/Resources/" + System.IO.Path.GetFileName(imag);
                AddPhoto.Visibility = Visibility.Hidden;
                SuccessLabel.Content = System.IO.Path.GetFileName(imag);
                SuccessLabel.Visibility = Visibility.Visible;
            }
            catch
            {
                MessageBox.Show("Попробуйте снова, возможно файл с таким именем уже существует!");
            }
        }
    }
}
