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
    public partial class InventoryForm : Form
    {
        public InventoryForm()
        {
            InitializeComponent();
        }
        private void InventoryForm_Load(object sender, EventArgs e)
        {
            List<Products> Inventory = new List<Products>();

            foreach (Products p in Inventory)
                lbl_CurrentInventory.Text += string.Format("{0} = {1}\n", p.ProdName, p.ProdQuantity);

            //Inventory CurrentInventory = new Inventory();
            //CurrentInventory.Apples = 0;
            //CurrentInventory.Bananas = 0;
            //CurrentInventory.Oranges = 0;
            //lbl_Apple_Count.Text = CurrentInventory.Apples.ToString();
            //lbl_Bananas_Count.Text = CurrentInventory.Bananas.ToString();
            //lbl_Oranges_Count.Text = CurrentInventory.Oranges.ToString();

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }


    }
}
