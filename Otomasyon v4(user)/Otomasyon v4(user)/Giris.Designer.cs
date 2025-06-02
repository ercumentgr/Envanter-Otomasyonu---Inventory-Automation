namespace Otomasyon_v4_user_
{
    partial class Giris
    {
        /// <summary> 
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Bileşen Tasarımcısı üretimi kod

        /// <summary> 
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Giris));
            this.btnList = new System.Windows.Forms.Button();
            this.txtList = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnOrder = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnRapor = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdateList = new System.Windows.Forms.Button();
            this.cmbProductCategory2 = new System.Windows.Forms.ComboBox();
            this.txtDailySales = new System.Windows.Forms.TextBox();
            this.txtProductId = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtProductStock = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbProductCategoryy = new System.Windows.Forms.ComboBox();
            this.btnSellRandomProduct = new System.Windows.Forms.Button();
            this.txtDailySalesPrice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.kategorııd = new System.Windows.Forms.Label();
            this.kategorıadı = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtProductPrice = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnList
            // 
            this.btnList.Location = new System.Drawing.Point(339, 249);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(45, 30);
            this.btnList.TabIndex = 58;
            this.btnList.Text = "Ara";
            this.btnList.UseVisualStyleBackColor = true;
            this.btnList.Click += new System.EventHandler(this.btnList_Click_1);
            // 
            // txtList
            // 
            this.txtList.Location = new System.Drawing.Point(405, 250);
            this.txtList.Multiline = true;
            this.txtList.Name = "txtList";
            this.txtList.Size = new System.Drawing.Size(237, 30);
            this.txtList.TabIndex = 59;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(339, 288);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(873, 317);
            this.dataGridView1.TabIndex = 57;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick_1);
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Location = new System.Drawing.Point(-1, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(325, 744);
            this.panel3.TabIndex = 56;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnOrder);
            this.panel6.Location = new System.Drawing.Point(3, 455);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(314, 107);
            this.panel6.TabIndex = 76;
            // 
            // btnOrder
            // 
            this.btnOrder.AutoSize = true;
            this.btnOrder.Image = ((System.Drawing.Image)(resources.GetObject("btnOrder.Image")));
            this.btnOrder.Location = new System.Drawing.Point(0, 0);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(314, 107);
            this.btnOrder.TabIndex = 9;
            this.btnOrder.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnRapor);
            this.panel5.Location = new System.Drawing.Point(3, 342);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(314, 107);
            this.panel5.TabIndex = 11;
            // 
            // btnRapor
            // 
            this.btnRapor.AutoSize = true;
            this.btnRapor.Image = ((System.Drawing.Image)(resources.GetObject("btnRapor.Image")));
            this.btnRapor.Location = new System.Drawing.Point(0, 0);
            this.btnRapor.Name = "btnRapor";
            this.btnRapor.Size = new System.Drawing.Size(314, 107);
            this.btnRapor.TabIndex = 6;
            this.btnRapor.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnUpdate);
            this.panel4.Location = new System.Drawing.Point(3, 229);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(314, 107);
            this.panel4.TabIndex = 10;
            // 
            // btnUpdate
            // 
            this.btnUpdate.AutoSize = true;
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.Location = new System.Drawing.Point(0, 0);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(314, 107);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click_1);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(314, 107);
            this.panel1.TabIndex = 1;
            // 
            // btnAdd
            // 
            this.btnAdd.AutoSize = true;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(0, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(314, 107);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click_1);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Location = new System.Drawing.Point(1, 116);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(314, 107);
            this.panel2.TabIndex = 2;
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSize = true;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(0, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(314, 107);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click_1);
            // 
            // btnUpdateList
            // 
            this.btnUpdateList.Location = new System.Drawing.Point(658, 249);
            this.btnUpdateList.Name = "btnUpdateList";
            this.btnUpdateList.Size = new System.Drawing.Size(164, 29);
            this.btnUpdateList.TabIndex = 60;
            this.btnUpdateList.Text = "Listeyi Güncelle";
            this.btnUpdateList.UseVisualStyleBackColor = true;
            this.btnUpdateList.Click += new System.EventHandler(this.btnUpdateList_Click_1);
            // 
            // cmbProductCategory2
            // 
            this.cmbProductCategory2.FormattingEnabled = true;
            this.cmbProductCategory2.Location = new System.Drawing.Point(840, 254);
            this.cmbProductCategory2.Name = "cmbProductCategory2";
            this.cmbProductCategory2.Size = new System.Drawing.Size(237, 24);
            this.cmbProductCategory2.TabIndex = 61;
            this.cmbProductCategory2.Text = "Ürün Grubuna Göre";
            this.cmbProductCategory2.SelectedIndexChanged += new System.EventHandler(this.cmbProductCategory2_SelectedIndexChanged_1);
            // 
            // txtDailySales
            // 
            this.txtDailySales.Location = new System.Drawing.Point(981, 32);
            this.txtDailySales.Multiline = true;
            this.txtDailySales.Name = "txtDailySales";
            this.txtDailySales.Size = new System.Drawing.Size(232, 118);
            this.txtDailySales.TabIndex = 63;
            // 
            // txtProductId
            // 
            this.txtProductId.Location = new System.Drawing.Point(460, 10);
            this.txtProductId.Name = "txtProductId";
            this.txtProductId.Size = new System.Drawing.Size(165, 22);
            this.txtProductId.TabIndex = 65;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(336, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 17);
            this.label5.TabIndex = 70;
            this.label5.Text = "Ürün Stok";
            // 
            // txtProductStock
            // 
            this.txtProductStock.Location = new System.Drawing.Point(460, 123);
            this.txtProductStock.Name = "txtProductStock";
            this.txtProductStock.Size = new System.Drawing.Size(165, 22);
            this.txtProductStock.TabIndex = 71;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(336, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 17);
            this.label4.TabIndex = 72;
            this.label4.Text = "Ürün Kategori";
            // 
            // cmbProductCategoryy
            // 
            this.cmbProductCategoryy.FormattingEnabled = true;
            this.cmbProductCategoryy.Location = new System.Drawing.Point(460, 159);
            this.cmbProductCategoryy.Name = "cmbProductCategoryy";
            this.cmbProductCategoryy.Size = new System.Drawing.Size(165, 24);
            this.cmbProductCategoryy.TabIndex = 73;
            // 
            // btnSellRandomProduct
            // 
            this.btnSellRandomProduct.Location = new System.Drawing.Point(981, 194);
            this.btnSellRandomProduct.Name = "btnSellRandomProduct";
            this.btnSellRandomProduct.Size = new System.Drawing.Size(220, 37);
            this.btnSellRandomProduct.TabIndex = 74;
            this.btnSellRandomProduct.Text = "SATIŞ";
            this.btnSellRandomProduct.UseVisualStyleBackColor = true;
            this.btnSellRandomProduct.Click += new System.EventHandler(this.btnSellRandomProduct_Click_1);
            // 
            // txtDailySalesPrice
            // 
            this.txtDailySalesPrice.Location = new System.Drawing.Point(981, 165);
            this.txtDailySalesPrice.Name = "txtDailySalesPrice";
            this.txtDailySalesPrice.Size = new System.Drawing.Size(232, 22);
            this.txtDailySalesPrice.TabIndex = 75;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(336, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 17);
            this.label6.TabIndex = 68;
            this.label6.Text = "Ürün Fiyat";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(979, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 17);
            this.label3.TabIndex = 62;
            this.label3.Text = "Günlük Satış";
            // 
            // kategorııd
            // 
            this.kategorııd.AutoSize = true;
            this.kategorııd.Location = new System.Drawing.Point(336, 13);
            this.kategorııd.Name = "kategorııd";
            this.kategorııd.Size = new System.Drawing.Size(56, 17);
            this.kategorııd.TabIndex = 64;
            this.kategorııd.Text = "Ürün ID";
            // 
            // kategorıadı
            // 
            this.kategorıadı.AutoSize = true;
            this.kategorıadı.Location = new System.Drawing.Point(336, 53);
            this.kategorıadı.Name = "kategorıadı";
            this.kategorıadı.Size = new System.Drawing.Size(63, 17);
            this.kategorıadı.TabIndex = 66;
            this.kategorıadı.Text = "Ürün Adı";
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(460, 50);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(165, 22);
            this.txtProductName.TabIndex = 67;
            // 
            // txtProductPrice
            // 
            this.txtProductPrice.Location = new System.Drawing.Point(460, 88);
            this.txtProductPrice.Name = "txtProductPrice";
            this.txtProductPrice.Size = new System.Drawing.Size(165, 22);
            this.txtProductPrice.TabIndex = 69;
            // 
            // Giris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.txtDailySalesPrice);
            this.Controls.Add(this.btnSellRandomProduct);
            this.Controls.Add(this.cmbProductCategoryy);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtProductStock);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtProductPrice);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.kategorıadı);
            this.Controls.Add(this.txtProductId);
            this.Controls.Add(this.kategorııd);
            this.Controls.Add(this.txtDailySales);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbProductCategory2);
            this.Controls.Add(this.btnUpdateList);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtList);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.panel3);
            this.Name = "Giris";
            this.Size = new System.Drawing.Size(1240, 751);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnList;
        private System.Windows.Forms.TextBox txtList;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Button btnRapor;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnUpdateList;
        private System.Windows.Forms.ComboBox cmbProductCategory2;
        private System.Windows.Forms.TextBox txtDailySales;
        private System.Windows.Forms.TextBox txtProductId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtProductStock;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbProductCategoryy;
        private System.Windows.Forms.Button btnSellRandomProduct;
        private System.Windows.Forms.TextBox txtDailySalesPrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label kategorııd;
        private System.Windows.Forms.Label kategorıadı;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TextBox txtProductPrice;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
    }
}
