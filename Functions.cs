using System.Linq;
using System.Windows;

namespace GIBDD
{
    class Functions
    {
        Entities db = new Entities();
        public Users Autorization(string log, string pass)
        {
            var user = db.Users.Where(x => x.Login == log && x.Password == pass).FirstOrDefault();
            if (user != null)
            {
                MessageBox.Show("Успешно!");
                return user;
            }
            else
            {
                MessageBox.Show("Логин или пароль введены неверно!");
                return null;
            }    
        }
    }
}
