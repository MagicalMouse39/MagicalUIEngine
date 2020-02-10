using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalUIEngine.HoverUI.Shapes
{
    public class ShapeEllipse : Shape
    {
        public int Width, Height;

        public ShapeEllipse(int X, int Y, Color backColor, int width, int height, float borderThickness = 0) : base(X, Y, backColor, borderThickness)
        {
            this.Width = width;
            this.Height = height;
        }

        public ShapeEllipse(int X, int Y, Brush backColor, int width, int height, float borderThickness = 0) : base(X, Y, backColor, borderThickness)
        {
            this.Width = width;
            this.Height = height;
        }

        public ShapeEllipse(Point position, Color backColor, int width, int height, float borderThickness = 0) : base(position, backColor, borderThickness)
        {
            this.Width = width;
            this.Height = height;
        }

        public ShapeEllipse(Point position, Brush backColor, int width, int height, float borderThickness = 0) : base(position, backColor, borderThickness)
        {
            this.Width = width;
            this.Height = height;
        }
    }
}
