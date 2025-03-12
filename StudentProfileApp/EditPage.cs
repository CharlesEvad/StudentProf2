using System;
using System.Windows.Forms;

namespace StudentProf
{
    public partial class EditPage : Form
    {
        private Student_Prof student;

        public EditPage(Student_Prof student)
        {
            InitializeComponent();
            this.student = student;
            LoadStudentInfo();
        }

        private void LoadStudentInfo()
        {
            NameTextBox.Text = student.Name;
            AgeTextBox.Text = student.Age.ToString();
            AddressTextBox.Text = student.Address;
            ContactNumberTextBox.Text = student.ContactNumber;
            EmailAddressTextBox.Text = student.EmailAddress;
            CourseComboBox.Text = student.CourseYear.Split(' ')[0];
            YearComboBox.Text = student.CourseYear.Split(' ')[1];
            GuardianTextBox.Text = student.Guardian;
            GuardianContactTextBox.Text = student.GuardianContactNumber;
            HobbiesTextBox.Text = student.Hobbies;
            NicknameTextBox.Text = student.Nickname;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                student.Name = NameTextBox.Text;
                student.Age = int.Parse(AgeTextBox.Text);
                student.Address = AddressTextBox.Text;
                student.ContactNumber = ContactNumberTextBox.Text;
                student.EmailAddress = EmailAddressTextBox.Text;
                student.CourseYear = $"{CourseComboBox.Text} {YearComboBox.Text}";
                student.Guardian = GuardianTextBox.Text;
                student.GuardianContactNumber = GuardianContactTextBox.Text;
                student.Hobbies = HobbiesTextBox.Text;
                student.Nickname = NicknameTextBox.Text;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text) ||
                string.IsNullOrWhiteSpace(AgeTextBox.Text) ||
                string.IsNullOrWhiteSpace(AddressTextBox.Text) ||
                string.IsNullOrWhiteSpace(ContactNumberTextBox.Text) ||
                string.IsNullOrWhiteSpace(EmailAddressTextBox.Text) ||
                string.IsNullOrWhiteSpace(GuardianTextBox.Text) ||
                string.IsNullOrWhiteSpace(GuardianContactTextBox.Text) ||
                CourseComboBox.SelectedIndex == -1 ||
                YearComboBox.SelectedIndex == -1)
            {
                ErrorLabel.Text = "All fields are required.";
                return false;
            }

            if (!int.TryParse(AgeTextBox.Text, out _) ||
                !System.Text.RegularExpressions.Regex.IsMatch(ContactNumberTextBox.Text, @"^\+63\d{10}$") ||
                !System.Text.RegularExpressions.Regex.IsMatch(GuardianContactTextBox.Text, @"^\+63\d{10}$"))
            {
                ErrorLabel.Text = "Age must be numeric and contact numbers must be in the format +63XXXXXXXXXX.";
                return false;
            }

            return true;
        }
    }
}