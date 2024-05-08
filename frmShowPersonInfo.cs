using DVLD_BusinessLayer;
using System;
using System.Windows.Forms;

namespace Driving_License_Management
{
    public partial class frmShowPersonInfo : Form
    {
        private int personID;
        clsPerson Person;
        public frmShowPersonInfo(int PersonID)
        {
            InitializeComponent();
            this.personID = PersonID;
            Person = clsPerson.Find(personID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmShowPersonInfo_Load(object sender, EventArgs e)
        {
            ctrlShowPersonInfo1.linkEditPersonClicked += MyUserControl_LinkClicked;
            _LoadPersonInfo();
        }
        private void MyUserControl_LinkClicked(object sender, EventArgs e)
        {
            frmAdd_EditPerson frm = new frmAdd_EditPerson(personID);
            frm.ShowDialog();
            _LoadPersonInfo();
        }


        private bool _LoadPersonInfo()
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
    }
}
