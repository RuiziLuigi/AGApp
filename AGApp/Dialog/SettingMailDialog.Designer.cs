namespace AGApp.Dialog
{
    partial class SettingMailDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mailComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.userTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.smtpTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.setButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.mailTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "メール機能を使用するにあたり、設定を行ってください。";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "使用メール：";
            // 
            // mailComboBox
            // 
            this.mailComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mailComboBox.FormattingEnabled = true;
            this.mailComboBox.Location = new System.Drawing.Point(110, 56);
            this.mailComboBox.Name = "mailComboBox";
            this.mailComboBox.Size = new System.Drawing.Size(275, 20);
            this.mailComboBox.TabIndex = 0;
            this.mailComboBox.SelectedIndexChanged += new System.EventHandler(this.mailComboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "ユーザ名：";
            // 
            // userTextBox
            // 
            this.userTextBox.Location = new System.Drawing.Point(110, 136);
            this.userTextBox.Name = "userTextBox";
            this.userTextBox.Size = new System.Drawing.Size(275, 19);
            this.userTextBox.TabIndex = 2;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(110, 176);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(275, 19);
            this.passwordTextBox.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "パスワード：";
            // 
            // smtpTextBox
            // 
            this.smtpTextBox.Location = new System.Drawing.Point(110, 216);
            this.smtpTextBox.Name = "smtpTextBox";
            this.smtpTextBox.Size = new System.Drawing.Size(275, 19);
            this.smtpTextBox.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 220);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "SMTPサーバ名：";
            // 
            // portTextBox
            // 
            this.portTextBox.Location = new System.Drawing.Point(110, 256);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(66, 19);
            this.portTextBox.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 260);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "ポート番号：";
            // 
            // setButton
            // 
            this.setButton.Location = new System.Drawing.Point(126, 293);
            this.setButton.Name = "setButton";
            this.setButton.Size = new System.Drawing.Size(75, 23);
            this.setButton.TabIndex = 6;
            this.setButton.Text = "設定";
            this.setButton.UseVisualStyleBackColor = true;
            this.setButton.Click += new System.EventHandler(this.setButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(247, 293);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 7;
            this.stopButton.Text = "中止";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // mailTextBox
            // 
            this.mailTextBox.Location = new System.Drawing.Point(110, 96);
            this.mailTextBox.Name = "mailTextBox";
            this.mailTextBox.Size = new System.Drawing.Size(275, 19);
            this.mailTextBox.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "メールアドレス：";
            // 
            // SettingMailDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 322);
            this.ControlBox = false;
            this.Controls.Add(this.mailTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.setButton);
            this.Controls.Add(this.portTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.smtpTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.userTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.mailComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SettingMailDialog";
            this.Text = "メール設定ダイアログ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox mailComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox userTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox smtpTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button setButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.TextBox mailTextBox;
        private System.Windows.Forms.Label label7;
    }
}