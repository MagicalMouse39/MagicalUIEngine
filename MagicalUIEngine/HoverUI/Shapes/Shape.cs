using MagicalUIEngine.HoverUI.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalUIEngine.HoverUI.Shapes
{
    public abstract class Shape
    {
        public Point Position;
        public Brush BackBrush;
        public Brush BorderBrush = new SolidBrush(Color.Transparent);

        public float BorderThickness;

        public int X
        {
            get
            {
                return this.Position.X;
            }
            set
            {
                this.Position.X = value;
            }
        }

        public int Y
        {
            get
            {
                return this.Position.Y;
            }
            set
            {
                this.Position.Y = value;
            }
        }

        public Shape(Point position, Color backColor, float borderThickness = 0f)
        {
            this.Position = position;
            this.BackBrush = new SolidBrush(backColor);
            this.BorderThickness = borderThickness;
        }

        public Shape(int X, int Y, Color backColor, float borderThickness = 0f)
        {
            this.Position = new Point(X, Y);
            this.BackBrush = new SolidBrush(backColor);
            this.BorderThickness = borderThickness;
        }

        public Shape(int X, int Y, Brush backColor, float borderThickness = 0f)
        {
            this.Position = new Point(X, Y);
            this.BackBrush = backColor;
            this.BorderThickness = borderThickness;
        }

        public Shape(Point position, Brush backColor, float borderThickness = 0f)
        {
            this.Position = position;
            this.BackBrush = backColor;
            this.BorderThickness = borderThickness;
        }

        public void MoveRight(int val) => this.Position.X += val;
        public void MoveUp(int val) => this.Position.Y -= val;
        public void MoveLeft(int val) => this.Position.X -= val;
        public void MoveDown(int val) => this.Position.Y += val;
    }
}
