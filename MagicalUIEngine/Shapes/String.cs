using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalUIEngine.Shapes
{
    public class String : Shape
    {
        public string Text;
        public Font Font = new Font("Calibri", 16, FontStyle.Regular);

        public String(int X, int Y, Color color, string text, float borderThickness = 0) : base(X, Y, color, borderThickness) => this.Text = text;
        public String(int X, int Y, Brush color, string text, float borderThickness = 0) : base(X, Y, color, borderThickness) => this.Text = text;

        public String(Point position, Color color, string text, float borderThickness = 0) : base(position, color, borderThickness) => this.Text = text;
        public String(Point position, Brush color, string text, float borderThickness = 0) : base(position, color, borderThickness) => this.Text = text;
    }
}
