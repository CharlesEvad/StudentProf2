using System;
using System.Windows.Forms;

namespace StudentProf
{
    public partial class StudentPage : Form
    {
        private Student_Prof student;

        public StudentPage()
        {
            InitializeComponent();
            student = new Student_Prof
            {
                Name = "Jessie Lou D. Bugarin",
                Age = 20,
                Address = "M.H.D.P Bayambang, Pangasinan",
                ContactNumber = "+639385747451",
                EmailAddress = "izzybugarin@gmail.com",
                CourseYear = "BSIT Third Year",
                Guardian = "Jesus Bugarin",
                GuardianContactNumber = "+63957417416",
                Hobbies = "Going Out",
                Nickname = "izzy"
            };
            DisplayStudentInfo();
        }

        private void DisplayStudentInfo()
        {
            NameTextBox.Text = student.Name;
            AgeTextBox.Text = student.Age.ToString();
            AddressTextBox.Text = student.Address;
            ContactNumberTextBox.Text = student.ContactNumber;
            EmailAddressTextBox.Text = student.EmailAddress;
            CourseYearTextBox.Text = student.CourseYear;
            GuardianTextBox.Text = student.Guardian;
            GuardianContactTextBox.Text = student.GuardianContactNumber;
            HobbiesTextBox.Text = student.Hobbies;
            NicknameTextBox.Text = student.Nickname;
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            EditPage editPage = new EditPage(student);
            if (editPage.ShowDialog() == DialogResult.OK)
            {
                DisplayStudentInfo();
            }
        }
    }
}