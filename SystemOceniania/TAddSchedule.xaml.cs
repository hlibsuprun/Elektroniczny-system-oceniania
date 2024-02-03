using System;
using System.Collections.Generic;
using System.Data.SQLite;
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
    public partial class TAddSchedule : Window
    {
        private string connectionString = "Data Source=System.db;Version=3;";
        public TAddSchedule()
        {
            InitializeComponent();
        }
        private void Add_Schedule_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("-");
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

        private void Add_Schedules_Click(object sender, RoutedEventArgs e)
        {
            string selectedSubject = ((ComboBoxItem)cmbSubjects.SelectedItem)?.Content.ToString();
            DateTime? selectedDate = dpSelectedDate.SelectedDate;
            string selectedTimeSlot = ((ComboBoxItem)cmbTimeSlots.SelectedItem)?.Content.ToString();
            string selectedFor = ((ComboBoxItem)cmbFor.SelectedItem)?.Content.ToString();

            if (string.IsNullOrWhiteSpace(selectedSubject) || selectedDate == null || string.IsNullOrWhiteSpace(selectedTimeSlot) || string.IsNullOrWhiteSpace(selectedFor))
            {
                MessageBox.Show("Please fill in all fields with valid information.");
                return;
            }

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO Schedules (subject, day, time, forST) VALUES (@subject, @day, @time, @forST);";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@subject", selectedSubject);
                        command.Parameters.AddWithValue("@day", selectedDate.Value.DayOfWeek.ToString());
                        command.Parameters.AddWithValue("@time", selectedTimeSlot);
                        command.Parameters.AddWithValue("@forST", selectedFor);

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Schedule added successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
