namespace AGApp.Control.Parts
{
    partial class TwitterControl
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.User = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.twitColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.postButton = new System.Windows.Forms.Button();
            this.postTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TimeLineLabel = new System.Windows.Forms.Label();
            this.settingButton = new System.Windows.Forms.Button();
            this.autoLoadOKButton = new System.Windows.Forms.Button();
            this.autoLoadNGButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.viewContentsAgqrButton = new System.Windows.Forms.Button();
            this.viewContentsTLButton = new System.Windows.Forms.Button();
            this.manualLoadButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.User,
            this.twitColumn});
            this.dataGridView.Location = new System.Drawing.Point(234, 97);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowTemplate.Height = 21;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(458, 430);
            this.dataGridView.TabIndex = 30;
            // 
            // User
            // 
            this.User.HeaderText = "User";
            this.User.Name = "User";
            this.User.ReadOnly = true;
            this.User.Width = 150;
            // 
            // twitColumn
            // 
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.twitColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.twitColumn.HeaderText = "Twit";
            this.twitColumn.Name = "twitColumn";
            this.twitColumn.ReadOnly = true;
            this.twitColumn.Width = 300;
            // 
            // postButton
            // 
            this.postButton.Location = new System.Drawing.Point(153, 294);
            this.postButton.Name = "postButton";
            this.postButton.Size = new System.Drawing.Size(75, 23);
            this.postButton.TabIndex = 31;
            this.postButton.Text = "POST";
            this.postButton.UseVisualStyleBackColor = true;
            this.postButton.Click += new System.EventHandler(this.postButton_Click);
            // 
            // postTextBox
            // 
            this.postTextBox.Location = new System.Drawing.Point(3, 97);
            this.postTextBox.Multiline = true;
            this.postTextBox.Name = "postTextBox";
            this.postTextBox.Size = new System.Drawing.Size(225, 191);
            this.postTextBox.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 33;
            this.label1.Text = "ツイート";
            // 
            // TimeLineLabel
            // 
            this.TimeLineLabel.AutoSize = true;
            this.TimeLineLabel.Location = new System.Drawing.Point(232, 77);
            this.TimeLineLabel.Name = "TimeLineLabel";
            this.TimeLineLabel.Size = new System.Drawing.Size(57, 12);
            this.TimeLineLabel.TabIndex = 34;
            this.TimeLineLabel.Text = "#agqr実況";
            // 
            // settingButton
            // 
            this.settingButton.Location = new System.Drawing.Point(20, 30);
            this.settingButton.Name = "settingButton";
            this.settingButton.Size = new System.Drawing.Size(119, 23);
            this.settingButton.TabIndex = 37;
            this.settingButton.Text = "Twitterアカウント設定";
            this.settingButton.UseVisualStyleBackColor = true;
            this.settingButton.Click += new System.EventHandler(this.settingButton_Click);
            // 
            // autoLoadOKButton
            // 
            this.autoLoadOKButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.autoLoadOKButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.autoLoadOKButton.Location = new System.Drawing.Point(10, 20);
            this.autoLoadOKButton.Name = "autoLoadOKButton";
            this.autoLoadOKButton.Size = new System.Drawing.Size(60, 23);
            this.autoLoadOKButton.TabIndex = 38;
            this.autoLoadOKButton.Text = "あり";
            this.autoLoadOKButton.UseVisualStyleBackColor = false;
            this.autoLoadOKButton.Click += new System.EventHandler(this.autoLoadButton_Click);
            // 
            // autoLoadNGButton
            // 
            this.autoLoadNGButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.autoLoadNGButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.autoLoadNGButton.Location = new System.Drawing.Point(80, 20);
            this.autoLoadNGButton.Name = "autoLoadNGButton";
            this.autoLoadNGButton.Size = new System.Drawing.Size(60, 23);
            this.autoLoadNGButton.TabIndex = 39;
            this.autoLoadNGButton.Text = "なし";
            this.autoLoadNGButton.UseVisualStyleBackColor = false;
            this.autoLoadNGButton.Click += new System.EventHandler(this.autoLoadButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.autoLoadNGButton);
            this.groupBox1.Controls.Add(this.autoLoadOKButton);
            this.groupBox1.Location = new System.Drawing.Point(540, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(150, 53);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "自動ロード（30秒おき）";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.viewContentsAgqrButton);
            this.groupBox2.Controls.Add(this.viewContentsTLButton);
            this.groupBox2.Location = new System.Drawing.Point(340, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(190, 53);
            this.groupBox2.TabIndex = 41;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "表示内容";
            // 
            // viewContentsAgqrButton
            // 
            this.viewContentsAgqrButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.viewContentsAgqrButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewContentsAgqrButton.Location = new System.Drawing.Point(100, 20);
            this.viewContentsAgqrButton.Name = "viewContentsAgqrButton";
            this.viewContentsAgqrButton.Size = new System.Drawing.Size(80, 23);
            this.viewContentsAgqrButton.TabIndex = 39;
            this.viewContentsAgqrButton.Text = "#agqr";
            this.viewContentsAgqrButton.UseVisualStyleBackColor = false;
            this.viewContentsAgqrButton.Click += new System.EventHandler(this.viewContentsButton_Click);
            // 
            // viewContentsTLButton
            // 
            this.viewContentsTLButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.viewContentsTLButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewContentsTLButton.Location = new System.Drawing.Point(10, 20);
            this.viewContentsTLButton.Name = "viewContentsTLButton";
            this.viewContentsTLButton.Size = new System.Drawing.Size(80, 23);
            this.viewContentsTLButton.TabIndex = 38;
            this.viewContentsTLButton.Text = "タイムライン";
            this.viewContentsTLButton.UseVisualStyleBackColor = false;
            this.viewContentsTLButton.Click += new System.EventHandler(this.viewContentsButton_Click);
            // 
            // manualLoadButton
            // 
            this.manualLoadButton.Location = new System.Drawing.Point(160, 30);
            this.manualLoadButton.Name = "manualLoadButton";
            this.manualLoadButton.Size = new System.Drawing.Size(119, 23);
            this.manualLoadButton.TabIndex = 42;
            this.manualLoadButton.Text = "手動ロード";
            this.manualLoadButton.UseVisualStyleBackColor = true;
            this.manualLoadButton.Click += new System.EventHandler(this.manualLoadButton_Click);
            // 
            // TwitterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.manualLoadButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.settingButton);
            this.Controls.Add(this.TimeLineLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.postTextBox);
            this.Controls.Add(this.postButton);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "TwitterControl";
            this.Size = new System.Drawing.Size(700, 550);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button postButton;
        private System.Windows.Forms.TextBox postTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label TimeLineLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn User;
        private System.Windows.Forms.DataGridViewTextBoxColumn twitColumn;
        private System.Windows.Forms.Button settingButton;
        private System.Windows.Forms.Button autoLoadOKButton;
        private System.Windows.Forms.Button autoLoadNGButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button viewContentsAgqrButton;
        private System.Windows.Forms.Button viewContentsTLButton;
        private System.Windows.Forms.Button manualLoadButton;
    }
}
