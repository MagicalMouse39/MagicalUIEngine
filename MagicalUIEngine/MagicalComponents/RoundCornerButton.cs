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

        public RoundCornerButton()
        {
            this.BackColor = Color.DimGray;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            Graphics g = pevent.Graphics;

            int vw = this.Width / 100;
            int vh = this.Height / 100;

            GraphicsPath path = new GraphicsPath();
            path.FillMode = FillMode.Winding;

            if (this.Width < 100)
                vw = 1;
            if (this.Height < 100)
                vh = 1;

            //Corners
            path.AddEllipse(new Rectangle(-1, -1, 20 * vw, 20 * vh));
            path.AddEllipse(new Rectangle(this.Width - 20 * vw + 1, -1, 20 * vw, 20 * vh));
            path.AddEllipse(new Rectangle(-1, this.Height - 20 * vh + 1, 20 * vw, 20 * vh));
            path.AddEllipse(new Rectangle(this.Width - 20 * vw + 1, this.Height - 20 * vh + 1, 20 * vw, 20 * vh));

            //Edges
            path.AddRectangle(new Rectangle(10 * vw, 0, this.Width - 20 * vw, 20 * vh));
            path.AddRectangle(new Rectangle(10 * vw, this.Height - 20 * vh, this.Width - 20 * vw, 20 * vh));
            path.AddRectangle(new Rectangle(0, 10 * vh, 20 * vw, this.Height - 20 * vh));
            path.AddRectangle(new Rectangle(this.Width - 20 * vw, 10 * vh, 20 * vw, this.Height - 20 * vh));

            //Center
            path.AddRectangle(new Rectangle(5 * vw, 5 * vh, this.Width - 10 * vw, this.Height - 10 * vh));

            g.FillRectangle(new SolidBrush(this.Parent.BackColor), this.ClientRectangle);
            g.FillPath(new SolidBrush(this.BackColor), path);


            //base.OnPaint(pevent);
        }
    }
}
