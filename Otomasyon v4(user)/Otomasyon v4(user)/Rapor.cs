using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;
using System.Windows.Media;


namespace Otomasyon_v4_user_
{
    public partial class Rapor : UserControl
    {
        public event EventHandler BackToGiris;
        public Rapor()
        {
            InitializeComponent();
            this.SuspendLayout();
            // 
            // UserControl2
            // 
            this.Name = "UserControl2";
            this.Size = new System.Drawing.Size(300, 200);
            this.ResumeLayout(false);
        }
        private string connectionString = "Server=DESKTOP-D5RU4QE;Database=StokTakipv2;Integrated Security=True;";
        private void Rapor_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.FromArgb(46, 44, 47); // Arka plan: Renk 4
            LoadSalesChart();
            LoadStockChart();
            LoadOrdersChart();
            btnBackToGiris.BackColor =System.Drawing.Color.FromArgb(46, 44, 47);
            btnBackToGiris.FlatStyle = FlatStyle.Flat;
            btnBackToGiris.FlatAppearance.BorderSize = 0;
            btnBackToGiris.Cursor = Cursors.Hand;

        }
        private void LoadSalesChart()
        {
            cartesianChartSales.Series.Clear();

            ChartValues<int> salesValues = new ChartValues<int>();
            List<string> productNames = new List<string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT p.ProductName, SUM(s.SaleAmount) AS TotalSales " +
                               "FROM TblSales s " +
                               "JOIN TblProduct p ON s.ProductId = p.ProductId " +
                               "GROUP BY p.ProductName";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        productNames.Add(reader["ProductName"].ToString());
                        salesValues.Add(Convert.ToInt32(reader["TotalSales"]));
                    }
                }
            }

            // Bar grafiği için renk düzenlemesi (sıcak-soğuk geçiş)
            var colors = new[] {
                Color.FromRgb(247, 97, 93),  // Renk 6
                Color.FromRgb(245, 80, 107), // Renk 3
                Color.FromRgb(252, 210, 99), // Renk 7
                Color.FromRgb(248, 230, 73), // Renk 2
                Color.FromRgb(112, 233, 253) // Renk 1
            };

            cartesianChartSales.Series.Add(new ColumnSeries
            {
                Title = "Satışlar",
                Values = salesValues,
                Fill = new LinearGradientBrush
                {
                    GradientStops = new GradientStopCollection
                    {
                        new GradientStop(colors[0], 0), // İlk renk
                        new GradientStop(colors[4], 1)  // Son renk
                    }
                }
            });

            // Eksen düzenlemesi
            cartesianChartSales.AxisX.Clear();
            cartesianChartSales.AxisX.Add(new Axis
            {
                Title = "Ürünler",
                Labels = productNames,
                Foreground = new SolidColorBrush(Color.FromRgb(248, 230, 73)) // Açık sarı (Renk 2)
            });

            cartesianChartSales.AxisY.Clear();
            cartesianChartSales.AxisY.Add(new Axis
            {
                Title = "Satış Miktarı",
                LabelFormatter = value => value.ToString("N0"),
                Foreground = new SolidColorBrush(Color.FromRgb(112, 233, 253)) // Açık mavi (Renk 1)
            });

            cartesianChartSales.Background = new SolidColorBrush(Color.FromRgb(54, 49, 50)); // Arka plan: Renk 8
        }

        private void LoadStockChart()
        {
            pieChartStock.Series.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT ProductName, ProductStock FROM TblProduct";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string productName = reader["ProductName"].ToString();
                        int stock = Convert.ToInt32(reader["ProductStock"]);

                        pieChartStock.Series.Add(new PieSeries
                        {
                            Title = productName,
                            Values = new ChartValues<int> { stock },
                            DataLabels = true,
                            Fill = new SolidColorBrush(Color.FromRgb(245, 80, 107)) // Sabit bir renk: Renk 3
                        });
                    }
                }
            }

            pieChartStock.LegendLocation = LegendLocation.Right;
            pieChartStock.Background = new SolidColorBrush(Color.FromRgb(54, 49, 50)); // Arka plan: Renk 8
        }

        private void LoadOrdersChart()
        {
            cartesianChartOrders.Series.Clear();

            ChartValues<int> orderValues = new ChartValues<int>();
            List<string> productNames = new List<string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT p.ProductName, SUM(o.OrderAmount) AS TotalOrders " +
                               "FROM TblOrder o " +
                               "JOIN TblProduct p ON o.ProductId = p.ProductId " +
                               "GROUP BY p.ProductName";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        productNames.Add(reader["ProductName"].ToString());
                        orderValues.Add(Convert.ToInt32(reader["TotalOrders"]));
                    }
                }
            }

            cartesianChartOrders.Series.Add(new ColumnSeries
            {
                Title = "Siparişler",
                Values = orderValues,
                Fill = new LinearGradientBrush
                {
                    GradientStops = new GradientStopCollection
                    {
                        new GradientStop(Color.FromRgb(247, 97, 93), 0), // Sıcak renk: Renk 6
                        new GradientStop(Color.FromRgb(112, 233, 253), 1)  // Soğuk renk: Renk 1
                    }
                }
            });

            cartesianChartOrders.AxisX.Add(new Axis
            {
                Title = "Ürünler",
                Labels = productNames,
                Foreground = new SolidColorBrush(Color.FromRgb(248, 230, 73)) // Açık sarı: Renk 2
            });

            cartesianChartOrders.AxisY.Add(new Axis
            {
                Title = "Sipariş Miktarı",
                LabelFormatter = value => value.ToString("N0"),
                Foreground = new SolidColorBrush(Color.FromRgb(112, 233, 253)) // Açık mavi: Renk 1
            });

            cartesianChartOrders.Background = new SolidColorBrush(Color.FromRgb(54, 49, 50)); // Arka plan: Renk 4
        }

        private void btnBackToGiris_Click(object sender, EventArgs e)
        {
            BackToGiris?.Invoke(this, EventArgs.Empty);
        }
    }
}
