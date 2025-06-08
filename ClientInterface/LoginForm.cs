using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            string username = textBox1.Text;
            string password = textBox2.Text;

            if (username == "admin" && password == "1234")
            {
                label2.ForeColor = Color.Green;
                label2.Text = "Successfully logged in!";
                new MainForm().Show();
                this.Hide();
            }
            else if (username == "" || password == "")
            {
                label2.ForeColor = Color.OrangeRed;
                label2.Text = "Enter username and password!";
            }
            else
            {
                label2.ForeColor = Color.Red;
                label2.Text = "Incorrect username or password!";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
