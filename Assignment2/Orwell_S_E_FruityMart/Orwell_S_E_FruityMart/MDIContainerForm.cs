using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Orwell_S_E_FruityMart
{
    public partial class MDIContainerForm : Form
    {

        public MDIContainerForm()
        {
            InitializeComponent();
        }

        private void MDIContainerForm_Load(object sender, EventArgs e)
        {
            OpenNewInventoryForm();
            OpenNewCustomerForm();
            OpenNewOrderForm();
        }

        private void trackStoreInventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenNewInventoryForm();
        }

        private void trackCustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenNewCustomerForm();
        }

        private void OpenNewInventoryForm()
        {
            InventoryForm myInventoryForm = new InventoryForm();
            myInventoryForm.MdiParent = this;
            myInventoryForm.Show();
        }

        private void OpenNewCustomerForm()
        {
            CustomerForm myCustomerForm = new CustomerForm();
            myCustomerForm.MdiParent = this;
            myCustomerForm.Show();
        }
        private void OpenNewOrderForm()
        {
            OrderForm myOrderForm = new OrderForm();
            myOrderForm.MdiParent = this;
            myOrderForm.Show();
        }

        private void trackOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenNewOrderForm();
        }
    }
}
