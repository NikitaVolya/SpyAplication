namespace ClientInterface
{
    partial class UsersTabPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            usersListBox = new ListBox();
            label1 = new Label();
            refreshBtn = new Button();
            textBox1 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            searchResultsListBox = new ListBox();
            searchBtn = new Button();
            SuspendLayout();
            // 
            // usersListBox
            // 
            usersListBox.FormattingEnabled = true;
            usersListBox.Name = "usersListBox";
            usersListBox.Size = new Size(150, 324);
            usersListBox.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Name = "label1";
            label1.Size = new Size(87, 38);
            label1.TabIndex = 1;
            label1.Text = "Users";
            // 
            // refreshBtn
            // 
            refreshBtn.Name = "refreshBtn";
            refreshBtn.Size = new Size(94, 29);
            refreshBtn.TabIndex = 2;
            refreshBtn.Text = "Refresh";
            refreshBtn.UseVisualStyleBackColor = true;
            refreshBtn.Click += refreshBtn_Click;
            // 
            // textBox1
            // 
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(292, 27);
            textBox1.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Name = "label2";
            label2.Size = new Size(178, 20);
            label2.TabIndex = 4;
            label2.Text = "Enter username to search:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Name = "label3";
            label3.Size = new Size(58, 20);
            label3.TabIndex = 5;
            label3.Text = "Results:";
            // 
            // searchResultsListBox
            // 
            searchResultsListBox.FormattingEnabled = true;
            searchResultsListBox.Name = "searchResultsListBox";
            searchResultsListBox.Size = new Size(150, 64);
            searchResultsListBox.TabIndex = 6;
            // 
            // searchBtn
            // 
            searchBtn.Name = "searchBtn";
            searchBtn.Size = new Size(94, 29);
            searchBtn.TabIndex = 7;
            searchBtn.Text = "Search";
            searchBtn.UseVisualStyleBackColor = true;
            searchBtn.Click += searchBtn_Click;
            // 
            // UsersTabPage
            // 
            Controls.Add(searchBtn);
            Controls.Add(searchResultsListBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(refreshBtn);
            Controls.Add(label1);
            Controls.Add(usersListBox);
            Size = new Size(800, 450);
            Text = "UsersTabPage";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox usersListBox;
        private Label label1;
        private Button refreshBtn;
        private TextBox textBox1;
        private Label label2;
        private Label label3;
        private ListBox searchResultsListBox;
        private Button searchBtn;
    }
}