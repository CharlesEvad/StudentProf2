using System;
using System.Windows.Forms;

namespace StudentProf
{
    public partial class LoginPage : Form
    {
        private int loginAttempts = 0;
        private const int maxAttempts = 5;
        private const string mockUsername = "izzy";
        private const string mockPassword = "izzy123";

        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;

            if (username == mockUsername && password == mockPassword)
            {
                // Open Student Page
                StudentPage studentPage = new StudentPage();
                studentPage.Show();
                this.Hide();
            }
            else
            {
                loginAttempts++;
                if (loginAttempts >= maxAttempts)
                {
                    ErrorLabel.Text = "Maximum attempts reached. Click here to reset your password.";
                    ResetLinkLabel.Visible = true;
                }
                else
                {
                    ErrorLabel.Text = "Invalid username or password. Try again.";
                }
            }
        }
    }
}