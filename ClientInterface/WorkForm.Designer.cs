using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace ClientInterface
{
    partial class WorkForm
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
            listBox2 = new ListBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            textBox1 = new TextBox();
            button5 = new Button();
            label1 = new Label();
            button6 = new Button();
            label2 = new Label();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(32, 63);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(178, 324);
            listBox1.TabIndex = 0;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.Location = new Point(303, 103);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(448, 284);
            listBox2.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(657, 61);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 2;
            button1.Text = "Search";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(32, 398);
            button2.Name = "button2";
            button2.Size = new Size(178, 29);
            button2.TabIndex = 3;
            button2.Text = "Update victims";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(303, 398);
            button3.Name = "button3";
            button3.Size = new Size(448, 29);
            button3.TabIndex = 4;
            button3.Text = "Update records";
            button3.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(303, 63);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(348, 27);
            textBox1.TabIndex = 5;
            // 
            // button5
            // 
            button5.Enabled = false;
            button5.FlatStyle = FlatStyle.System;
            button5.Location = new Point(15, 46);
            button5.Name = "button5";
            button5.Size = new Size(214, 396);
            button5.TabIndex = 7;
            button5.Tag = "0";
            button5.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new System.Drawing.Font("Sylfaen", 12F);
            label1.Location = new Point(32, 34);
            label1.Name = "label1";
            label1.Size = new Size(79, 26);
            label1.TabIndex = 9;
            label1.Text = "Victims";
            // 
            // button6
            // 
            button6.Enabled = false;
            button6.FlatStyle = FlatStyle.System;
            button6.Location = new Point(284, 46);
            button6.Name = "button6";
            button6.Size = new Size(482, 396);
            button6.TabIndex = 10;
            button6.Tag = "0";
            button6.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Font = new System.Drawing.Font("Sylfaen", 12F);
            label2.Location = new Point(303, 34);
            label2.Name = "label2";
            label2.Size = new Size(180, 26);
            label2.TabIndex = 11;
            label2.Text = "Search information";
            // 
            // WorkForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 469);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(listBox2);
            Controls.Add(listBox1);
            Controls.Add(button5);
            Controls.Add(button6);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "WorkForm";
            Text = "WorkForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox1;
        private ListBox listBox2;
        private Button button1;
        private Button button2;
        private Button button3;
        private TextBox textBox1;
        private Button button5;
        private Label label1;
        private Button button6;
        private Label label2;
    }
}