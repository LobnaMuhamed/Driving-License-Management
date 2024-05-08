using System;
using System.Windows.Forms;
using DVLD_BusinessLayer;

namespace Driving_License_Management
{
    public partial class ctrlShowPersonInfo : UserControl
    {
        public ctrlShowPersonInfo()
        {
            InitializeComponent();
        }

        public event EventHandler linkEditPersonClicked;



        private void linkEditPerson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkEditPersonClicked?.Invoke(this, e);
        }




        public int PersonID
        {
            get
            {
                if (int.TryParse(lblPersonID.Text, out int ID))
                    return ID;
                return 0;
            }
            set { lblPersonID.Text = value.ToString(); }
        }

        public string FullName
        {
            get { return lblName.Text; }
            set
            {
                lblName.Text = value;
            }
        }

        public string NationalNo
        {
            get { return lblNationalNo.Text; }
            set
            {
                lblNationalNo.Text = value;
            }
        }
        public string Gender

        {
            get { return lblGender.Text; }
            set { lblGender.Text = value; }
        }
        public PictureBox pboxGender
        {
            get { return pbGendor; }
            set { pbGendor.Image = value.Image; }

        }

        public string Email
        {
            get { return lblEmail.Text; }
            set { lblEmail.Text = value; }
        }
        public string Address
        {
            get { return lblAddress.Text; }
            set { lblAddress.Text = value; }
        }

        public string DateOfBirth
        {
            get { return lblDateOfBirth.Text; }
            set { lblDateOfBirth.Text = value; }
        }
        public string Phone
        {
            get { return lblPhone.Text; }
            set { lblPhone.Text = value; }
        }
        public string Country
        {
            get { return lblCountry.Text; }
            set { lblCountry.Text = value; }
        }


    }

}
