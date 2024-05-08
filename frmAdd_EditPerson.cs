using DVLD_BusinessLayer;
using System;
using System.Data;
using System.Windows.Forms;



namespace Driving_License_Management
{
    public partial class frmAdd_EditPerson : Form
    {
        public enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode;
        clsPerson Person;
        int _PersonID;

        public delegate void DataBack_EventHandler(object sender, int PersonID);

        public event DataBack_EventHandler DataBack;
        public frmAdd_EditPerson(int PersonID)
        {
            InitializeComponent();
            this._PersonID = PersonID;

            if (_PersonID == -1)
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;
        }
        private void _FillCountriesInComboBox()
        {
            DataTable dtCountries = clsCountry.GetAllCountries();
            foreach (DataRow row in dtCountries.Rows)
            {
                ctL_AddEditPerson_Info1.ComboBoxCountries.Items.Add(row["CountryName"]);
            }
        }
        private void frmAddPerson_Load(object sender, EventArgs e)
        {

            ctL_AddEditPerson_Info1.CancelButtonClicked += MyUserControl_CloseButtonClicked;
            ctL_AddEditPerson_Info1.SaveButtonClicked += MyUserControl_SaveButtonClicked;
            _LoadData();
        }

        private void AddNewPerson()
        {
            Person.NationalNo = ctL_AddEditPerson_Info1.NationalNo;
            Person.FirstName = ctL_AddEditPerson_Info1.FirstName;
            Person.SecondName = ctL_AddEditPerson_Info1.SecondName;
            Person.ThirdName = ctL_AddEditPerson_Info1.ThirdName;
            Person.LastName = ctL_AddEditPerson_Info1.LastName;
            Person.Gendor = ctL_AddEditPerson_Info1.Gendor;
            Person.Address = ctL_AddEditPerson_Info1.Address;
            Person.Email = ctL_AddEditPerson_Info1.Email;
            Person.NationalityCountryID = ctL_AddEditPerson_Info1.NationalityCountryID;
            Person.DateOfBirth = ctL_AddEditPerson_Info1.DateOfBirth;
            Person.Phone = ctL_AddEditPerson_Info1.Phone;
            Person.ImagePath = ctL_AddEditPerson_Info1.ImagePath;
            if (Person.Save())
                MessageBox.Show("Data Saved Successfully :-)");
            else
                MessageBox.Show("Error: Data Is Not Saved Successfully");
            _Mode = enMode.Update;
            lblHeaderMode.Text = "Edit Person";
            ctL_AddEditPerson_Info1.PersonID = Person.PersonID;
        }

        private void _LoadData()
        {
            _FillCountriesInComboBox();
            ctL_AddEditPerson_Info1.ComboBoxCountries.SelectedIndex = 0;

            if (_Mode == enMode.AddNew)
            {
                lblHeaderMode.Text = "Add New Person";
                Person = new clsPerson();
                return;
            }
            else

                Person = clsPerson.Find(_PersonID);
            if (Person == null)
            {
                MessageBox.Show("This form will be closed because No Person with ID = " + _PersonID);
                this.Close();
                return;
            }
            lblHeaderMode.Text = "Edit Person";
            ctL_AddEditPerson_Info1.PersonID = _PersonID;
            ctL_AddEditPerson_Info1.FirstName = Person.FirstName;
            ctL_AddEditPerson_Info1.SecondName = Person.SecondName;
            ctL_AddEditPerson_Info1.ThirdName = Person.ThirdName;
            ctL_AddEditPerson_Info1.LastName = Person.LastName;
            ctL_AddEditPerson_Info1.NationalNo = Person.NationalNo;
            ctL_AddEditPerson_Info1.DateOfBirth = Person.DateOfBirth;
            ctL_AddEditPerson_Info1.Phone = Person.Phone;
            ctL_AddEditPerson_Info1.Email = Person.Email;
            ctL_AddEditPerson_Info1.Gendor = Person.Gendor;
            ctL_AddEditPerson_Info1.NationalityCountryID = Person.NationalityCountryID;
            ctL_AddEditPerson_Info1.Address = Person.Address;
        }


        private void MyUserControl_CloseButtonClicked(object sender, EventArgs e)
        {
            DataBack?.Invoke(this, _PersonID);
            Close();
        }

        private void MyUserControl_SaveButtonClicked(object sender, EventArgs e)
        {
            AddNewPerson();
        }

    }
}
