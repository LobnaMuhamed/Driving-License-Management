using System;
using DVLD_BusinessLayer;
using System.Windows.Forms;

namespace Driving_License_Management
{
    public partial class frmManagePeople : Form
    {
        public frmManagePeople()
        {
            InitializeComponent();
        }

        private void _RefreshPeopleShowList()
        {
            dgvManagePeople.DataSource = clsPerson.GetAllPeople();

        }
        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            _RefreshPeopleShowList();
            cbFilterBy.SelectedIndex = 0;
            lblRecords.Text = clsPerson.GetAllPeople().Rows.Count.ToString();
        }

        private void pbAddPerson_Click(object sender, EventArgs e)
        {
            frmAdd_EditPerson frm = new frmAdd_EditPerson(-1);
            frm.ShowDialog();
            _RefreshPeopleShowList();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void ShowDetailsMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPersonInfo frmShowPerson = new frmShowPersonInfo((int)dgvManagePeople.CurrentRow.Cells[0].Value);
            frmShowPerson.ShowDialog();
            _RefreshPeopleShowList();

        }

        private void AddNewPersonMenuItem_Click(object sender, EventArgs e)
        {
            frmAdd_EditPerson frmAddEditPerson = new frmAdd_EditPerson(-1);

            frmAddEditPerson.ShowDialog();
            _RefreshPeopleShowList();
        }

        private void EditPersonMenuItem_Click(object sender, EventArgs e)
        {
            frmAdd_EditPerson frmAddEditPerson = new frmAdd_EditPerson((int)dgvManagePeople.CurrentRow.Cells[0].Value);
            frmAddEditPerson.ShowDialog();
            _RefreshPeopleShowList();

        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Isn't Implemented Yet", "Not Ready", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            _RefreshPeopleShowList();

        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Isn't Implemented Yet", "Not Ready", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            _RefreshPeopleShowList();



        }
        private void DeletePersonMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are You Sure You Want To Delete This Person", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (result == DialogResult.OK)
            {
                if (
                clsPerson.DeletePerson((int)dgvManagePeople.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Person Deleted Successfully :-)");

                }
                else
                    MessageBox.Show("Delete Process Failed :-(");
                _RefreshPeopleShowList();
            }
        }
        private void txtbFilter_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtbFilter.Text))
                _RefreshPeopleShowList();

            if (cbFilterBy.SelectedItem != null && cbFilterBy.SelectedItem.ToString() != "None")
            {
                switch (cbFilterBy.SelectedItem.ToString())
                {
                    case "PersonID":
                        if (int.TryParse(txtbFilter.Text, out int ID))
                            dgvManagePeople.DataSource = clsPerson.GetPersonByPersonID(ID);
                        break;
                    case "National No":
                        dgvManagePeople.DataSource = clsPerson.GetPersonByNationalNo(txtbFilter.Text);
                        break;
                    case "First Name":
                        dgvManagePeople.DataSource = clsPerson.GetPersonByFirstName(txtbFilter.Text);
                        break;
                    case "Second Name":
                        dgvManagePeople.DataSource = clsPerson.GetPersonBySecondName(txtbFilter.Text);
                        break;
                    case "Third Name":
                        dgvManagePeople.DataSource = clsPerson.GetPersonByThirdName(txtbFilter.Text);
                        break;
                    case "Last Name":
                        dgvManagePeople.DataSource = clsPerson.GetPersonByLastName(txtbFilter.Text);
                        break;
                    case "Email":
                        dgvManagePeople.DataSource = clsPerson.GetPersonByEmail(txtbFilter.Text);
                        break;
                    case "Phone":
                        dgvManagePeople.DataSource = clsPerson.GetPersonByPhone(txtbFilter.Text);
                        break;
                    case "Country":
                        dgvManagePeople.DataSource = clsPerson.GetPersonByCountryName(txtbFilter.Text);
                        break;

                }
                lblRecords.Text = dgvManagePeople.RowCount.ToString();
            }




        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.SelectedItem != null && cbFilterBy.SelectedItem.ToString() != "None")
                txtbFilter.Visible = true;
            else txtbFilter.Visible = false;
            txtbFilter.Text = null;
        }


    }
}
