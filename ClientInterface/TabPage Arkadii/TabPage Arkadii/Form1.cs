using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TabPage_Arkadii
{
    public partial class Form1 : Form
    {
        private List<LogEntry> logEntries = new List<LogEntry>();

        public Form1()
        {
            InitializeComponent();
            LoadSampleData();
            UpdateListBox();
            button2.Enabled = false;
        }

        private void LoadSampleData()
        {
            logEntries.Add(new LogEntry("192.168.1.1", DateTime.Now.AddHours(-2), "Привіт"));
            logEntries.Add(new LogEntry("10.0.0.5", DateTime.Now.AddHours(-1), "help"));
            logEntries.Add(new LogEntry("172.16.0.3", DateTime.Now, "password"));
        }

        private void UpdateListBox()
        {
            listBox1.Items.Clear();
            foreach (var entry in logEntries)
            {
                listBox1.Items.Add($"{entry.IP} | {entry.Date:yyyy-MM-dd} | {entry.Time:HH:mm:ss} | {entry.Text}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateListBox();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                logEntries.RemoveAt(listBox1.SelectedIndex);
                UpdateListBox();
                button2.Enabled = false;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button2.Enabled = listBox1.SelectedIndex != -1;
        }
    }

    public class LogEntry
    {
        public string IP { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public string Text { get; set; }

        public LogEntry(string ip, DateTime dateTime, string text)
        {
            IP = ip;
            Date = dateTime.Date;
            Time = dateTime;
            Text = text;
        }
    }
}