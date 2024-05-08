using DVLD_BusinessLayer;
using System;
using System.Data;
using System.Windows.Forms;

namespace Driving_License_Management
{
    public partial class frmManageUsers : Form
    {
        public frmManageUsers()
        {
            InitializeComponent();
        }

        public void _RefreshUsersList()
        {
            dgvManageUsers.DataSource = clsUser.GetAllUsers();
        }
        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            _RefreshUsersList();
            lblRecords.Text = dgvManageUsers.RowCount.ToString();
            cbFilterBy.SelectedIndex = 0;

        }


        private void txtbFilter_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtbFilter.Text))
                _RefreshUsersList();

            if (cbFilterBy.SelectedItem != null && cbFilterBy.SelectedItem.ToString() != "None")
            {
                switch (cbFilterBy.SelectedItem.ToString())
                {
                    case "UserID":
                        if (int.TryParse(txtbFilter.Text, out int ID))
                            dgvManageUsers.DataSource = clsUser.GetUserByUserID(ID);
                        break;
                    case "PersonID":
                        if (int.TryParse(txtbFilter.Text, out int PersonID))
                            dgvManageUsers.DataSource = clsUser.GetUserByPersonID(PersonID);
                        break;
                    case "UserName":
                        dgvManageUsers.DataSource = clsUser.GetUserByUserName(txtbFilter.Text);
                        break;
                    case "IsActive":
                        dgvManageUsers.DataSource = clsUser.GetUserIsActive();
                        break;


                }
                lblRecords.Text = dgvManageUsers.RowCount.ToString();
            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.SelectedItem.ToString() == "IsActive")
            {
                cmbIsActive.SelectedIndex = 0;
                cmbIsActive.Visible = true;
                txtbFilter.Visible = false;

            }
            else if (cbFilterBy.SelectedItem.ToString() != "None" && cbFilterBy.SelectedItem.ToString() != "IsActive")
            {
                txtbFilter.Visible = true;
                cmbIsActive.Visible = false;
            }
            else
            {
                txtbFilter.Visible = false;
                cmbIsActive.Visible = false;

            }
            txtbFilter.Text = null;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pbAddUser_Click(object sender, EventArgs e)
        {
            frmAddNewUser frm = new frmAddNewUser();
            frm.ShowDialog();
            _RefreshUsersList();
        }

        private void cmbISActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbIsActive.SelectedItem.ToString())
            {
                case "All":
                    dgvManageUsers.DataSource = clsUser.GetAllUsers();
                    break;
                case "Yes":
                    dgvManageUsers.DataSource = clsUser.GetUserIsActive();
                    break;
                case "No":
                    dgvManageUsers.DataSource = clsUser.GetUserIsNotActive();
                    break;
            }
            lblRecords.Text = dgvManageUsers.RowCount.ToString();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddNewUser frm = new frmAddNewUser();
            frm.ShowDialog();
            _RefreshUsersList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are You Sure You Want To Delete This User", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (result == DialogResult.OK)
            {
                if (
                clsUser.DeleteUser((int)dgvManageUsers.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Person Deleted Successfully :-)");

                }
                else
                    MessageBox.Show("Delete Process Failed :-(");
                _RefreshUsersList();
            }
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Isn't Implemented Yet", "Not Ready", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            _RefreshUsersList();
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Isn't Implemented Yet", "Not Ready", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            _RefreshUsersList();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword((int)dgvManageUsers.CurrentRow.Cells[1].Value);
            frm.ShowDialog();

        }
    }
}
