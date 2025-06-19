namespace ClientInterface
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void logInBtn_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                resultLabel.ForeColor = Color.OrangeRed;
                resultLabel.Text = "Enter username and password!";
                return;
            }

            if (IsValidUser(username, password))
            {
                resultLabel.ForeColor = Color.Green;
                resultLabel.Text = "Successfully logged in!";
                this.Hide();
                new MainForm().ShowDialog();
                this.Show();
            }
            else
            {
                resultLabel.ForeColor = Color.Red;
                resultLabel.Text = "Incorrect username or password!";
            }
        }

        private bool IsValidUser(string username, string password)
        {
            return username == "admin" && password == "1234";
        }

    }
}
