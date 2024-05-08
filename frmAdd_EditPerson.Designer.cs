namespace Driving_License_Management
{
    partial class frmAdd_EditPerson
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
            this.lblHeaderMode = new System.Windows.Forms.Label();
            this.ctL_AddEditPerson_Info1 = new Driving_License_Management.ctrlAddEditPerson_Info();
            this.SuspendLayout();
            // 
            // lblHeaderMode
            // 
            this.lblHeaderMode.AutoSize = true;
            this.lblHeaderMode.Font = new System.Drawing.Font("Malgun Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderMode.ForeColor = System.Drawing.Color.Red;
            this.lblHeaderMode.Location = new System.Drawing.Point(388, 22);
            this.lblHeaderMode.Name = "lblHeaderMode";
            this.lblHeaderMode.Size = new System.Drawing.Size(65, 45);
            this.lblHeaderMode.TabIndex = 17;
            this.lblHeaderMode.Text = "???";
            // 
            // ctL_AddEditPerson_Info1
            // 
            this.ctL_AddEditPerson_Info1.Address = "";
            this.ctL_AddEditPerson_Info1.DateOfBirth = new System.DateTime(2005, 5, 3, 21, 30, 0, 0);
            this.ctL_AddEditPerson_Info1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ctL_AddEditPerson_Info1.Email = "";
            this.ctL_AddEditPerson_Info1.FirstName = "";
            this.ctL_AddEditPerson_Info1.Gendor = ((byte)(0));
            this.ctL_AddEditPerson_Info1.LastName = "";
            this.ctL_AddEditPerson_Info1.Location = new System.Drawing.Point(0, 87);
            this.ctL_AddEditPerson_Info1.Name = "ctL_AddEditPerson_Info1";
            this.ctL_AddEditPerson_Info1.NationalNo = "";
            this.ctL_AddEditPerson_Info1.Phone = "";
            this.ctL_AddEditPerson_Info1.SecondName = "";
            this.ctL_AddEditPerson_Info1.Size = new System.Drawing.Size(1061, 478);
            this.ctL_AddEditPerson_Info1.TabIndex = 0;
            this.ctL_AddEditPerson_Info1.ThirdName = "";
            // 
            // frmAdd_EditPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 565);
            this.Controls.Add(this.lblHeaderMode);
            this.Controls.Add(this.ctL_AddEditPerson_Info1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAdd_EditPerson";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Edit Person";
            this.Load += new System.EventHandler(this.frmAddPerson_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlAddEditPerson_Info ctL_AddEditPerson_Info1;
        private System.Windows.Forms.Label lblHeaderMode;
    }
}