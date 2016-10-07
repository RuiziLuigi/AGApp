namespace AGApp.Control.Parts
{
    partial class SettingControl
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.retryBtn = new System.Windows.Forms.Button();
            this.versionChkBtn = new System.Windows.Forms.Button();
            this.versionBtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.helpButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.retryBtn);
            this.groupBox1.Location = new System.Drawing.Point(30, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(380, 60);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "システム";
            // 
            // retryBtn
            // 
            this.retryBtn.Location = new System.Drawing.Point(20, 18);
            this.retryBtn.Name = "retryBtn";
            this.retryBtn.Size = new System.Drawing.Size(121, 23);
            this.retryBtn.TabIndex = 4;
            this.retryBtn.Text = "Ａ＆Ｇ＋再接続";
            this.retryBtn.UseVisualStyleBackColor = true;
            this.retryBtn.Click += new System.EventHandler(this.retryBtn_Click);
            // 
            // versionChkBtn
            // 
            this.versionChkBtn.Location = new System.Drawing.Point(20, 20);
            this.versionChkBtn.Name = "versionChkBtn";
            this.versionChkBtn.Size = new System.Drawing.Size(121, 23);
            this.versionChkBtn.TabIndex = 2;
            this.versionChkBtn.Text = "バージョン確認";
            this.versionChkBtn.UseVisualStyleBackColor = true;
            this.versionChkBtn.Click += new System.EventHandler(this.versionChkBtn_Click);
            // 
            // versionBtn
            // 
            this.versionBtn.Location = new System.Drawing.Point(180, 20);
            this.versionBtn.Name = "versionBtn";
            this.versionBtn.Size = new System.Drawing.Size(121, 23);
            this.versionBtn.TabIndex = 1;
            this.versionBtn.Text = "最新バージョンを取得";
            this.versionBtn.UseVisualStyleBackColor = true;
            this.versionBtn.Click += new System.EventHandler(this.versionBtn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.versionBtn);
            this.groupBox2.Controls.Add(this.versionChkBtn);
            this.groupBox2.Location = new System.Drawing.Point(30, 100);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(380, 60);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "バージョン";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(449, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "番組表更新";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.helpButton);
            this.groupBox3.Location = new System.Drawing.Point(30, 170);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(380, 60);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "その他";
            // 
            // helpButton
            // 
            this.helpButton.Location = new System.Drawing.Point(20, 18);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(121, 23);
            this.helpButton.TabIndex = 4;
            this.helpButton.Text = "ヘルプ";
            this.helpButton.UseVisualStyleBackColor = true;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // SettingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "SettingControl";
            this.Size = new System.Drawing.Size(550, 500);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button versionBtn;
        private System.Windows.Forms.Button versionChkBtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button retryBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button helpButton;
    }
}
