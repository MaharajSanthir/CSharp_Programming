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

namespace Orwell_S_E_FruityMart
{
    public partial class InventoryForm : Form
    {
        List<Products> InventoryList = new List<Products>();
        string strExecFolder = (new FileInfo(Application.ExecutablePath)).Directory.FullName;
        string InvenotryDataFilePath;

        public InventoryForm()
        {
            InitializeComponent();
        }
        private void InventoryForm_Load(object sender, EventArgs e)
        {
            InvenotryDataFilePath = Path.Combine(strExecFolder, "inventory.dat");
            FillInventoryList();
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
                CreateInventoryListFile();
            }

        }

        private void CreateInventoryListFile()
        {
            // serialize the student list 
            if (InventoryList != null)
            {
                Stream mem = SerializationUtility.SerializeObjectGraphToMemory(InventoryList);
                FileStream fsOutput = null;
                try
                {
                    fsOutput = File.Create(InvenotryDataFilePath);
                    mem.CopyTo(fsOutput);
                }
                finally
                {
                    fsOutput.Close();
                }
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }


    }
}
