namespace ClientInterface
{
    public partial class UsersTabPage : TabPage
    {
        private List<string> users = new List<string>
        {
            "1 - admin",
            "2 - user1",
            "3 - user2",
            "4 - test_admin",
            "5 - guest"
        };
        public UsersTabPage()
        {
            InitializeComponent();
            this.Text = "Users";
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            foreach (var user in users)
            {
                listBox1.Items.Add(user);
            }
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            foreach (var user in users)
            {
                listBox1.Items.Add(user);
            }

            listBox2.Items.Clear();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            string query = textBox1.Text.Trim().ToLower();
            listBox2.Items.Clear();

            if (string.IsNullOrWhiteSpace(query))
            {
                MessageBox.Show("Enter username to search.");
                return;
            }

            var results = users.FindAll(u => u.ToLower().Contains(query));

            if (results.Count == 0)
            {
                listBox2.Items.Add("Noting found.");
            }
            else
            {
                foreach (var user in results)
                {
                    listBox2.Items.Add(user);
                }
            }
        }
    }
}
