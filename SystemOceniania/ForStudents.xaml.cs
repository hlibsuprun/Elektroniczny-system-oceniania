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
    public partial class ForStudents : Window
    {
        public ForStudents()
        {
            InitializeComponent();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("-");
        }

        private void Grade_Click(object sender, RoutedEventArgs e)
        {
            Grades grades = new Grades();
            grades.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            grades.Show();
            Close();
        }

        private void Schedule_Click(object sender, RoutedEventArgs e)
        {
            Schedule schedule = new Schedule();
            schedule.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            schedule.Show();
            Close();
        }
        private void Button_LogOut(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            authWindow.Show();
            Close();

        }
    }
}
