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

namespace Elektroniczny_system_oceniania
{
    public partial class ForTeachers : Window
    {
        public ForTeachers()
        {
            InitializeComponent();
        }

        private void Add_Schedule_Click(object sender, RoutedEventArgs e)
        {
            TAddSchedule tAddSchedule = new TAddSchedule();
            tAddSchedule.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            tAddSchedule.Show();
            Close();
        }

        private void Schedule_Click(object sender, RoutedEventArgs e)
        {
            TSchedule tSchedule = new TSchedule();
            tSchedule.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            tSchedule.Show();
            Close();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("-");
        }

        private void Add_Grade_Click(object sender, RoutedEventArgs e)
        {
            TGrades tGrades = new TGrades();
            tGrades.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            tGrades.Show();
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
