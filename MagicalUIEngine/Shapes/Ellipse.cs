using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalUIEngine.Shapes
{
    class Ellipse : Shape
    {
        public int Width, Height;

        public Ellipse(Point position, Color backColor, int width, int height, float borderThickness = 0) : base(position, backColor, borderThickness)
        {
            this.Width = width;
            this.Height = height;
        }

        public Ellipse(Point position, Brush backColor, int width, int height, float borderThickness = 0) : base(position, backColor, borderThickness)
        {
            this.Width = width;
            this.Height = height;
        }
    }
}
