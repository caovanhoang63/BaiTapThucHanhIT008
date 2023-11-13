using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2_Bai2._4
{
    public partial class Form1 : Form
    {
        private Random random = new Random();

        public Form1()
        {
            InitializeComponent();
            this.Paint+=MainForm_Paint;
        }
        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            // Gọi hàm vẽ mỗi khi sự kiện Paint xảy ra
            DrawPaintEventText(e.Graphics);
        }
        private void DrawPaintEventText(Graphics g)
        {
            // Lấy kích thước Form
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;

            // Tạo vị trí ngẫu nhiên
            int x = random.Next(0, formWidth);
            int y = random.Next(0, formHeight);
            Font verdana14 = new Font("Verdana", 14);

            // Vẽ chuỗi "Paint Event" tại vị trí ngẫu nhiên
            g.DrawString("Paint Event", verdana14, Brushes.Black, new PointF(x, y));
        }

    }
}
