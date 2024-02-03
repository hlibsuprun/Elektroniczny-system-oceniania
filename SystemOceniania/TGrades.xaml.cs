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
    public partial class TGrades : Window
    {

        public TGrades()
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
            ForTeachers forTeachers = new ForTeachers();
            forTeachers.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            forTeachers.Show();
            Close();
        }
        private void Add_Grade_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("-");

        }


        private void SubmitGrade_Click(object sender, RoutedEventArgs e)
        {
            string studentLogin = txtStudentLogin.Text;
            string selectedSubject = ((ComboBoxItem)cmbSubjects.SelectedItem)?.Content.ToString();
            int grade;

            if (string.IsNullOrWhiteSpace(studentLogin) || string.IsNullOrWhiteSpace(selectedSubject) || !int.TryParse(txtGrade.Text, out grade))
            {
                MessageBox.Show("Please fill in all fields with valid information.");
                return;
            }

            if (grade < 2 || grade > 5)
            {
                MessageBox.Show("Please enter a valid grade between 2 and 5.");
                return;
            }

            using (var context = new ApplicationContext())
            {
                if (context.Users.Any(user => user.Login == studentLogin))
                {
                    Grade newGrade = new Grade(studentLogin, grade, selectedSubject);
                    context.Grades.Add(newGrade);
                    context.SaveChanges();
                    MessageBox.Show("Grade submitted successfully.");
                }
                else
                {
                    MessageBox.Show("User with the provided login does not exist.");
                }
            }
        }
    }
}
