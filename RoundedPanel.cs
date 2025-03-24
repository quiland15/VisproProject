using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace VisproProject
{
    internal class RoundedPanel : Panel
    {
        public int BorderRadius { get; set; } = 30;
        public Color BorderColor { get; set; } = Color.Black;
        public int BorderSize { get; set; } = 2;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Buat path lingkaran
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, this.Width, this.Height);
            this.Region = new Region(path);

            // Buat border
            using (Pen pen = new Pen(BorderColor, BorderSize))
            {
                e.Graphics.DrawEllipse(pen, 0, 0, this.Width - 1, this.Height - 1);
            }
        }
    }
}
