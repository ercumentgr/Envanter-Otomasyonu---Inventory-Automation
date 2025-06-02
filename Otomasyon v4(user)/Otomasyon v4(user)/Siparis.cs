using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using System.Drawing;

namespace Otomasyon_v4_user_
{
    public partial class Siparis : UserControl
    {
        public event EventHandler BackToGiris;
        private string connectionString = "Server=DESKTOP-D5RU4QE;Database=StokTakipv2;Integrated Security=True;";
        DbProject2Entities db = new DbProject2Entities();

        public class ComboBoxItem
        {
            public string Text { get; set; } // Görünen metin (Product Name)
            public int Value { get; set; }   // Gizli değer (ProductId)
        }
        public Siparis()
        {
            InitializeComponent();
            this.SuspendLayout();
            // 
            // UserControl2
            // 
            this.Name = "UserControl3";
            this.Size = new System.Drawing.Size(300, 200);
            this.ResumeLayout(false);
        }

        private void Siparis_Load(object sender, EventArgs e)
        {
            this.SuspendLayout();
            LoadProductsToComboBox();
            ProductList();
            ApplyModernStyles();
            ApplyModernDataGridViewStyle(dataGridView1);
            this.BackColor = Color.FromArgb(46, 44, 47); // Arka plan rengi: Renk 4
            this.Font = new Font("Segoe UI", 10, FontStyle.Regular); // Modern font

            // DataGridView başlıklarını ayarla
            if (dataGridView1.Columns.Count >= 3)
            {
                dataGridView1.Columns[0].HeaderText = "Ürün Adı";
                dataGridView1.Columns[1].HeaderText = "Ürün Fiyatı";
                dataGridView1.Columns[2].HeaderText = "Ürün Stok";
            }
        }
        private void ProductList()
        {
            dataGridView1.DataSource = db.TblProduct
                .Select(x => new { x.ProductName, x.ProductPrice, x.ProductStock })
                .ToList();
        }
        private void LoadProductsToComboBox()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT ProductId, ProductName FROM TblProduct", conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var item = new ComboBoxItem
                        {
                            Text = reader["ProductName"].ToString(),
                            Value = Convert.ToInt32(reader["ProductId"])
                        };
                    }
                }
            }
        }
        private decimal GetProductPrice(string productName)
        {
            decimal productPrice = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT ProductPrice FROM TblProduct WHERE ProductName = @ProductName";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductName", productName);
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        productPrice = Convert.ToDecimal(result);
                    }
                }
            }
            return productPrice;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Geçerli bir satır seçilmiş mi?
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtProductName.Text = row.Cells["ProductName"].Value.ToString();
                txtUnitPrice.Text = row.Cells["ProductPrice"].Value.ToString(); // Ürün fiyatını doldur
                nudQuantity.Value = 1; // Varsayılan olarak 1 adet
                UpdateTotalPrice();
            }
        }
        private void nudQuantity_ValueChanged_1(object sender, EventArgs e)
        {
            UpdateTotalPrice();
        }
        private void UpdateTotalPrice()
        {
            if (decimal.TryParse(txtUnitPrice.Text, out decimal unitPrice))
            {
                int quantity = (int)nudQuantity.Value;
                decimal totalPrice = unitPrice * quantity;
                txtTotalPrice.Text = totalPrice.ToString("C");
            }
            else
            {
                txtTotalPrice.Text = "0";
            }
        }
        private int GetProductIdByName(string productName)
        {
            int productId = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT ProductId FROM TblProduct WHERE ProductName = @ProductName";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductName", productName);

                object result = command.ExecuteScalar();
                if (result != null)
                {
                    productId = Convert.ToInt32(result);
                }
            }

            return productId;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtProductName.Text) && nudQuantity.Value > 0)
            {
                string productName = txtProductName.Text; // Ürün adı TextBox'tan alınıyor
                int quantity = (int)nudQuantity.Value;    // Sipariş miktarı

                // Veritabanından ürün ID'sini alıyoruz
                int productId = GetProductIdByName(productName);

                if (productId == 0)
                {
                    MessageBox.Show("Girilen ürün adına ait bir ürün bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SaveOrder(productId, quantity);
                UpdateProductStock(productId, quantity);

                // Ürün fiyatını al ve toplam fiyatı hesapla
                decimal productPrice = GetProductPrice(productName);
                decimal totalPrice = productPrice * quantity;

                string supplierEmail = txtSupplierEmail.Text; // Tedarikçi e-posta adresi

                SendOrderEmail(productName, quantity, totalPrice, supplierEmail);

                MessageBox.Show("Sipariş başarıyla alındı ve e-posta gönderildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir ürün adı ve miktar girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void SaveOrder(int productId, int quantity)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO TblOrder (ProductId, OrderAmount, SupplierEmail) VALUES (@ProductId, @OrderAmount, @SupplierEmail)", conn))
                {
                    cmd.Parameters.AddWithValue("@ProductId", productId);
                    cmd.Parameters.AddWithValue("@OrderAmount", quantity);
                    cmd.Parameters.AddWithValue("@SupplierEmail", txtSupplierEmail.Text);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void UpdateProductStock(int productId, int quantity)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE TblProduct SET ProductStock = ProductStock + @Quantity WHERE ProductId = @ProductId", conn))
                {
                    cmd.Parameters.AddWithValue("@Quantity", quantity);
                    cmd.Parameters.AddWithValue("@ProductId", productId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void SendOrderEmail(string productName, int quantity, decimal totalPrice, string supplierEmail)
        {
            string fromEmail = "otomasyontedarik@gmail.com";
            string fromPassword = "shze qaes tbnq ttfn";

            try
            {
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential(fromEmail, fromPassword),
                    EnableSsl = true
                };

                string subject = "Yeni Sipariş Alındı";
                string body = $"Ürün: {productName}\nMiktar: {quantity}\nToplam Fiyat: {totalPrice:C}\nTedarikçi E-posta: {supplierEmail}";

                MailMessage mailMessage = new MailMessage(fromEmail, supplierEmail, subject, body);
                smtpClient.Send(mailMessage);

                MessageBox.Show("E-posta gönderildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"E-posta gönderme hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
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
                btnBackToGiris.BackColor = Color.FromArgb(46, 44, 47);
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

        private void btnBackToGiris_Click(object sender, EventArgs e)
        {
            BackToGiris?.Invoke(this, EventArgs.Empty);
        }
    }
}
