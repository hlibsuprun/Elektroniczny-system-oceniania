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
    public partial class Schedule : Window
    {
        ApplicationContext db;
        private string connectionString = "Data Source=System.db;Version=3;";
        public Schedule()
        {
            InitializeComponent();
            scheduleLoad();
            db = new ApplicationContext();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            ForStudents forStudents = new ForStudents();
            forStudents.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            forStudents.Show();
            Close();
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
            MessageBox.Show("-");
        }

        private void scheduleLoad()
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT subject, day, time, forST FROM Schedules WHERE forST = 'student';";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            dgSchedule.ItemsSource = dataTable.DefaultView;
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
