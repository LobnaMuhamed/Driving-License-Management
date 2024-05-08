using DVLD_BusinessLayer;
using System;
using System.Windows.Forms;

namespace Driving_License_Management
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {
            FindRememberUser();
        }
        private void ctrlLogin1_Load(object sender, EventArgs e)
        {
            ctrlLogin1.frmLoginClosed += frmLoginClosed;
            ctrlLogin1.Login_Click += Login_Click;
        }

        private void FindRememberUser()
        {

            int UserID = clsUser.GetRememberUser();
            clsUser RememberUser = clsUser.Find(UserID);
            if (RememberUser != null)
            {
                ctrlLogin1.UserName = RememberUser.UserName;
                ctrlLogin1.Password = RememberUser.Password;
                ctrlLogin1.RememberMe.Checked = true;
            }

        }

        private void frmLoginClosed(object sender, EventArgs e)
        {
            Close();
        }


        private void Login_Click(object sender, EventArgs e)
        {
            string UserName = ctrlLogin1.UserName;
            string Password = ctrlLogin1.Password;
            if (UserName != "" && Password != "")
            {

                Global.CurrentUser = clsUser.Find(UserName, Password);
                if (Global.CurrentUser != null && Global.CurrentUser.IsActive == true)
                {
                    if (ctrlLogin1.RememberMe.Checked == true)
                    {
                        clsUser.AddUserToRememberMeLog(Global.CurrentUser.UserID);
                    }
                    else
                        clsUser.DeleteRememberUser();
                    frmMain frm = new frmMain();
                    frm.ShowDialog();
                }
                else if (Global.CurrentUser != null && Global.CurrentUser.IsActive == false)
                {
                    MessageBox.Show("Your Account is deactivated, Please Contact Your Admin :-(", "wrong credential", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Invalid UserName Or Password :-(", "wrong credential", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
