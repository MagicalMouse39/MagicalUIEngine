using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalUIEngine.HoverUI.Shapes
{
    public class ShapeString : Shape
    {
        public string Text;
        public Font Font = new Font("Calibri", 16, FontStyle.Regular);

        public ShapeString(int X, int Y, Color color, string text, float borderThickness = 0) : base(X, Y, color, borderThickness) => this.Text = text;
        public ShapeString(int X, int Y, Brush color, string text, float borderThickness = 0) : base(X, Y, color, borderThickness) => this.Text = text;

        public ShapeString(Point position, Color color, string text, float borderThickness = 0) : base(position, color, borderThickness) => this.Text = text;
        public ShapeString(Point position, Brush color, string text, float borderThickness = 0) : base(position, color, borderThickness) => this.Text = text;
    }
}
