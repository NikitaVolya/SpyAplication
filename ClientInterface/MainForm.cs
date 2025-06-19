namespace ClientInterface
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            var menuStrip = new MenuStrip();
            var exitMenuItem = new ToolStripMenuItem("Exit");
            exitMenuItem.Click += exitToolStripMenuItem_Click;
            menuStrip.Items.Add(exitMenuItem);
            var form2MenuItem = new ToolStripMenuItem("Open Form2");
            form2MenuItem.Click += OpenForm2_Click;
            menuStrip.Items.Add(form2MenuItem);
            var form3MenuItem = new ToolStripMenuItem("Open Form3");
            form3MenuItem.Click += OpenForm3_Click;
            menuStrip.Items.Add(form3MenuItem);
            var mainMenuTabControl = new TabControl();
            mainMenuTabControl.Dock = DockStyle.Fill;
            mainMenuTabControl.TabPages.Add(new UsersTabPage());
            var layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 2,
                ColumnCount = 1
            };
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            layout.Controls.Add(menuStrip, 0, 0);
            layout.Controls.Add(mainMenuTabControl, 0, 1);
            this.Controls.Add(layout);
            this.MainMenuStrip = menuStrip;
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void OpenForm2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }
        private void OpenForm3_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}