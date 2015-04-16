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
    public partial class OrderForm : Form
    {
        // the path of the file on disk is in the same folder as this compiled program 
        string strExecFolder = (new FileInfo(Application.ExecutablePath)).Directory.FullName;
        string dataFilePath;

        List<Customer> CustomerList = new List<Customer>();

        public OrderForm()
        {
            InitializeComponent();
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            dataFilePath = Path.Combine(strExecFolder, "customer.dat");
            FillCustomerList();
            LoadCustomerListTo_ListBox();
        }

        private void LoadCustomerListTo_ListBox()
        {
            lbx_CustomerList.Items.Clear();
            foreach (Customer Cust in CustomerList)
                lbx_CustomerList.Items.Add(Cust.CustName);

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
                MessageBox.Show("Customer list file not found!");
            }
        }
    }
}
