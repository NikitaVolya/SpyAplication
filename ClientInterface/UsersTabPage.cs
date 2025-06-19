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
            usersListBox.Items.Clear();
            searchResultsListBox.Items.Clear();
            foreach (var user in users)
            {
                usersListBox.Items.Add(user);
            }
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            usersListBox.Items.Clear();

            foreach (var user in users)
            {
                usersListBox.Items.Add(user);
            }

            searchResultsListBox.Items.Clear();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            string query = textBox1.Text.Trim().ToLower();
            searchResultsListBox.Items.Clear();

            if (string.IsNullOrWhiteSpace(query))
            {
                MessageBox.Show("Enter username to search.");
                return;
            }

            var results = users.FindAll(u => u.ToLower().Contains(query));

            if (results.Count == 0)
            {
                MessageBox.Show("Nothing found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                searchResultsListBox.Items.Clear();
            }
            else
            {
                foreach (var user in results)
                {
                    searchResultsListBox.Items.Add(user);
                }
            }
        }
    }
}
