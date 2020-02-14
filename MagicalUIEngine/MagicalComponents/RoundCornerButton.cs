using MagicalUIEngine.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagicalUIEngine.MagicalComponents
{
    public class RoundCornerButton : Button
    {
        private Color backColor = Color.Transparent;
        public Color HoverColor { get; set; } = Color.Gray;
        public Color BorderColor { get; set; } = Color.OrangeRed;

        public RoundCornerButton()
        {
            this.backColor = this.BackColor;
            this.MouseEnter += (s, e) =>
                this.BackColor = this.HoverColor;
            this.MouseLeave += (s, e) =>
                this.BackColor = this.backColor;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            Graphics g = pevent.Graphics;

            int vw = this.Width / 100;
            int vh = this.Height / 100;

            GraphicsPath path = new GraphicsPath();
            path.FillMode = FillMode.Winding;

            GraphicsPath inner = new GraphicsPath();
            inner.FillMode = FillMode.Winding;


            if (this.Width < 100)
                vw = 1;
            if (this.Height < 100)
                vh = 1;

            //Corners
            path.AddEllipse(new Rectangle(-1, -1, 20 * vw, 20 * vh));
            path.AddEllipse(new Rectangle(this.Width - 20 * vw + 1, -1, 20 * vw, 20 * vh));
            path.AddEllipse(new Rectangle(-1, this.Height - 20 * vh + 1, 20 * vw, 20 * vh));
            path.AddEllipse(new Rectangle(this.Width - 20 * vw + 1, this.Height - 20 * vh + 1, 20 * vw, 20 * vh));

            inner.AddEllipse(new Rectangle(3, 3, 16 * vw, 16 * vh));
            inner.AddEllipse(new Rectangle(this.Width - 20 * vw, 3, 16 * vw, 16 * vh));
            inner.AddEllipse(new Rectangle(3, this.Height - 20 * vh, 16 * vw, 16 * vh));
            inner.AddEllipse(new Rectangle(this.Width - 20 * vw, this.Height - 21 * vh + 1, 16 * vw, 16 * vh));

            //Edges
            path.AddRectangle(new Rectangle(10 * vw, 0, this.Width - 20 * vw, 20 * vh));
            path.AddRectangle(new Rectangle(10 * vw, this.Height - 20 * vh, this.Width - 20 * vw, 20 * vh));
            path.AddRectangle(new Rectangle(0, 10 * vh, 20 * vw, this.Height - 20 * vh));
            path.AddRectangle(new Rectangle(this.Width - 20 * vw, 10 * vh, 20 * vw, this.Height - 20 * vh));

            inner.AddRectangle(new Rectangle(14 * vw, 4, this.Width - 24 * vw, 16 * vh));
            inner.AddRectangle(new Rectangle(14 * vw, this.Height - 24 * vh, this.Width - 24 * vw, 16 * vh + 4));
            inner.AddRectangle(new Rectangle(4, 14 * vh, 16 * vw, this.Height - 24 * vh));
            inner.AddRectangle(new Rectangle(this.Width - 24 * vw, 14 * vh, 16 * vw + 4, this.Height - 24 * vh));

            //Center
            path.AddRectangle(new Rectangle(5 * vw, 5 * vh, this.Width - 10 * vw, this.Height - 10 * vh));
            inner.AddRectangle(new Rectangle(5 * vw, 5 * vh, this.Width - 10 * vw, this.Height - 10 * vh));

            g.FillRectangle(new SolidBrush(this.Parent.BackColor), this.ClientRectangle);


            int scale = 4 * vw;

            g.FillPath(new SolidBrush(this.BorderColor), path);
            g.FillPath(new SolidBrush(this.BackColor), inner);
        }
    }
}
