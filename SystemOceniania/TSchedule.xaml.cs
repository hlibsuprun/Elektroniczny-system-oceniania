using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
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
    public partial class TSchedule : Window
    {
        private string connectionString = "Data Source=System.db;Version=3;";
        public TSchedule()
        {
            InitializeComponent();
            scheduleLoad();
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
            MessageBox.Show("-");
        }
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            ForTeachers forTeachers = new ForTeachers();
            forTeachers.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            forTeachers.Show();
            Close();
        }
        private void Add_Grade_Click(object sender, RoutedEventArgs e)
        {
            TGrades tGrades = new TGrades();
            tGrades.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            tGrades.Show();
            Close();

        }

        private void scheduleLoad()
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT subject, day, time, forST FROM Schedules WHERE forST = 'teacher';";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            dgTSchedule.ItemsSource = dataTable.DefaultView;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}