using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalUIEngine.Shapes
{
    public class Rectangle : Shape
    {
        public int Width, Height;

        public Rectangle(Point position, Color backColor, int width, int height, float borderThickness = 0) : base(position, backColor, borderThickness)
        {
            this.Width = width;
            this.Height = height;
        }

        public Rectangle(Point position, Brush backColor, int width, int height, float borderThickness = 0) : base(position, backColor, borderThickness)
        {
            this.Width = width;
            this.Height = height;
        }
    }
}
