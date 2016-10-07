namespace AGApp
{
    partial class newChBUpper
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
            this.updateThreadButton = new System.Windows.Forms.Button();
            this.stateTextBox = new System.Windows.Forms.TextBox();
            this.readButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.titleListBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.reduceButton = new System.Windows.Forms.Button();
            this.zoomButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // updateThreadButton
            // 
            this.updateThreadButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.updateThreadButton.Image = global::AGApp.Properties.Resources.update;
            this.updateThreadButton.Location = new System.Drawing.Point(709, 99);
            this.updateThreadButton.Name = "updateThreadButton";
            this.updateThreadButton.Size = new System.Drawing.Size(36, 36);
            this.updateThreadButton.TabIndex = 33;
            this.updateThreadButton.UseVisualStyleBackColor = true;
            // 
            // stateTextBox
            // 
            this.stateTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.stateTextBox.Location = new System.Drawing.Point(428, 116);
            this.stateTextBox.Name = "stateTextBox";
            this.stateTextBox.ReadOnly = true;
            this.stateTextBox.Size = new System.Drawing.Size(258, 19);
            this.stateTextBox.TabIndex = 32;
            // 
            // readButton
            // 
            this.readButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.readButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.readButton.Location = new System.Drawing.Point(428, 23);
            this.readButton.Name = "readButton";
            this.readButton.Size = new System.Drawing.Size(103, 36);
            this.readButton.TabIndex = 31;
            this.readButton.Text = "スレッド読み込み";
            this.readButton.UseVisualStyleBackColor = false;
            // 
            // updateButton
            // 
            this.updateButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.updateButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.updateButton.Location = new System.Drawing.Point(428, 70);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(103, 36);
            this.updateButton.TabIndex = 26;
            this.updateButton.Text = "スレッド一覧更新";
            this.updateButton.UseVisualStyleBackColor = false;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // titleListBox
            // 
            this.titleListBox.FormattingEnabled = true;
            this.titleListBox.ItemHeight = 12;
            this.titleListBox.Location = new System.Drawing.Point(3, 23);
            this.titleListBox.Name = "titleListBox";
            this.titleListBox.Size = new System.Drawing.Size(416, 112);
            this.titleListBox.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 12);
            this.label2.TabIndex = 29;
            this.label2.Text = "【ラジオ実況】スレッド一覧";
            // 
            // reduceButton
            // 
            this.reduceButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.reduceButton.Image = global::AGApp.Properties.Resources.Reduce;
            this.reduceButton.Location = new System.Drawing.Point(789, 99);
            this.reduceButton.Name = "reduceButton";
            this.reduceButton.Size = new System.Drawing.Size(36, 36);
            this.reduceButton.TabIndex = 28;
            this.reduceButton.UseVisualStyleBackColor = true;
            // 
            // zoomButton
            // 
            this.zoomButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.zoomButton.Image = global::AGApp.Properties.Resources.Zoom;
            this.zoomButton.Location = new System.Drawing.Point(749, 99);
            this.zoomButton.Margin = new System.Windows.Forms.Padding(0);
            this.zoomButton.Name = "zoomButton";
            this.zoomButton.Size = new System.Drawing.Size(36, 36);
            this.zoomButton.TabIndex = 27;
            this.zoomButton.UseVisualStyleBackColor = true;
            // 
            // newChBUpper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.updateThreadButton);
            this.Controls.Add(this.stateTextBox);
            this.Controls.Add(this.readButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.titleListBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.reduceButton);
            this.Controls.Add(this.zoomButton);
            this.Name = "newChBUpper";
            this.Size = new System.Drawing.Size(850, 150);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button updateThreadButton;
        private System.Windows.Forms.TextBox stateTextBox;
        private System.Windows.Forms.Button readButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.ListBox titleListBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button reduceButton;
        private System.Windows.Forms.Button zoomButton;
    }
}
