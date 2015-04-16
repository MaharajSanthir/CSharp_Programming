using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace Orwell_S_E_FruityMart
{
    public partial class CustomerForm : Form
    {
        // the path of the file on disk is in the same folder as this compiled program 
        string strExecFolder = (new FileInfo(Application.ExecutablePath)).Directory.FullName;
        string dataFilePath;
        string InvenotryDataFilePath;

        List<Customer> CustomerList = new List<Customer>();
        List<Products> InventoryList = new List<Products>();

        public CustomerForm()
        {
            InitializeComponent();
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            dataFilePath = Path.Combine(strExecFolder, "customer.dat");
            InvenotryDataFilePath = Path.Combine(strExecFolder, "inventory.dat");

            //FillInventoryList();

            FillCustomerList();
            LoadCustomerListTo_ListBox();

            gbx_EditCustDetails.Hide();
            gbx_Edit_Error.Hide();
            gbx_NewCust_Error.Hide();

            lbx_CustomerList.SelectedIndex = 0;
            ShowCustomerDetails();
        }

        private void FillInventoryList()
        {
            FileStream fstreamInput = null;
            try
            {
                // deserialize the student list
                fstreamInput = File.OpenRead(InvenotryDataFilePath);
                InventoryList = SerializationUtility.DeserializeObjectGraphFromStream<List<Products>>(fstreamInput);
                fstreamInput.Close();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Inventory file not found!");
            }

        }

        private void FillCustomerList()
        {
            FileStream fstreamInput = null;
            try
            {
                // deserialize the student list
                fstreamInput = File.OpenRead(dataFilePath);
                CustomerList = SerializationUtility.DeserializeObjectGraphFromStream<List<Customer>>(fstreamInput);
                fstreamInput.Close();
            }
            catch (FileNotFoundException)
            {
               CreateCustomerListFile();
            }
        }

        private void CreateCustomerListFile()
        {
            // serialize the student list 
            if (CustomerList != null)
            {
                Stream mem = SerializationUtility.SerializeObjectGraphToMemory(CustomerList);
                FileStream fsOutput = null;
                try
                {
                    fsOutput = File.Create(dataFilePath);
                    mem.CopyTo(fsOutput);
                }
                finally
                {
                    fsOutput.Close();
                }
            }
        }

        private void LoadCustomerListTo_ListBox()
        {
            lbx_CustomerList.Items.Clear();
            foreach (Customer Cust in CustomerList)
                lbx_CustomerList.Items.Add(Cust.CustName);

        }

        private void AddNewCustomerSaveToFile(Customer NewCustomer)
        {
            // serialize the student list 
            if (CustomerList != null)
            {
                CustomerList.Add(NewCustomer);
                SaveCustomerListToFile();
            }
        }

        private void SaveCustomerListToFile()
        {
            Stream mem = SerializationUtility.SerializeObjectGraphToMemory(CustomerList);
            FileStream fsOutput = null;
            try
            {
                fsOutput = File.OpenWrite(dataFilePath);
                mem.CopyTo(fsOutput);
            }
            finally
            {
                fsOutput.Close();
            }

        }

        private void ShowCustomerDetails()
        {

            lbl_CustomerDetails.Text = "";
            ClearEditCustomerFields();

            if (lbx_CustomerList.SelectedIndex != -1)
            {
                Customer SelectedCustomer = CustomerList[lbx_CustomerList.SelectedIndex];
                lbl_CustomerDetails.Text = string.Format(
                                            "Customer ID: {0}\n Name: {1}\n Address: {2}\n Phone: {3}\n Email: {4}\n"
                                            , SelectedCustomer.CustID, SelectedCustomer.CustName, SelectedCustomer.CustAddress, SelectedCustomer.CustPhone, SelectedCustomer.CustEmail);

                //

                lbl_Edit_CustomerID.Text = SelectedCustomer.CustID.ToString();
                tbx_edit_CustName.Text = SelectedCustomer.CustName.ToString();
                tbx_edit_CustAddres.Text = SelectedCustomer.CustAddress.ToString();
                tbx_edit_CustEmail.Text = SelectedCustomer.CustEmail.ToString();
                tbx_edit_CustPhone.Text = SelectedCustomer.CustPhone.ToString();
            }
            else
                lbl_CustomerDetails.Text = "Customer Not Found!";
        }

        private void btn_AddCust_Click(object sender, EventArgs e)
        {
            lbl_error.Text = "";
            if (NewCustomer_DetailsValidations())
            {
                gbx_NewCust_Error.Hide();
                Customer NewCustomer = new Customer(GenerateCustID());
                NewCustomer.CustName = tbx_CustName.Text;
                NewCustomer.CustAddress = tbx_Address.Text;
                NewCustomer.CustPhone = tbx_Phone.Text;
                NewCustomer.CustEmail = tbx_Email.Text;

                ClearNewCustomerFields();
                AddNewCustomerSaveToFile(NewCustomer);
                FillCustomerList();
                LoadCustomerListTo_ListBox();
            }
            else
                gbx_NewCust_Error.Show();
        }

        private int GenerateCustID()
        {
            int MaxCustId = 0;
            if (CustomerList != null && CustomerList.Count > 0)
            {
                
                MaxCustId = CustomerList.Max(item => item.CustID);                
            }
            return MaxCustId + 1;
        }

        private void ClearNewCustomerFields()
        {
            tbx_Address.Clear();
            tbx_CustName.Clear();
            tbx_Email.Clear();
            tbx_Phone.Clear();

        }

        private void ClearEditCustomerFields()
        {
            tbx_edit_CustName.Clear();
            tbx_edit_CustAddres.Clear();
            tbx_edit_CustEmail.Clear();
            tbx_edit_CustPhone.Clear();

        }
        private bool NewCustomer_DetailsValidations()
        {   
            bool valid = true;
            lbl_error.Text = "";
            //Customer name validator
            if (string.IsNullOrEmpty(tbx_CustName.Text))
            {
                lbl_error.Text += "\nCustomer name should not be empty.";
                valid = false;
            }

            //Address Validator
            if (string.IsNullOrEmpty(tbx_Address.Text))
            {
                lbl_error.Text += "\nAddress should not be empty.";
                valid = false;
            }

            //Phone Number validator
            Regex PhoneEx = new Regex(@"^[\d\-\(\)ext]+$");
            if (!PhoneEx.IsMatch(tbx_Phone.Text))
            {
                lbl_error.Text += "\nPhone number invalid. Must be only digits, (), -, ext";
                valid = false;
            }

            //Email Address Validator
            Regex EmailEx = new Regex(@"^[^@]+@[^@]+\.[^@]+$");
            if (!EmailEx.IsMatch(tbx_Email.Text))
            {
                lbl_error.Text += "\nEmail address invalid.";
                valid = false;
            }

            return valid;
        }

        private bool EditCustomerDetails_Validations()
        {
            bool valid = true;
            lbl_Edit_Error.Text = "";
            //Customer name validator
            if (string.IsNullOrEmpty(tbx_edit_CustName.Text))
            {

                lbl_Edit_Error.Text += "\nCustomer name should not be empty.";
                valid = false;
            }

            //Address Validator
            if (string.IsNullOrEmpty(tbx_edit_CustAddres.Text))
            {
                lbl_Edit_Error.Text += "\nAddress should not be empty.";
                valid = false;
            }

            //Phone Number validator
            Regex PhoneEx = new Regex(@"^[\d\-\(\)ext]+$");
            if (!PhoneEx.IsMatch(tbx_edit_CustPhone.Text))
            {
                lbl_Edit_Error.Text += "\nPhone number invalid. Must be only digits, (), -, ext";
                valid = false;
            }

            //Email Address Validator
            Regex EmailEx = new Regex(@"^[^@]+@[^@]+\.[^@]+$");
            if (!EmailEx.IsMatch(tbx_edit_CustEmail.Text))
            {
                lbl_Edit_Error.Text += "\nEmail address invalid.";
                valid = false;
            }

            return valid;

        }
        private void lbx_CustomerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowCustomerDetails();
            tbx_Search_CustName.Text = "";
        }

        private void btn_EditCustomer_Click(object sender, EventArgs e)
        {
            ShowCustomerDetails();
            gbx_CustomerDetails.Hide();
            gbx_EditCustDetails.Show();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            gbx_EditCustDetails.Hide();
            gbx_Edit_Error.Hide();
            ClearEditCustomerFields();
            gbx_CustomerDetails.Show();
        }

        private void btn_Save_Changes_Click(object sender, EventArgs e)
        {
            if (EditCustomerDetails_Validations())
            {
                gbx_Edit_Error.Hide();
                Customer EditCustomer = CustomerList[lbx_CustomerList.SelectedIndex];
                EditCustomer.CustName = tbx_edit_CustName.Text;
                EditCustomer.CustAddress = tbx_edit_CustAddres.Text;
                EditCustomer.CustEmail = tbx_edit_CustEmail.Text;
                EditCustomer.CustPhone = tbx_edit_CustPhone.Text;

                CustomerList[lbx_CustomerList.SelectedIndex] = EditCustomer;
                SaveCustomerListToFile();
                ClearEditCustomerFields();

                ShowCustomerDetails();

                gbx_EditCustDetails.Hide();
                gbx_CustomerDetails.Show();
            }
            else
                gbx_Edit_Error.Show();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            int returned = CustomerList.FindIndex(item => item.CustName.ToLower().Contains(tbx_Search_CustName.Text.ToLower()));
            
            if (returned != -1)
                lbx_CustomerList.SelectedIndex = returned;
            else
                MessageBox.Show("Customer not found!");
        }

        private void btn_NewCust_Clear_Click(object sender, EventArgs e)
        {
            ClearNewCustomerFields();
            gbx_NewCust_Error.Hide();
        }

    }
}
