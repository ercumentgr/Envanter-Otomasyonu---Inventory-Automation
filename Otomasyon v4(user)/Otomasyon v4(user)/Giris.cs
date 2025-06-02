using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Otomasyon_v4_user_
{
    public partial class Giris : UserControl 
    {
        private string connectionString = "Server=DESKTOP-D5RU4QE;Database=StokTakipv2;Integrated Security=True;";
        decimal toplamsatıs;
        public event EventHandler btnRaporClicked;
        public event EventHandler btnSiparisClicked;
        public Giris()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(46, 44, 47); // Arka plan rengi: Renk 4
            this.Font = new Font("Segoe UI", 10, FontStyle.Regular); // Modern font
            ApplyModernStyles(); // Stil uygulama metodu
            ApplyModernDataGridViewStyle(dataGridView1); //DGW modern görünüm
            btnRapor.Click += btnRapor_Click;
            btnOrder.Click += btnOrder_Click;
            
        }
        DbProject2Entities db = new DbProject2Entities();
        void ProductList()
        {
            dataGridView1.DataSource = db.TblProduct.Select(x => new { x.ProductName, x.ProductPrice, x.ProductId, x.ProductStock }).ToList();
        }
        private void InsertSaleData(int productId, decimal saleAmount)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Satış verisini TblSales tablosuna eklemek için SQL sorgusu
                string query = "INSERT INTO TblSales (ProductId, SaleAmount) VALUES (@ProductId, @SaleAmount)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Parametreleri ekle
                    command.Parameters.AddWithValue("@ProductId", productId);
                    command.Parameters.AddWithValue("@SaleAmount", saleAmount);

                    // Veriyi ekle
                    command.ExecuteNonQuery();
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            TblProduct tblProduct = new TblProduct();
            tblProduct.ProductPrice = decimal.Parse(txtProductPrice.Text);
            tblProduct.ProductStock = int.Parse(txtProductPrice.Text);
            tblProduct.ProductName = txtProductName.Text;
            tblProduct.CategoryId = int.Parse(cmbProductCategoryy.SelectedValue.ToString());
            db.TblProduct.Add(tblProduct);
            db.SaveChanges();
            ProductList();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtList.Text)) // TextBox boşsa
            {
                ProductList();
            }
            else
            {
                // Filtrelenmiş veriyi getir
                var values = db.TblProduct.Where(x => x.ProductName == txtList.Text).ToList();
                dataGridView1.DataSource = values;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var value = db.TblProduct.Find(int.Parse(txtProductId.Text));
            db.TblProduct.Remove(value);
            db.SaveChanges();
            ProductList();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var value = db.TblProduct.Find(int.Parse(txtProductId.Text));
            value.ProductPrice = decimal.Parse(txtProductPrice.Text);
            value.ProductStock = int.Parse(txtProductStock.Text);
            value.ProductName = txtProductName.Text;
            value.CategoryId = int.Parse(cmbProductCategoryy.SelectedValue.ToString());
            db.SaveChanges();
            ProductList();
        }

        private void btnUpdateList_Click(object sender, EventArgs e)
        {
            ProductList();
        }

        private void cmbProductCategory2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedCategoryId = Convert.ToInt32(cmbProductCategory2.SelectedValue);

            if (selectedCategoryId == 0) // Tüm Kategoriler
            {
                dataGridView1.DataSource = db.TblProduct.ToList();
            }
            else
            {
                // Seçili kategoriye göre DataGridView'i filtrele
                var filteredData = db.TblProduct.Where(x => x.CategoryId == selectedCategoryId).Select(x => new { x.ProductName, x.ProductPrice, x.ProductId, x.ProductStock }).ToList();
                dataGridView1.DataSource = filteredData;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            // TextBox'lara hücre değerlerini ata
            txtProductName.Text = row.Cells["ProductName"].Value.ToString();
            txtProductPrice.Text = row.Cells["ProductPrice"].Value.ToString();
            txtProductStock.Text = row.Cells["ProductStock"].Value.ToString();
            txtProductId.Text = row.Cells["ProductId"].Value.ToString();

        }

        private void btnSellRandomProduct_Click(object sender, EventArgs e)
        {
            // 1. Ürünleri Veritabanından Çek
            DataTable products = GetProductsFromDatabase();

            if (products.Rows.Count > 0)
            {
                // 2. Rastgele Ürün Seçimi
                Random random = new Random();
                int randomIndex = random.Next(products.Rows.Count);
                DataRow selectedProduct = products.Rows[randomIndex];
                // Ürün bilgilerini al
                int productId = Convert.ToInt32(selectedProduct["ProductId"]);
                string productName = selectedProduct["ProductName"].ToString();
                decimal productPrice = Convert.ToDecimal(selectedProduct["ProductPrice"]);
                int productStock = Convert.ToInt32(selectedProduct["ProductStock"]);

                // Stok kontrolü
                if (productStock > 0)
                {
                    // 3. Stok Azaltma
                    UpdateProductStock(productId, productStock - 1);
                    // 4. DailySales Textbox'a Yazdır
                    txtDailySales.Text += $"Satılan Ürün: {productName}, Fiyat: {productPrice:C}, Kalan Stok: {productStock - 1}\r\n";
                    toplamsatıs += productPrice;
                    //5.FİYATI YAZDIR.
                    txtDailySalesPrice.Text = toplamsatıs.ToString();
                    decimal saleAmount = productPrice;
                    InsertSaleData(productId, saleAmount);
                }
                else
                {
                    MessageBox.Show("Stokta bu ürün yok!");
                }
            }
            else
            {
                MessageBox.Show("Veritabanında ürün bulunamadı!");
            }
        }
        private DataTable GetProductsFromDatabase()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT ProductId, ProductName, ProductPrice, ProductStock FROM TblProduct";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            return dataTable;
        }
        private void UpdateProductStock(int productId, int newStock)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE TblProduct SET ProductStock = @NewStock WHERE ProductId = @ProductId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NewStock", newStock);
                    command.Parameters.AddWithValue("@ProductId", productId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        private void btnRapor_Click(object sender, EventArgs e)
        {
            //Rapor frm = new Rapor();
            //frm.Show();
            btnRaporClicked?.Invoke(this, EventArgs.Empty); // Event'i tetikleyin
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            //btnOrder frm = new btnOrder();
            //frm.Show();
            btnSiparisClicked?.Invoke(this, EventArgs.Empty);//Event'i tetikle
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            var values = db.TblCategory
                   .Select(x => new { x.CategoryId, x.CategoryName })
                   .ToList();

            cmbProductCategoryy.DisplayMember = "CategoryName";
            cmbProductCategoryy.ValueMember = "CategoryId";
            cmbProductCategoryy.DataSource = values;

            //ComboBox'ın ilk değeri boş olmasını sağlamak
            cmbProductCategoryy.SelectedIndex = -1;
            var values2 = db.TblCategory
                   .Select(x => new { x.CategoryId, x.CategoryName })
                   .ToList();

            cmbProductCategory2.DisplayMember = "CategoryName";
            cmbProductCategory2.ValueMember = "CategoryId";
            cmbProductCategory2.DataSource = values2;

            // ComboBox'ın ilk değeri boş olmasını sağlamak
            cmbProductCategory2.SelectedIndex = -1;
            ProductList();
            // Başlıkları değiştirme
            dataGridView1.Columns[0].HeaderText = "Ürün Adı";
            dataGridView1.Columns[1].HeaderText = "Ürün Fiyatı";
            dataGridView1.Columns[2].HeaderText = "Ürün ID";
            dataGridView1.Columns[3].HeaderText = "Ürün Stok";
        }
        //ARAYÜZ 
        private void ApplyModernStyles()
        {
            // DataGridView stilleri
            dataGridView1.BackgroundColor = Color.FromArgb(54, 49, 50); // Arka plan: Renk 8
            dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(46, 44, 47); // Satır arka plan: Renk 4
            dataGridView1.DefaultCellStyle.ForeColor = Color.FromArgb(112, 233, 253); // Yazı rengi: Renk 1
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(248, 230, 73); // Başlık: Renk 2
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.GridColor = Color.FromArgb(144, 59, 91); // Çizgiler: Renk 5
            dataGridView1.RowTemplate.Height = 30;

            // Buton stilleri
            foreach (var button in this.Controls.OfType<Button>())
            {
                button.BackColor = Color.FromArgb(245, 80, 107); // Buton rengi: Renk 3
                button.ForeColor = Color.White;
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
                button.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                button.Cursor = Cursors.Hand;
                button.Size = new Size(button.Width + 10, button.Height + 5); // Buton boyutlarını artırarak dikkat çekici hale getir
                btnAdd.BackColor = Color.FromArgb(46, 44, 47);
                btnDelete.BackColor = Color.FromArgb(46, 44, 47);
                btnUpdate.BackColor = Color.FromArgb(46, 44, 47);
                btnRapor.BackColor = Color.FromArgb(46, 44, 47);
                btnRapor.BackColor = Color.FromArgb(46, 44, 47);
                btnOrder.BackColor = Color.FromArgb(46, 44, 47);

            }

            // TextBox stilleri
            foreach (var textBox in this.Controls.OfType<TextBox>())
            {
                textBox.BackColor = Color.FromArgb(54, 49, 50); // TextBox arka plan: Renk 8
                textBox.ForeColor = Color.White;
                textBox.BorderStyle = BorderStyle.FixedSingle;
                textBox.Font = new Font("Segoe UI", 10);
            }

            // ComboBox stilleri
            foreach (var comboBox in this.Controls.OfType<ComboBox>())
            {
                comboBox.BackColor = Color.FromArgb(54, 49, 50); // Arka plan: Renk 8
                comboBox.ForeColor = Color.White;
                comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox.FlatStyle = FlatStyle.Flat;
                comboBox.Font = new Font("Segoe UI", 10);
            }

            // Label stilleri
            foreach (var label in this.Controls.OfType<Label>())
            {
                label.ForeColor = Color.FromArgb(252, 210, 99); // Sarı tonları: Renk 7
                label.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            }

            // Panel veya grup kutuları varsa stillendirin
            foreach (var panel in this.Controls.OfType<Panel>())
            {
                panel.BackColor = Color.FromArgb(54, 49, 50); // Panel arka planı
                panel.BorderStyle = BorderStyle.FixedSingle;
            }

            foreach (var groupBox in this.Controls.OfType<GroupBox>())
            {
                groupBox.ForeColor = Color.FromArgb(252, 210, 99); // Grup kutusu başlığı
                groupBox.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            }
        }
        private void ApplyModernDataGridViewStyle(DataGridView gridView)
        {
            // Arka plan ve genel renkler
            gridView.BackgroundColor = Color.FromArgb(54, 49, 50); // Renk 8: Koyu arka plan
            gridView.GridColor = Color.FromArgb(144, 59, 91); // Renk 5: Grid çizgi rengi

            // Hücre stilleri
            gridView.DefaultCellStyle.BackColor = Color.FromArgb(46, 44, 47); // Renk 4: Hücre arka plan rengi
            gridView.DefaultCellStyle.ForeColor = Color.FromArgb(112, 233, 253); // Renk 1: Yazı rengi
            gridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(245, 80, 107); // Renk 3: Seçili hücre arka planı
            gridView.DefaultCellStyle.SelectionForeColor = Color.White; // Seçili hücre yazı rengi
            gridView.DefaultCellStyle.Font = new Font("Segoe UI", 10);

            // Başlık stilleri
            gridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(248, 230, 73); // Renk 2: Başlık arka planı
            gridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black; // Başlık yazı rengi
            gridView.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            gridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            gridView.ColumnHeadersHeight = 40;
            gridView.EnableHeadersVisualStyles = false;

            // Alternatif satır stilleri
            gridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(54, 49, 50); // Renk 8: Alternatif satır arka plan rengi
            gridView.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(112, 233, 253); // Renk 1: Alternatif satır yazı rengi

            // Çerçeve ve kenarlıklar
            gridView.BorderStyle = BorderStyle.None;
            gridView.RowTemplate.Height = 30; // Satır yüksekliği
            gridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            // Seçili satır için özel stil
            gridView.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(247, 97, 93); // Renk 6: Seçili satır arka planı
            gridView.RowsDefaultCellStyle.SelectionForeColor = Color.White; // Yazı rengi

            // Genel ayarlar
            gridView.RowHeadersVisible = false; // Satır başlıklarını gizle
            gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Sütunlar tam genişlik
        }

        

        private void btnSellRandomProduct_Click_1(object sender, EventArgs e)
        {
            // 1. Ürünleri Veritabanından Çek
            DataTable products = GetProductsFromDatabase();

            if (products.Rows.Count > 0)
            {
                // 2. Rastgele Ürün Seçimi
                Random random = new Random();
                int randomIndex = random.Next(products.Rows.Count);
                DataRow selectedProduct = products.Rows[randomIndex];
                // Ürün bilgilerini al
                int productId = Convert.ToInt32(selectedProduct["ProductId"]);
                string productName = selectedProduct["ProductName"].ToString();
                decimal productPrice = Convert.ToDecimal(selectedProduct["ProductPrice"]);
                int productStock = Convert.ToInt32(selectedProduct["ProductStock"]);

                // Stok kontrolü
                if (productStock > 0)
                {
                    // 3. Stok Azaltma
                    UpdateProductStock(productId, productStock - 1);
                    // 4. DailySales Textbox'a Yazdır
                    txtDailySales.Text += $"Satılan Ürün: {productName}, Fiyat: {productPrice:C}, Kalan Stok: {productStock - 1}\r\n";
                    toplamsatıs += productPrice;
                    //5.FİYATI YAZDIR.
                    txtDailySalesPrice.Text = toplamsatıs.ToString();
                    decimal saleAmount = productPrice;
                    InsertSaleData(productId, saleAmount);
                }
                else
                {
                    MessageBox.Show("Stokta bu ürün yok!");
                }
            }
            else
            {
                MessageBox.Show("Veritabanında ürün bulunamadı!");
            }
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            // TextBox'lara hücre değerlerini ata
            txtProductName.Text = row.Cells["ProductName"].Value.ToString();
            txtProductPrice.Text = row.Cells["ProductPrice"].Value.ToString();
            txtProductStock.Text = row.Cells["ProductStock"].Value.ToString();
            txtProductId.Text = row.Cells["ProductId"].Value.ToString();
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            TblProduct tblProduct = new TblProduct();
            tblProduct.ProductPrice = decimal.Parse(txtProductPrice.Text);
            tblProduct.ProductStock = int.Parse(txtProductPrice.Text);
            tblProduct.ProductName = txtProductName.Text;
            tblProduct.CategoryId = int.Parse(cmbProductCategoryy.SelectedValue.ToString());
            db.TblProduct.Add(tblProduct);
            db.SaveChanges();
            ProductList();
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            var value = db.TblProduct.Find(int.Parse(txtProductId.Text));
            value.ProductPrice = decimal.Parse(txtProductPrice.Text);
            value.ProductStock = int.Parse(txtProductStock.Text);
            value.ProductName = txtProductName.Text;
            value.CategoryId = int.Parse(cmbProductCategoryy.SelectedValue.ToString());
            db.SaveChanges();
            ProductList();
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            var value = db.TblProduct.Find(int.Parse(txtProductId.Text));
            db.TblProduct.Remove(value);
            db.SaveChanges();
            ProductList();
        }

        private void btnList_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtList.Text)) // TextBox boşsa
            {
                ProductList();
            }
            else
            {
                // Filtrelenmiş veriyi getir
                var values = db.TblProduct.Where(x => x.ProductName == txtList.Text).ToList();
                dataGridView1.DataSource = values;
            }
        }

        private void btnUpdateList_Click_1(object sender, EventArgs e)
        {
            ProductList();
        }

        private void cmbProductCategory2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int selectedCategoryId = Convert.ToInt32(cmbProductCategory2.SelectedValue);

            if (selectedCategoryId == 0) // Tüm Kategoriler
            {
                dataGridView1.DataSource = db.TblProduct.ToList();
            }
            else
            {
                // Seçili kategoriye göre DataGridView'i filtrele
                var filteredData = db.TblProduct.Where(x => x.CategoryId == selectedCategoryId).Select(x => new { x.ProductName, x.ProductPrice, x.ProductId, x.ProductStock }).ToList();
                dataGridView1.DataSource = filteredData;
            }
        }
        private void ChangeUserControl(UserControl newControl)
        {
            // Mevcut olan UserControl'ü kaldırıyoruz
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is UserControl)
                {
                    this.Controls.Remove(ctrl);
                    ctrl.Dispose();
                }
            }
            // Yeni UserControl'ü ekliyoruz
            newControl.Dock = DockStyle.Fill;
            this.Controls.Add(newControl);
        }
    }
}
