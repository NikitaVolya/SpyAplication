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
            listBox1 = new ListBox();
            label1 = new Label();
            refreshBtn = new Button();
            textBox1 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            listBox2 = new ListBox();
            searchBtn = new Button();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(12, 60);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(150, 324);
            listBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(12, 19);
            label1.Name = "label1";
            label1.Size = new Size(87, 38);
            label1.TabIndex = 1;
            label1.Text = "Users";
            // 
            // refreshBtn
            // 
            refreshBtn.Location = new Point(12, 390);
            refreshBtn.Name = "refreshBtn";
            refreshBtn.Size = new Size(94, 29);
            refreshBtn.TabIndex = 2;
            refreshBtn.Text = "Refresh";
            refreshBtn.UseVisualStyleBackColor = true;
            refreshBtn.Click += refreshBtn_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(291, 83);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(292, 27);
            textBox1.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(291, 60);
            label2.Name = "label2";
            label2.Size = new Size(178, 20);
            label2.TabIndex = 4;
            label2.Text = "Enter username to search:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(291, 144);
            label3.Name = "label3";
            label3.Size = new Size(58, 20);
            label3.TabIndex = 5;
            label3.Text = "Results:";
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.Location = new Point(291, 167);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(150, 64);
            listBox2.TabIndex = 6;
            // 
            // searchBtn
            // 
            searchBtn.Location = new Point(608, 81);
            searchBtn.Name = "searchBtn";
            searchBtn.Size = new Size(94, 29);
            searchBtn.TabIndex = 7;
            searchBtn.Text = "Search";
            searchBtn.UseVisualStyleBackColor = true;
            searchBtn.Click += searchBtn_Click;
            // 
            // UsersTabPage
            // 
            ClientSize = new Size(800, 450);
            Controls.Add(searchBtn);
            Controls.Add(listBox2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(refreshBtn);
            Controls.Add(label1);
            Controls.Add(listBox1);
            Name = "UsersTabPage";
            Text = "UsersTabPage";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox1;
        private Label label1;
        private Button refreshBtn;
        private TextBox textBox1;
        private Label label2;
        private Label label3;
        private ListBox listBox2;
        private Button searchBtn;
    }
}