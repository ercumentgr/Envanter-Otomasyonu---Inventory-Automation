using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otomasyon_v4_user_
{
    public partial class GirisAnimasyon : UserControl
    {
        public event EventHandler AnimationCompleted; // Animasyon tamamlandığında tetiklenecek olay
        public GirisAnimasyon()
        {
            InitializeComponent();
            label1.ForeColor = Color.White;
        }
        private void GirisAnimasyon_Load(object sender, EventArgs e)
        {
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;

            timer1.Interval = 45; // Animasyon hızını ayarlayın (ms)
            timer1.Enabled = true;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value += 2; // İlerleme hızını ayarlayın

            if (progressBar1.Value >= progressBar1.Maximum)
            {
                timer1.Stop();
                AnimationCompleted?.Invoke(this, EventArgs.Empty); // Animasyon bittiğinde olayı tetikle
            }
        }
    }
}
