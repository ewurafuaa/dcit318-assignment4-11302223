namespace PharmacyInventoryApp
{
    partial class MainForm
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtSaleQty = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnUpdateStock = new System.Windows.Forms.Button();
            this.btnRecordSale = new System.Windows.Forms.Button();
            this.btnViewAll = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvMedicines = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicines)).BeginInit();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(85, 52);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(230, 22);
            this.txtName.TabIndex = 0;
            this.txtName.Text = "Medicine Name";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(85, 285);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(203, 22);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.Text = "Search by name or category";
            // 
            // txtCategory
            // 
            this.txtCategory.Location = new System.Drawing.Point(350, 52);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(146, 22);
            this.txtCategory.TabIndex = 2;
            this.txtCategory.Text = "Category";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(531, 52);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(100, 22);
            this.txtPrice.TabIndex = 3;
            this.txtPrice.Text = "Price";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(667, 52);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(219, 22);
            this.txtQuantity.TabIndex = 4;
            this.txtQuantity.Text = "Quantity to add";
            // 
            // txtSaleQty
            // 
            this.txtSaleQty.Location = new System.Drawing.Point(921, 52);
            this.txtSaleQty.Name = "txtSaleQty";
            this.txtSaleQty.Size = new System.Drawing.Size(196, 22);
            this.txtSaleQty.TabIndex = 5;
            this.txtSaleQty.Text = "Quantity to sell";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnSearch.Location = new System.Drawing.Point(294, 281);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 30);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnUpdateStock
            // 
            this.btnUpdateStock.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnUpdateStock.Location = new System.Drawing.Point(85, 101);
            this.btnUpdateStock.Name = "btnUpdateStock";
            this.btnUpdateStock.Size = new System.Drawing.Size(154, 36);
            this.btnUpdateStock.TabIndex = 7;
            this.btnUpdateStock.Text = "Update Stock";
            this.btnUpdateStock.UseVisualStyleBackColor = false;
            // 
            // btnRecordSale
            // 
            this.btnRecordSale.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnRecordSale.Location = new System.Drawing.Point(260, 101);
            this.btnRecordSale.Name = "btnRecordSale";
            this.btnRecordSale.Size = new System.Drawing.Size(124, 36);
            this.btnRecordSale.TabIndex = 8;
            this.btnRecordSale.Text = "Record Sale";
            this.btnRecordSale.UseVisualStyleBackColor = false;
            // 
            // btnViewAll
            // 
            this.btnViewAll.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnViewAll.Location = new System.Drawing.Point(402, 101);
            this.btnViewAll.Name = "btnViewAll";
            this.btnViewAll.Size = new System.Drawing.Size(94, 36);
            this.btnViewAll.TabIndex = 9;
            this.btnViewAll.Text = "View All";
            this.btnViewAll.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnAdd.Location = new System.Drawing.Point(517, 101);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(128, 36);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Add Medicine";
            this.btnAdd.UseVisualStyleBackColor = false;
            // 
            // dgvMedicines
            // 
            this.dgvMedicines.AllowUserToAddRows = false;
            this.dgvMedicines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMedicines.Location = new System.Drawing.Point(85, 327);
            this.dgvMedicines.Name = "dgvMedicines";
            this.dgvMedicines.ReadOnly = true;
            this.dgvMedicines.RowHeadersWidth = 51;
            this.dgvMedicines.RowTemplate.Height = 24;
            this.dgvMedicines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMedicines.Size = new System.Drawing.Size(727, 150);
            this.dgvMedicines.TabIndex = 11;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1332, 518);
            this.Controls.Add(this.dgvMedicines);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnViewAll);
            this.Controls.Add(this.btnRecordSale);
            this.Controls.Add(this.btnUpdateStock);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSaleQty);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtCategory);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.txtName);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicines)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtSaleQty;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnUpdateStock;
        private System.Windows.Forms.Button btnViewAll;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvMedicines;
        private System.Windows.Forms.Button btnRecordSale;
    }
}