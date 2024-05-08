namespace Driving_License_Management
{
    partial class frmLogin
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
            this.ctrlLogin1 = new Driving_License_Management.ctrlLogin();
            this.SuspendLayout();
            // 
            // ctrlLogin1
            // 
            this.ctrlLogin1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(1)))), ((int)(((byte)(31)))));
            this.ctrlLogin1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlLogin1.Location = new System.Drawing.Point(0, 0);
            this.ctrlLogin1.Name = "ctrlLogin1";
            this.ctrlLogin1.Password = "";
            this.ctrlLogin1.Size = new System.Drawing.Size(932, 467);
            this.ctrlLogin1.TabIndex = 0;
            this.ctrlLogin1.UserName = "";
            this.ctrlLogin1.Load += new System.EventHandler(this.ctrlLogin1_Load);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 467);
            this.Controls.Add(this.ctrlLogin1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLogin";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlLogin ctrlLogin1;
    }
}