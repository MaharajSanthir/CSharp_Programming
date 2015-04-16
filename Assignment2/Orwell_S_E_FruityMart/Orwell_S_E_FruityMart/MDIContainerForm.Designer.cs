namespace Orwell_S_E_FruityMart
{
    partial class MDIContainerForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trackStoreInventoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trackCustomersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trackOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1087, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.closeAllToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trackStoreInventoryToolStripMenuItem,
            this.trackCustomersToolStripMenuItem,
            this.trackOrderToolStripMenuItem});
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // trackStoreInventoryToolStripMenuItem
            // 
            this.trackStoreInventoryToolStripMenuItem.Name = "trackStoreInventoryToolStripMenuItem";
            this.trackStoreInventoryToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.trackStoreInventoryToolStripMenuItem.Text = "Track Store Inventory";
            this.trackStoreInventoryToolStripMenuItem.Click += new System.EventHandler(this.trackStoreInventoryToolStripMenuItem_Click);
            // 
            // trackCustomersToolStripMenuItem
            // 
            this.trackCustomersToolStripMenuItem.Name = "trackCustomersToolStripMenuItem";
            this.trackCustomersToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.trackCustomersToolStripMenuItem.Text = "Track Customers";
            this.trackCustomersToolStripMenuItem.Click += new System.EventHandler(this.trackCustomersToolStripMenuItem_Click);
            // 
            // closeAllToolStripMenuItem
            // 
            this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            this.closeAllToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.closeAllToolStripMenuItem.Text = "Close All";
            // 
            // trackOrderToolStripMenuItem
            // 
            this.trackOrderToolStripMenuItem.Name = "trackOrderToolStripMenuItem";
            this.trackOrderToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.trackOrderToolStripMenuItem.Text = "Track Orders";
            this.trackOrderToolStripMenuItem.Click += new System.EventHandler(this.trackOrderToolStripMenuItem_Click);
            // 
            // MDIContainerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 633);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MDIContainerForm";
            this.Text = "MDIContainerForm";
            this.Load += new System.EventHandler(this.MDIContainerForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trackStoreInventoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trackCustomersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trackOrderToolStripMenuItem;
    }
}