using SpyCommunicationLib;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientInterface
{
    public partial class LoginForm : Form
    {
        private readonly ClientService _clientService = new ClientService();

        public LoginForm()
        {
            InitializeComponent();
            textBox1.Text = "admin";
            textBox2.Text = "admin123";
        }

        private async void logInBtn_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                resultLabel.ForeColor = Color.OrangeRed;
                resultLabel.Text = "Enter username and password!";
                return;
            }

            resultLabel.ForeColor = Color.DarkOrange;
            resultLabel.Text = "Connecting...";

            bool success = await _clientService.LoginAsync(username, password);

            if (success)
            {
                resultLabel.ForeColor = Color.Green;
                resultLabel.Text = "Successfully logged in!";
                this.Hide();
                new WorkForm(this, _clientService).ShowDialog();
                this.Show();
            }
            else
            {
                resultLabel.ForeColor = Color.Red;
                resultLabel.Text = "Login failed. Try again.";
            }
        }

    }
}
