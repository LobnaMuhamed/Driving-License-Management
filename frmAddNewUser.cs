using DVLD_BusinessLayer;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Driving_License_Management
{
    public partial class frmAddNewUser : Form
    {
        clsPerson Person;
        clsUser User = new clsUser();
        public frmAddNewUser()
        {
            InitializeComponent();
        }


        private bool LoadPersonInfo()
        {
            if (Person != null)
            {

                string FullName = Person.FirstName + " " + Person.SecondName + " " + Person.ThirdName + " " + Person.LastName;
                string Country = clsCountry.Find(Person.NationalityCountryID).CountryName;

                ctlrShowPersonInfo1.PersonID = Person.PersonID;
                ctlrShowPersonInfo1.NationalNo = Person.NationalNo;
                ctlrShowPersonInfo1.FullName = FullName;
                ctlrShowPersonInfo1.Country = Country;
                ctlrShowPersonInfo1.Email = Person.Email;
                ctlrShowPersonInfo1.Phone = Person.Phone;
                ctlrShowPersonInfo1.Address = Person.Address;
                ctlrShowPersonInfo1.DateOfBirth = Person.DateOfBirth.ToString("d");
                if (Person.Gendor == 0)
                {
                    ctlrShowPersonInfo1.Gender = "Male";
                    ctlrShowPersonInfo1.pboxGender.Image = Properties.Resources.man_gentleman_husband_male_guy;
                }
                else
                {
                    ctlrShowPersonInfo1.Gender = "Female";
                    ctlrShowPersonInfo1.pboxGender.Image = Properties.Resources.woman_girl_lady_female_wife;
                }
                return true;
            }
            else
                return false;
        }


        private void frmAddNewUser_Load(object sender, EventArgs e)
        {
            ctlrShowPersonInfo1.linkEditPersonClicked += MyUserControl_LinkClicked;
            cbFilterBy.SelectedIndex = 0;


        }
        private void MyUserControl_LinkClicked(object sender, EventArgs e)
        {
            if (Person != null)
            {
                frmAdd_EditPerson frm = new frmAdd_EditPerson(Person.PersonID);
                frm.DataBack += UpdateDataForm;
                frm.ShowDialog();
            }
        }
        private void UpdateDataForm(object sender, int PersonID)
        {
            Person = clsPerson.Find(PersonID);
            LoadPersonInfo();
        }
        private void pbAddUser_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtbFilter.Text))
            {
                switch (cbFilterBy.SelectedItem.ToString())
                {
                    case "PersonID":
                        if (int.TryParse(txtbFilter.Text, out int PersonID))
                            Person = clsPerson.Find(PersonID);
                        if (Person == null)
                        {
                            MessageBox.Show("No Person With PersonID = " + txtbFilter.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        break;
                    case "NationalNo":
                        Person = clsPerson.Find(txtbFilter.Text);
                        if (Person == null)
                        {
                            MessageBox.Show("No Person With NationalNo = " + txtbFilter.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        break;
                }

                LoadPersonInfo();

            }

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            User = clsUser.Find(Person.PersonID);
            if (User != null)
            {
                MessageBox.Show("Selected Person Already Has A User, Choose Another One.", "Select another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                tabControl1.SelectedIndex = tabControl1.SelectedIndex + 1;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.SelectedIndex != 0)
            {
                txtbFilter.Enabled = true;
            }
            else
                txtbFilter.Enabled = false;

        }

        private void txtbUserName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidtxtbUserName(txtbUserName.Text, out errorMsg))
            {
                e.Cancel = true;
                txtbUserName.Select(0, txtbUserName.Text.Length);
                this.errorProvider1.SetError(txtbUserName, errorMsg);
            }
            else
                errorProvider1.SetError(txtbUserName, "");
        }


        public bool ValidtxtbUserName(string txtBox, out string errorMessage)
        {
            if (txtBox.Length == 0)
            {
                errorMessage = "required!";
                return false;
            }
            else if (clsUser.IsUserExist(txtBox))
            {
                errorMessage = "This Username already Exist, Choose another one";
                return false;
            }
            else
            {
                errorMessage = "";
                return true;
            }
        }

        private void txtbPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidtxtbPassword(txtbPassword.Text, out errorMsg))
            {
                e.Cancel = true;
                txtbPassword.Select(0, txtbPassword.Text.Length);
                this.errorProvider1.SetError(txtbPassword, errorMsg);
            }
            else
                errorProvider1.SetError(txtbPassword, "");
        }

        public bool ValidtxtbPassword(string txtBox, out string errorMessage)
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


        private void txtbConfirmPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidtxtbConfirmPassword(txtConfirmPassword.Text, out errorMsg))
            {
                e.Cancel = true;
                txtConfirmPassword.Select(0, txtConfirmPassword.Text.Length);
                this.errorProvider1.SetError(txtConfirmPassword, errorMsg);
            }
            else
                errorProvider1.SetError(txtConfirmPassword, "");
        }

        public bool ValidtxtbConfirmPassword(string txtBox, out string errorMessage)
        {
            if (txtBox.Length == 0)
            {
                errorMessage = "required!";
                return false;
            }
            else if (txtBox != txtbPassword.Text)
            {
                errorMessage = "Password Confirmation doesn't match Password";
                return false;
            }
            else
            {
                errorMessage = "";
                return true;
            }
        }

        private void FillUserInfo()
        {
            if (Person != null)
            {
                if (!string.IsNullOrEmpty(txtbUserName.Text) || !string.IsNullOrEmpty(txtbPassword.Text) || !string.IsNullOrEmpty(txtConfirmPassword.Text))
                {
                    User = new clsUser();
                    User.PersonID = Person.PersonID;
                    User.UserName = txtbUserName.Text;
                    User.Password = txtbPassword.Text;
                    User.IsActive = chbIsActive.Checked;
                    if (User.Save())
                    {
                        MessageBox.Show("User Added Successfully :-)");
                        Close();
                    }
                    else
                        MessageBox.Show("Failed To Add User!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FillUserInfo();
        }

        private void pbAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAdd_EditPerson frm = new frmAdd_EditPerson();
            frm.DataBack += UpdateDataForm;
            frm.ShowDialog();
        }
    }
}
