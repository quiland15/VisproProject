using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisproProject
{
    internal class RoundedPictureBox : PictureBox
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, this.Width, this.Height);
            this.Region = new Region(path);
        }
    }
}
