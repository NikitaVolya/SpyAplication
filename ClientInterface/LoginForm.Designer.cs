namespace ClientInterface
{
    partial class LoginForm
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
            label1 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            logInBtn = new Button();
            resultLabel = new Label();
            label3 = new Label();
            label4 = new Label();
            button4 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Segoe UI", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(315, 65);
            label1.Name = "label1";
            label1.Size = new Size(123, 50);
            label1.TabIndex = 0;
            label1.Text = "Log in";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(264, 174);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(222, 27);
            textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(264, 266);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(222, 27);
            textBox2.TabIndex = 2;
            // 
            // logInBtn
            // 
            logInBtn.Location = new Point(329, 332);
            logInBtn.Name = "logInBtn";
            logInBtn.Size = new Size(94, 29);
            logInBtn.TabIndex = 3;
            logInBtn.Text = "Log in";
            logInBtn.UseVisualStyleBackColor = true;
            logInBtn.Click += logInBtn_Click;
            // 
            // resultLabel
            // 
            resultLabel.BackColor = Color.White;
            resultLabel.Location = new Point(264, 377);
            resultLabel.Name = "resultLabel";
            resultLabel.Size = new Size(222, 26);
            resultLabel.TabIndex = 4;
            resultLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(264, 133);
            label3.Name = "label3";
            label3.Size = new Size(56, 23);
            label3.TabIndex = 5;
            label3.Text = "Login:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.White;
            label4.Font = new Font("Segoe UI", 10F);
            label4.Location = new Point(264, 224);
            label4.Name = "label4";
            label4.Size = new Size(84, 23);
            label4.TabIndex = 6;
            label4.Text = "Password:";
            // 
            // button4
            // 
            button4.BackColor = Color.White;
            button4.Enabled = false;
            button4.FlatStyle = FlatStyle.System;
            button4.ForeColor = SystemColors.ControlDark;
            button4.Location = new Point(229, 39);
            button4.Name = "button4";
            button4.Size = new Size(303, 395);
            button4.TabIndex = 8;
            button4.Tag = "0";
            button4.UseVisualStyleBackColor = false;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 473);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(resultLabel);
            Controls.Add(logInBtn);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(button4);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "LoginForm";
            Text = "LoginForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button logInBtn;
        private Label resultLabel;
        private Label label3;
        private Label label4;
        public Button button4;
    }
}