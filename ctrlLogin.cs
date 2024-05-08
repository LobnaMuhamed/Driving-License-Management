using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Driving_License_Management
{
    public partial class ctrlLogin : UserControl
    {
        public ctrlLogin()
        {
            InitializeComponent();
        }

        public event EventHandler frmLoginClosed;
        public event EventHandler Login_Click;

        private void pbClose_Click(object sender, EventArgs e)
        {
            frmLoginClosed?.Invoke(this, EventArgs.Empty);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login_Click?.Invoke(this, EventArgs.Empty);

        }
        private void txtb_Validating(object sender, CancelEventArgs e)
        {
            TextBox txtbox = (TextBox)sender;

            string errorMsg;
            if (!ValidtxtBoxField(txtbox.Text, out errorMsg))
            {
                txtbox.Select(0, txtbox.Text.Length);
                this.errorProvider1.SetError(txtbox, errorMsg);
            }
            else
            {
                errorProvider1.SetError(txtbox, "");
            }
        }
        public bool ValidtxtBoxField(string txtBox, out string errorMessage)
        {
            if (txtBox.Length == 0)
            {
                errorMessage = "required!";
                return false;
            }
            else
            {
                errorMessage = "";
                return true;
            }
        }

        public string UserName
        {
            get { return txtUserName.Text; }
            set { txtUserName.Text = value; }
        }
        public string Password
        {
            get { return txtPassword.Text; }
            set { txtPassword.Text = value; }
        }

        public CheckBox RememberMe
        {
            get { return chbRememberMe; }
        }



    }
}
