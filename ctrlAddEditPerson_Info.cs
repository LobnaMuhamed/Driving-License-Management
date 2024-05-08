using DVLD_BusinessLayer;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Driving_License_Management
{
    public partial class ctrlAddEditPerson_Info : UserControl
    {

        public ctrlAddEditPerson_Info()
        {
            InitializeComponent();

            DateTime currentDate = DateTime.Now;
            DateTime maxDate = currentDate.AddYears(-18);

            DTPicker.MaxDate = maxDate;

        }

        public event EventHandler CancelButtonClicked;
        public event EventHandler SaveButtonClicked;

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveButtonClicked?.Invoke(this, EventArgs.Empty);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            CancelButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        private void txtb_Validating(object sender, CancelEventArgs e)
        {
            TextBox txtbox = (TextBox)sender;

            string errorMsg;
            if (!ValidtxtBoxField(txtbox.Text, out errorMsg))
            {
                e.Cancel = true;
                txtbox.Select(0, txtbox.Text.Length);
                this.errorProvider1.SetError(txtbox, errorMsg);
            }
        }
        private void NationalNo_Validating(object sender, CancelEventArgs e)
        {

            string errorMsg;
            if (!ValidtxtNationalNo(txtNationalNo.Text, out errorMsg))
            {
                e.Cancel = true;
                txtNationalNo.Select(0, txtNationalNo.Text.Length);
                this.errorProvider1.SetError(txtNationalNo, errorMsg);
            }
        }
        private void emailAddress_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidEmailAddress(txtEmail.Text, out errorMsg))
            {
                e.Cancel = true;
                txtEmail.Select(0, txtEmail.Text.Length);
                this.errorProvider1.SetError(txtEmail, errorMsg);
            }
        }

        private void txtBox_Validated(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            errorProvider1.SetError(txtbox, "");
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
        public bool ValidtxtNationalNo(string txtBox, out string errorMessage)
        {
            if (txtBox.Length == 0)
            {
                errorMessage = "required!";
                return false;
            }
            else if (clsPerson.isPersonExist(txtNationalNo.Text) && txtNationalNo.Tag == null)
            {
                errorMessage = "National Number is used for another person!";
                return false;
            }
            else
            {
                errorMessage = "";
                return true;
            }
        }
        public bool ValidEmailAddress(string emailAddress, out string errorMessage)
        {
            if (emailAddress.Length == 0)
            {
                errorMessage = "";
                return true;
            }
            {
                if (emailAddress.IndexOf(".", emailAddress.IndexOf("@")) > emailAddress.IndexOf("@"))
                {
                    errorMessage = "";
                    return true;
                }
            }

            errorMessage = "email address must be valid email address format.\n" +
               "For example 'someone@example.com' ";
            return false;
        }

        private void linkSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Title = "This is a title";
            openFileDialog1.DefaultExt = "txt";
            openFileDialog1.Filter = "Image Files(*.jpg; *.png; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.png;*.bmp";
            openFileDialog1.FilterIndex = 2;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pbImagePerson.Image = new Bitmap(openFileDialog1.FileName);
                pbImagePerson.Tag = 1;
                linkRemoveImage.Visible = true;
            }
        }


        public int PersonID
        {
            get { return int.Parse(lblPersonID.Text); }
            set { lblPersonID.Text = value.ToString(); }
        }

        public string NationalNo
        {
            get { return (string)txtNationalNo.Text; }
            set { txtNationalNo.Text = value; }
        }

        public string FirstName
        {
            get { return txtFirstName.Text; }
            set { txtFirstName.Text = value; }
        }
        public string SecondName
        {
            get { return txtSecondName.Text; }
            set { txtSecondName.Text = value; }
        }
        public string ThirdName
        {
            get { return txtThirdName.Text; }
            set { txtThirdName.Text = value; }
        }
        public string LastName
        {
            get { return txtLastName.Text; }
            set { txtLastName.Text = value; }
        }

        public string Phone
        {
            get { return txtPhone.Text; }
            set { txtPhone.Text = value; }
        }
        public string Email
        {
            get { return txtEmail.Text; }
            set { txtEmail.Text = value; }
        }

        public string Address
        {
            get { return txtAddress.Text; }
            set { txtAddress.Text = value; }
        }

        public DateTime DateOfBirth
        {
            get { return DTPicker.Value; }
            set { DTPicker.Value = value; }
        }
        public int NationalityCountryID
        {
            get
            {
                int CountryID = clsCountry.Find(comBoxCountry.Text).CountryID;
                return CountryID;
            }
            set
            {
                string CountryName = clsCountry.Find(value).CountryName;
                comBoxCountry.SelectedIndex = comBoxCountry.FindString(CountryName);
            }
        }

        public byte Gendor
        {
            get
            {
                if (rbMale.Checked) return 0;
                else return 1;
            }
            set
            {
                if (value == 0)
                    rbMale.Checked = true;
                else
                    rbFemale.Checked = true;
            }
        }

        public string ImagePath
        {
            get
            {
                return pbImagePerson.ImageLocation;
            }

        }

        public ComboBox ComboBoxCountries
        {
            get
            {
                return comBoxCountry;
            }
        }



        private void rbGendor_CheckedChanged(object sender, EventArgs e)
        {
            if (pbImagePerson.Tag == null)
            {
                if (rbMale.Checked)
                {
                    pbImagePerson.Image = Properties.Resources.person_boy__1_;
                }
                else
                {
                    pbImagePerson.Image = Properties.Resources.person_girl;

                }
            }

        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void linkRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbImagePerson.Tag = null;
            if (rbMale.Checked)
            {
                pbImagePerson.Image = Properties.Resources.person_boy__1_;
            }
            else
            {
                pbImagePerson.Image = Properties.Resources.person_girl;

            }
            linkRemoveImage.Visible = false;
        }

    }

}

