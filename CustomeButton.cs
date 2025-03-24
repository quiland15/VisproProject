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
    internal class CustomButton : Button
    {
        public Color BorderColor { get; set; } = Color.White;
        public int BorderSize { get; set; } = 2;
        public int BorderRadius { get; set; } = 20;

        private bool isClicked = false;

        public CustomButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.BackColor = Color.Transparent;
            this.ForeColor = Color.White;
            this.Font = new Font("Arial", 10, FontStyle.Bold);
            this.Size = new Size(120, 40);
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Buat border dengan rounded corner
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(0, 0, BorderRadius, BorderRadius, 180, 90);
                path.AddArc(Width - BorderRadius, 0, BorderRadius, BorderRadius, 270, 90);
                path.AddArc(Width - BorderRadius, Height - BorderRadius, BorderRadius, BorderRadius, 0, 90);
                path.AddArc(0, Height - BorderRadius, BorderRadius, BorderRadius, 90, 90);
                path.CloseFigure();

                this.Region = new Region(path);

                using (Pen pen = new Pen(BorderColor, BorderSize))
                {
                    pevent.Graphics.DrawPath(pen, path);
                }
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            if (!isClicked)
            {
                this.BackColor = Color.White;
                this.ForeColor = Color.Black;
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (!isClicked)
            {
                this.BackColor = Color.Transparent;
                this.ForeColor = Color.White;
            }
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            isClicked = true;
            this.BackColor = Color.White;
            this.ForeColor = Color.Black;

            // Reset semua button lain di form
            foreach (Control control in this.Parent.Controls)
            {
                if (control is CustomButton button && button != this)
                {
                    button.ResetButton();
                }
            }
        }

        public void ResetButton()
        {
            isClicked = false;
            this.BackColor = Color.Transparent;
            this.ForeColor = Color.White;
        }
    }
}
