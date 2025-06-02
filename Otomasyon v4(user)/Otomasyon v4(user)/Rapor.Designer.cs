namespace Otomasyon_v4_user_
{
    partial class Rapor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Rapor));
            this.elementHost2 = new System.Windows.Forms.Integration.ElementHost();
            this.cartesianChartOrders = new LiveCharts.Wpf.CartesianChart();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.cartesianChartSales = new LiveCharts.Wpf.CartesianChart();
            this.elementHost3 = new System.Windows.Forms.Integration.ElementHost();
            this.pieChartStock = new LiveCharts.Wpf.PieChart();
            this.btnBackToGiris = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // elementHost2
            // 
            this.elementHost2.Location = new System.Drawing.Point(752, 15);
            this.elementHost2.Name = "elementHost2";
            this.elementHost2.Size = new System.Drawing.Size(623, 391);
            this.elementHost2.TabIndex = 7;
            this.elementHost2.Text = "elementHost2";
            this.elementHost2.Child = this.cartesianChartOrders;
            // 
            // elementHost1
            // 
            this.elementHost1.Location = new System.Drawing.Point(133, 15);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(623, 391);
            this.elementHost1.TabIndex = 6;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.cartesianChartSales;
            // 
            // elementHost3
            // 
            this.elementHost3.Location = new System.Drawing.Point(487, 421);
            this.elementHost3.Name = "elementHost3";
            this.elementHost3.Size = new System.Drawing.Size(574, 391);
            this.elementHost3.TabIndex = 8;
            this.elementHost3.Text = "elementHost3";
            this.elementHost3.Child = this.pieChartStock;
            // 
            // btnBackToGiris
            // 
            this.btnBackToGiris.Image = ((System.Drawing.Image)(resources.GetObject("btnBackToGiris.Image")));
            this.btnBackToGiris.Location = new System.Drawing.Point(0, 0);
            this.btnBackToGiris.Name = "btnBackToGiris";
            this.btnBackToGiris.Size = new System.Drawing.Size(70, 52);
            this.btnBackToGiris.TabIndex = 9;
            this.btnBackToGiris.UseVisualStyleBackColor = true;
            this.btnBackToGiris.Click += new System.EventHandler(this.btnBackToGiris_Click);
            // 
            // Rapor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnBackToGiris);
            this.Controls.Add(this.elementHost2);
            this.Controls.Add(this.elementHost1);
            this.Controls.Add(this.elementHost3);
            this.Name = "Rapor";
            this.Size = new System.Drawing.Size(1240, 751);
            this.Load += new System.EventHandler(this.Rapor_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Integration.ElementHost elementHost2;
        private LiveCharts.Wpf.CartesianChart cartesianChartOrders;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private LiveCharts.Wpf.CartesianChart cartesianChartSales;
        private System.Windows.Forms.Integration.ElementHost elementHost3;
        private LiveCharts.Wpf.PieChart pieChartStock;
        private System.Windows.Forms.Button btnBackToGiris;
    }
}
