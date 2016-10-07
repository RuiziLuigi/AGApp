namespace AGApp.Dialog
{
    partial class TwitterLoginDialog
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
            this.twitDataGridView = new System.Windows.Forms.DataGridView();
            this.addBtn = new System.Windows.Forms.Button();
            this.delBtn = new System.Windows.Forms.Button();
            this.PINtext = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ui_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oAuthColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.twitDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Twitterアカウント一覧です。";
            // 
            // twitDataGridView
            // 
            this.twitDataGridView.AllowUserToAddRows = false;
            this.twitDataGridView.AllowUserToDeleteRows = false;
            this.twitDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.twitDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PINtext,
            this.ui_Column,
            this.s_Column,
            this.oAuthColumn});
            this.twitDataGridView.Location = new System.Drawing.Point(24, 64);
            this.twitDataGridView.MultiSelect = false;
            this.twitDataGridView.Name = "twitDataGridView";
            this.twitDataGridView.RowTemplate.Height = 21;
            this.twitDataGridView.Size = new System.Drawing.Size(471, 150);
            this.twitDataGridView.TabIndex = 1;
            this.twitDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.twitDataGridView_CellContentClick);
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(24, 220);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(75, 23);
            this.addBtn.TabIndex = 2;
            this.addBtn.Text = "追加";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // delBtn
            // 
            this.delBtn.Location = new System.Drawing.Point(105, 220);
            this.delBtn.Name = "delBtn";
            this.delBtn.Size = new System.Drawing.Size(75, 23);
            this.delBtn.TabIndex = 3;
            this.delBtn.Text = "削除";
            this.delBtn.UseVisualStyleBackColor = true;
            this.delBtn.Click += new System.EventHandler(this.delBtn_Click);
            // 
            // PINtext
            // 
            this.PINtext.HeaderText = "認証PIN";
            this.PINtext.Name = "PINtext";
            // 
            // ui_Column
            // 
            this.ui_Column.HeaderText = "UserID";
            this.ui_Column.Name = "ui_Column";
            // 
            // s_Column
            // 
            this.s_Column.HeaderText = "状態";
            this.s_Column.Name = "s_Column";
            this.s_Column.ReadOnly = true;
            // 
            // oAuthColumn
            // 
            this.oAuthColumn.HeaderText = "処理";
            this.oAuthColumn.Name = "oAuthColumn";
            this.oAuthColumn.ReadOnly = true;
            // 
            // TwitterLoginDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 279);
            this.Controls.Add(this.delBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.twitDataGridView);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TwitterLoginDialog";
            this.ShowIcon = false;
            this.Text = "Twitterアカウント管理";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TwitterLoginDialog_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.twitDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView twitDataGridView;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button delBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PINtext;
        private System.Windows.Forms.DataGridViewTextBoxColumn ui_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_Column;
        private System.Windows.Forms.DataGridViewButtonColumn oAuthColumn;
    }
}