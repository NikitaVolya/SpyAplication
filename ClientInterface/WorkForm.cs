using SpyCommunicationLib;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ClientInterface
{
    public partial class WorkForm : Form
    {
        private readonly LoginForm _loginForm;
        private readonly ClientService _clientService;
        private List<string> allVictims = new List<string>();

        public WorkForm(LoginForm loginForm, ClientService clientService)
        {
            InitializeComponent();
            _loginForm = loginForm;
            _clientService = clientService;
            InitializeMenu();
            allVictims = new List<string>
            {
                "192.168.1.1",
                "192.168.1.2",
                "192.168.1.3",
                "10.0.0.1",
                "10.0.0.2"
            };
            LoadVictims();
            button3.Visible = false;

            listBox1.SelectedIndexChanged += ListBox_SelectedIndexChanged;
            listBox2.SelectedIndexChanged += ListBox_SelectedIndexChanged;
            button2.Click += button2_Click;
            button1.Click += button1_Click;
            button3.Click += button3_Click;
        }

        private void InitializeMenu()
        {
            MenuStrip menuStrip = new MenuStrip();
            ToolStripMenuItem fileMenu = new ToolStripMenuItem("File");
            ToolStripMenuItem logoutMenuItem = new ToolStripMenuItem("Logout");
            logoutMenuItem.Click += LogoutMenuItem_Click;

            fileMenu.DropDownItems.Add(logoutMenuItem);
            menuStrip.Items.Add(fileMenu);

            this.Controls.Add(menuStrip);
            this.MainMenuStrip = menuStrip;
        }

        private void LogoutMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            _loginForm.Show();
        }

        private void LoadVictims()
        {
            listBox1.Items.Clear();
            foreach (var victim in allVictims)
                listBox1.Items.Add(victim);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadVictims();
            listBox2.Items.Clear();
            button3.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchIp = textBox1.Text.Trim();
            listBox2.Items.Clear();

            if (!string.IsNullOrEmpty(searchIp))
            {
                foreach (var victim in allVictims)
                {
                    if (victim.Contains(searchIp))
                        listBox2.Items.Add(victim);
                }
            }
        }

        private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            button3.Visible = (listBox1.SelectedItem != null || listBox2.SelectedItem != null);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string toDelete = null;
            if (listBox1.SelectedItem != null)
                toDelete = listBox1.SelectedItem.ToString();
            else if (listBox2.SelectedItem != null)
                toDelete = listBox2.SelectedItem.ToString();

            if (toDelete != null)
            {
                allVictims.Remove(toDelete);
                LoadVictims();
                listBox2.Items.Remove(toDelete);
                button3.Visible = false;
            }
        }
    }
}