using DVLD_BusinessLayer;
using System;
using System.Windows.Forms;

namespace Driving_License_Management
{
    public partial class frmChangePassword : Form
    {
        private int _personID = -1;
        clsUser User;
        clsPerson Person;
        public frmChangePassword(int personID)
        {
            InitializeComponent();
            _personID = personID;
            Person = clsPerson.Find(_personID);
            User = clsUser.FindByPersonID(_personID);
        }


        private bool LoadPersonInfo()
        {
            if (Person != null)
            {

                string FullName = Person.FirstName + " " + Person.SecondName + " " + Person.ThirdName + " " + Person.LastName;
                string Country = clsCountry.Find(Person.NationalityCountryID).CountryName;

                ctrlShowPersonInfo1.PersonID = Person.PersonID;
                ctrlShowPersonInfo1.NationalNo = Person.NationalNo;
                ctrlShowPersonInfo1.FullName = FullName;
                ctrlShowPersonInfo1.Country = Country;
                ctrlShowPersonInfo1.Email = Person.Email;
                ctrlShowPersonInfo1.Phone = Person.Phone;
                ctrlShowPersonInfo1.Address = Person.Address;
                ctrlShowPersonInfo1.DateOfBirth = Person.DateOfBirth.ToString("d");
                if (Person.Gendor == 0)
                {
                    ctrlShowPersonInfo1.Gender = "Male";
                    ctrlShowPersonInfo1.pboxGender.Image = Properties.Resources.man_gentleman_husband_male_guy;
                }
                else
                {
                    ctrlShowPersonInfo1.Gender = "Female";
                    ctrlShowPersonInfo1.pboxGender.Image = Properties.Resources.woman_girl_lady_female_wife;
                }
                return true;
            }
            else
                return false;
        }

        private bool LoadUserInfo()
        {
            if (User != null)
            {
                ctrlLogInfo1.UserID = User.UserID.ToString();
                ctrlLogInfo1.UserName = User.UserName;
                ctrlLogInfo1.IsActive = (User.IsActive ? "Yes" : "No");
                return true;
            }
            else
                return false;
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            LoadPersonInfo();
            LoadUserInfo();
            ctrlShowPersonInfo1.linkEditPersonClicked += LinkEditPersonClicked;
        }
        private void LinkEditPersonClicked(object sender, EventArgs e)
        {
            if (Person != null)
            {
                frmAdd_EditPerson frm = new frmAdd_EditPerson(_personID);
                frm.DataBack += UpdateDataForm;
                frm.ShowDialog();
            }
        }
        private void UpdateDataForm(object sender, int PersonID)
        {
            Person = clsPerson.Find(PersonID);
            LoadPersonInfo();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtbCurrentPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidtxtbPassword(txtCurrentPassword.Text, out errorMsg))
            {
                e.Cancel = true;
                txtCurrentPassword.Select(0, txtCurrentPassword.Text.Length);
                this.errorProvider1.SetError(txtCurrentPassword, errorMsg);
            }
            else
                errorProvider1.SetError(txtbNewPassword, "");
        }

        public bool ValidtxtbCurrentPassword(string txtBox, out string errorMessage)
        {
            if (txtBox.Length == 0)
            {
                errorMessage = "required!";
                return false;
            }
            else if (txtBox != User.Password)
            {
                errorMessage = "Current Password is Wrong!";
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
            if (!ValidtxtbPassword(txtbNewPassword.Text, out errorMsg))
            {
                e.Cancel = true;
                txtbNewPassword.Select(0, txtbNewPassword.Text.Length);
                this.errorProvider1.SetError(txtbNewPassword, errorMsg);
            }
            else
                errorProvider1.SetError(txtbNewPassword, "");
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
            else if (txtBox != txtbNewPassword.Text)
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            User.Password = txtbNewPassword.Text;
            if (User.Save())
            {
                MessageBox.Show("Password Change Successfully :-)");

            }
            else
                MessageBox.Show("Change Password Failed ;-(", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
