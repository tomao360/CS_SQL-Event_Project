namespace EventGuests
{
    partial class frmGuests
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
            this.GuestNameTextBox = new System.Windows.Forms.TextBox();
            this.GuestListBox = new System.Windows.Forms.ListBox();
            this.okBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // GuestNameTextBox
            // 
            this.GuestNameTextBox.Font = new System.Drawing.Font("Segoe Print", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GuestNameTextBox.Location = new System.Drawing.Point(197, 114);
            this.GuestNameTextBox.Name = "GuestNameTextBox";
            this.GuestNameTextBox.Size = new System.Drawing.Size(143, 30);
            this.GuestNameTextBox.TabIndex = 0;
            this.GuestNameTextBox.TextChanged += new System.EventHandler(this.GuestNameTextBox_TextChanged);
            // 
            // GuestListBox
            // 
            this.GuestListBox.Font = new System.Drawing.Font("Segoe Print", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GuestListBox.FormattingEnabled = true;
            this.GuestListBox.ItemHeight = 23;
            this.GuestListBox.Location = new System.Drawing.Point(197, 159);
            this.GuestListBox.Name = "GuestListBox";
            this.GuestListBox.Size = new System.Drawing.Size(143, 119);
            this.GuestListBox.TabIndex = 1;
            this.GuestListBox.SelectedIndexChanged += new System.EventHandler(this.GuestListBox_SelectedIndexChanged);
            // 
            // okBtn
            // 
            this.okBtn.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.okBtn.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okBtn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.okBtn.Location = new System.Drawing.Point(228, 300);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(83, 37);
            this.okBtn.TabIndex = 2;
            this.okBtn.Text = "אישור";
            this.okBtn.UseVisualStyleBackColor = false;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(214, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "הכנס שם אורח";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Print", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(184, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 26);
            this.label2.TabIndex = 4;
            this.label2.Text = "ברוכים הבאים לאירוע";
            // 
            // frmGuests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(550, 418);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.GuestListBox);
            this.Controls.Add(this.GuestNameTextBox);
            this.Name = "frmGuests";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox GuestNameTextBox;
        private System.Windows.Forms.ListBox GuestListBox;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

