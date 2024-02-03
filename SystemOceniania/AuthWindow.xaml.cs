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

namespace SystemOceniania
{
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void Button_LogIn(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string pass = passBox.Password.Trim();

            if (login.Length < 5)
            {
                textBoxLogin.ToolTip = "Fail";
                textBoxLogin.Background = Brushes.DarkRed;
            }
            else if (pass.Length < 5)
            {
                passBox.ToolTip = "Fail";
                passBox.Background = Brushes.DarkRed;
            }
            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;
                passBox.ToolTip = "";
                passBox.Background = Brushes.Transparent;

                User authUser = null;
                using (ApplicationContext db = new ApplicationContext())
                {
                    authUser = db.Users.FirstOrDefault(b => b.Login == login && b.Pass == pass);
                }

                if (authUser != null)
                {
                    if (login == "teacher")
                    {
                        ForTeachers forTeachers = new ForTeachers();
                        forTeachers.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                        forTeachers.Show();
                        Close();
                    }
                    else
                    {
                        ForStudents forStudents = new ForStudents();
                        forStudents.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                        forStudents.Show();
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("Authentication failed");
                }
            }
        }
    }
}