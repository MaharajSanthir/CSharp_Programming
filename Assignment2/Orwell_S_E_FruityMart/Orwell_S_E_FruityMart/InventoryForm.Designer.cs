namespace Orwell_S_E_FruityMart
{
    partial class InventoryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.gbx_AddInventory = new System.Windows.Forms.GroupBox();
            this.tbx_ProdName = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_AddProd = new System.Windows.Forms.Button();
            this.btn_AddProdClear = new System.Windows.Forms.Button();
            this.gbx_ProdDetails = new System.Windows.Forms.GroupBox();
            this.gbx_EditProduct = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tbx_Edit_ProdName = new System.Windows.Forms.TextBox();
            this.tbx_Edit_ProdPrice = new System.Windows.Forms.TextBox();
            this.tbx_Edit_ProdQuantity = new System.Windows.Forms.TextBox();
            this.btn_Edit_Cancel = new System.Windows.Forms.Button();
            this.btn_Edit_SaveChanges = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.gbx_AddInventory.SuspendLayout();
            this.gbx_ProdDetails.SuspendLayout();
            this.gbx_EditProduct.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(22, 211);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(112, 173);
            this.listBox1.TabIndex = 13;
            // 
            // gbx_AddInventory
            // 
            this.gbx_AddInventory.Controls.Add(this.btn_AddProdClear);
            this.gbx_AddInventory.Controls.Add(this.btn_AddProd);
            this.gbx_AddInventory.Controls.Add(this.label2);
            this.gbx_AddInventory.Controls.Add(this.textBox6);
            this.gbx_AddInventory.Controls.Add(this.textBox5);
            this.gbx_AddInventory.Controls.Add(this.label1);
            this.gbx_AddInventory.Controls.Add(this.textBox4);
            this.gbx_AddInventory.Controls.Add(this.tbx_ProdName);
            this.gbx_AddInventory.Location = new System.Drawing.Point(22, 24);
            this.gbx_AddInventory.Name = "gbx_AddInventory";
            this.gbx_AddInventory.Size = new System.Drawing.Size(258, 169);
            this.gbx_AddInventory.TabIndex = 14;
            this.gbx_AddInventory.TabStop = false;
            this.gbx_AddInventory.Text = "Add Product";
            // 
            // tbx_ProdName
            // 
            this.tbx_ProdName.AutoSize = true;
            this.tbx_ProdName.Location = new System.Drawing.Point(26, 31);
            this.tbx_ProdName.Name = "tbx_ProdName";
            this.tbx_ProdName.Size = new System.Drawing.Size(75, 13);
            this.tbx_ProdName.TabIndex = 0;
            this.tbx_ProdName.Text = "Product Name";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(121, 28);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Product Price";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(121, 57);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 20);
            this.textBox5.TabIndex = 3;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(121, 84);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 20);
            this.textBox6.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Product Quantity";
            // 
            // btn_AddProd
            // 
            this.btn_AddProd.Location = new System.Drawing.Point(146, 122);
            this.btn_AddProd.Name = "btn_AddProd";
            this.btn_AddProd.Size = new System.Drawing.Size(75, 23);
            this.btn_AddProd.TabIndex = 6;
            this.btn_AddProd.Text = "Add Product";
            this.btn_AddProd.UseVisualStyleBackColor = true;
            // 
            // btn_AddProdClear
            // 
            this.btn_AddProdClear.Location = new System.Drawing.Point(29, 122);
            this.btn_AddProdClear.Name = "btn_AddProdClear";
            this.btn_AddProdClear.Size = new System.Drawing.Size(75, 23);
            this.btn_AddProdClear.TabIndex = 7;
            this.btn_AddProdClear.Text = "Clear";
            this.btn_AddProdClear.UseVisualStyleBackColor = true;
            // 
            // gbx_ProdDetails
            // 
            this.gbx_ProdDetails.Controls.Add(this.button1);
            this.gbx_ProdDetails.Location = new System.Drawing.Point(168, 211);
            this.gbx_ProdDetails.Name = "gbx_ProdDetails";
            this.gbx_ProdDetails.Size = new System.Drawing.Size(263, 173);
            this.gbx_ProdDetails.TabIndex = 15;
            this.gbx_ProdDetails.TabStop = false;
            this.gbx_ProdDetails.Text = "Product Details";
            // 
            // gbx_EditProduct
            // 
            this.gbx_EditProduct.Controls.Add(this.label5);
            this.gbx_EditProduct.Controls.Add(this.label4);
            this.gbx_EditProduct.Controls.Add(this.label3);
            this.gbx_EditProduct.Controls.Add(this.btn_Edit_SaveChanges);
            this.gbx_EditProduct.Controls.Add(this.btn_Edit_Cancel);
            this.gbx_EditProduct.Controls.Add(this.tbx_Edit_ProdQuantity);
            this.gbx_EditProduct.Controls.Add(this.tbx_Edit_ProdPrice);
            this.gbx_EditProduct.Controls.Add(this.tbx_Edit_ProdName);
            this.gbx_EditProduct.Location = new System.Drawing.Point(305, 24);
            this.gbx_EditProduct.Name = "gbx_EditProduct";
            this.gbx_EditProduct.Size = new System.Drawing.Size(240, 169);
            this.gbx_EditProduct.TabIndex = 16;
            this.gbx_EditProduct.TabStop = false;
            this.gbx_EditProduct.Text = "Edit Product";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(182, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Edit";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // tbx_Edit_ProdName
            // 
            this.tbx_Edit_ProdName.Location = new System.Drawing.Point(117, 28);
            this.tbx_Edit_ProdName.Name = "tbx_Edit_ProdName";
            this.tbx_Edit_ProdName.Size = new System.Drawing.Size(100, 20);
            this.tbx_Edit_ProdName.TabIndex = 0;
            // 
            // tbx_Edit_ProdPrice
            // 
            this.tbx_Edit_ProdPrice.Location = new System.Drawing.Point(117, 54);
            this.tbx_Edit_ProdPrice.Name = "tbx_Edit_ProdPrice";
            this.tbx_Edit_ProdPrice.Size = new System.Drawing.Size(100, 20);
            this.tbx_Edit_ProdPrice.TabIndex = 1;
            // 
            // tbx_Edit_ProdQuantity
            // 
            this.tbx_Edit_ProdQuantity.Location = new System.Drawing.Point(117, 84);
            this.tbx_Edit_ProdQuantity.Name = "tbx_Edit_ProdQuantity";
            this.tbx_Edit_ProdQuantity.Size = new System.Drawing.Size(100, 20);
            this.tbx_Edit_ProdQuantity.TabIndex = 2;
            // 
            // btn_Edit_Cancel
            // 
            this.btn_Edit_Cancel.Location = new System.Drawing.Point(142, 122);
            this.btn_Edit_Cancel.Name = "btn_Edit_Cancel";
            this.btn_Edit_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Edit_Cancel.TabIndex = 3;
            this.btn_Edit_Cancel.Text = "Cancel";
            this.btn_Edit_Cancel.UseVisualStyleBackColor = true;
            // 
            // btn_Edit_SaveChanges
            // 
            this.btn_Edit_SaveChanges.Location = new System.Drawing.Point(22, 122);
            this.btn_Edit_SaveChanges.Name = "btn_Edit_SaveChanges";
            this.btn_Edit_SaveChanges.Size = new System.Drawing.Size(99, 23);
            this.btn_Edit_SaveChanges.TabIndex = 4;
            this.btn_Edit_SaveChanges.Text = "Save Changes";
            this.btn_Edit_SaveChanges.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Product Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Product Price";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Product Quantity";
            // 
            // InventoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 491);
            this.Controls.Add(this.gbx_EditProduct);
            this.Controls.Add(this.gbx_ProdDetails);
            this.Controls.Add(this.gbx_AddInventory);
            this.Controls.Add(this.listBox1);
            this.Name = "InventoryForm";
            this.Text = "Track Store Inventory";
            this.Load += new System.EventHandler(this.InventoryForm_Load);
            this.gbx_AddInventory.ResumeLayout(false);
            this.gbx_AddInventory.PerformLayout();
            this.gbx_ProdDetails.ResumeLayout(false);
            this.gbx_EditProduct.ResumeLayout(false);
            this.gbx_EditProduct.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.GroupBox gbx_AddInventory;
        private System.Windows.Forms.Button btn_AddProdClear;
        private System.Windows.Forms.Button btn_AddProd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label tbx_ProdName;
        private System.Windows.Forms.GroupBox gbx_ProdDetails;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox gbx_EditProduct;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Edit_SaveChanges;
        private System.Windows.Forms.Button btn_Edit_Cancel;
        private System.Windows.Forms.TextBox tbx_Edit_ProdQuantity;
        private System.Windows.Forms.TextBox tbx_Edit_ProdPrice;
        private System.Windows.Forms.TextBox tbx_Edit_ProdName;

    }
}

