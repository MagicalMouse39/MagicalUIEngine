using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalUIEngine.HoverUI.Shapes
{
    public class ShapeCircle : Shape
    {
        public int Radius;

        public ShapeCircle(int X, int Y, Color backColor, int radius, float borderThickness = 0) : base(X, Y, backColor, borderThickness) => this.Radius = radius;
        public ShapeCircle(int X, int Y, Brush backColor, int radius, float borderThickness = 0) : base(X, Y, backColor, borderThickness) => this.Radius = radius;
        public ShapeCircle(Point position, Color backColor, int radius, float borderThickness = 0) : base(position, backColor, borderThickness) => this.Radius = radius;
        public ShapeCircle(Point position, Brush backColor, int radius, float borderThickness = 0) : base(position, backColor, borderThickness) => this.Radius = radius;
    }
}
