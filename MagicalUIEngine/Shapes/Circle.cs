using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalUIEngine.Shapes
{
    public class Circle : Shape
    {
        public int Radius;

        public Circle(Point position, Color backColor, int radius, float borderThickness = 0) : base(position, backColor, borderThickness) => this.Radius = radius;

        public Circle(Point position, Brush backColor, int radius, float borderThickness = 0) : base(position, backColor, borderThickness) => this.Radius = radius;
    }
}
