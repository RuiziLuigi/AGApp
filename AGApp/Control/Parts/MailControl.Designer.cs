namespace AGApp.Control.Parts
{
    partial class MailControl
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.saveCheckBox = new System.Windows.Forms.CheckBox();
            this.msgTextBox = new System.Windows.Forms.TextBox();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.resetButton = new System.Windows.Forms.Button();
            this.sendButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toTextBox = new System.Windows.Forms.TextBox();
            this.fromComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.attachButton = new System.Windows.Forms.Button();
            this.attach1Label = new System.Windows.Forms.Label();
            this.fromSettingButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // saveCheckBox
            // 
            this.saveCheckBox.AutoSize = true;
            this.saveCheckBox.Location = new System.Drawing.Point(513, 474);
            this.saveCheckBox.Name = "saveCheckBox";
            this.saveCheckBox.Size = new System.Drawing.Size(173, 16);
            this.saveCheckBox.TabIndex = 7;
            this.saveCheckBox.Text = "送信時に送信メールを保存する";
            this.saveCheckBox.UseVisualStyleBackColor = true;
            // 
            // msgTextBox
            // 
            this.msgTextBox.Location = new System.Drawing.Point(112, 180);
            this.msgTextBox.MaxLength = 1000000;
            this.msgTextBox.Multiline = true;
            this.msgTextBox.Name = "msgTextBox";
            this.msgTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.msgTextBox.Size = new System.Drawing.Size(560, 280);
            this.msgTextBox.TabIndex = 6;
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(112, 97);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(560, 19);
            this.titleTextBox.TabIndex = 3;
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(606, 499);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 9;
            this.resetButton.Text = "リセット";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(526, 499);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(75, 23);
            this.sendButton.TabIndex = 8;
            this.sendButton.Text = "送信";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 12);
            this.label4.TabIndex = 20;
            this.label4.Text = "本文（Msg）";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 12);
            this.label3.TabIndex = 18;
            this.label3.Text = "タイトル（Title）";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 12);
            this.label2.TabIndex = 16;
            this.label2.Text = "送信元（From）";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "送信先（To）";
            // 
            // toTextBox
            // 
            this.toTextBox.Location = new System.Drawing.Point(112, 22);
            this.toTextBox.Name = "toTextBox";
            this.toTextBox.Size = new System.Drawing.Size(400, 19);
            this.toTextBox.TabIndex = 0;
            // 
            // fromComboBox
            // 
            this.fromComboBox.FormattingEnabled = true;
            this.fromComboBox.Location = new System.Drawing.Point(112, 59);
            this.fromComboBox.Name = "fromComboBox";
            this.fromComboBox.Size = new System.Drawing.Size(400, 20);
            this.fromComboBox.TabIndex = 1;
            this.fromComboBox.SelectedIndexChanged += new System.EventHandler(this.fromComboBox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 12);
            this.label5.TabIndex = 28;
            this.label5.Text = "添付（attach）";
            // 
            // attachButton
            // 
            this.attachButton.Location = new System.Drawing.Point(112, 133);
            this.attachButton.Name = "attachButton";
            this.attachButton.Size = new System.Drawing.Size(75, 23);
            this.attachButton.TabIndex = 4;
            this.attachButton.Text = "ファイル";
            this.attachButton.UseVisualStyleBackColor = true;
            this.attachButton.Click += new System.EventHandler(this.attachButton_Click);
            // 
            // attach1Label
            // 
            this.attach1Label.AutoSize = true;
            this.attach1Label.Location = new System.Drawing.Point(193, 138);
            this.attach1Label.Name = "attach1Label";
            this.attach1Label.Size = new System.Drawing.Size(48, 12);
            this.attach1Label.TabIndex = 5;
            this.attach1Label.Text = "添付なし";
            // 
            // fromSettingButton
            // 
            this.fromSettingButton.Location = new System.Drawing.Point(535, 59);
            this.fromSettingButton.Name = "fromSettingButton";
            this.fromSettingButton.Size = new System.Drawing.Size(75, 23);
            this.fromSettingButton.TabIndex = 2;
            this.fromSettingButton.Text = "メール設定";
            this.fromSettingButton.UseVisualStyleBackColor = true;
            this.fromSettingButton.Click += new System.EventHandler(this.fromSettingButton_Click);
            // 
            // MailControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.fromSettingButton);
            this.Controls.Add(this.attach1Label);
            this.Controls.Add(this.attachButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.fromComboBox);
            this.Controls.Add(this.toTextBox);
            this.Controls.Add(this.saveCheckBox);
            this.Controls.Add(this.msgTextBox);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MailControl";
            this.Size = new System.Drawing.Size(700, 550);
            this.Load += new System.EventHandler(this.MailControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox saveCheckBox;
        private System.Windows.Forms.TextBox msgTextBox;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox toTextBox;
        private System.Windows.Forms.ComboBox fromComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button attachButton;
        private System.Windows.Forms.Label attach1Label;
        private System.Windows.Forms.Button fromSettingButton;

    }
}
