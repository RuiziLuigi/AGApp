namespace AGApp.Dialog
{
    partial class BrowserDialog
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
            this.chBrowser1 = new Control.Browse.chBrowser();
            this.SuspendLayout();
            // 
            // chBrowser1
            // 
            this.chBrowser1.Location = new System.Drawing.Point(0, 0);
            this.chBrowser1.Name = "chBrowser1";
            this.chBrowser1.Size = new System.Drawing.Size(850, 550);
            this.chBrowser1.TabIndex = 0;
            // 
            // BrowserDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 552);
            this.Controls.Add(this.chBrowser1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "BrowserDialog";
            this.Text = "ブラウザダイアログ";
            this.ResumeLayout(false);

        }

        #endregion

        private Control.Browse.chBrowser chBrowser1;
    }
}