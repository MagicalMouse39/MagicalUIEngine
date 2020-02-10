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
    public class GradientPanel : Panel
    {
        public Color ColorFirst { get; set; } = Color.Black;
        public Color ColorSecond { get; set; } = Color.White;
        public float GradientDegree { get; set; } = 90f;

        public GradientPanel()
        {
            this.Paint += (s, e) =>
            {
                Graphics g = e.Graphics;
                g.FillRectangle(new LinearGradientBrush(this.ClientRectangle, this.ColorFirst, this.ColorSecond, this.GradientDegree), this.ClientRectangle);
            };
        }
    }
}
