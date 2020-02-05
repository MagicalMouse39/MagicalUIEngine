using MagicalUIEngine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            HoverUI interfaccia = new HoverUI();

            var rect = new MagicalUIEngine.Shapes.Rectangle(0, 0, Color.OrangeRed, 50, 50);

            var color = new MagicalUIEngine.Shapes.String(100, 100, Color.White, "Color: ");

            interfaccia.Render += (s, e) =>
            {
                color.Text = $"Color: {interfaccia.GetColorAtPixel(new Point(0, 0))}";

                int speed = 5;

                if (interfaccia.GetBackgroundKeyDown(Keys.Right))
                    rect.X += speed;
                if (interfaccia.GetBackgroundKeyDown(Keys.Left))
                    rect.X -= speed;

                if (interfaccia.GetBackgroundKeyDown(Keys.Up))
                    rect.Y -= speed;
                if (interfaccia.GetBackgroundKeyDown(Keys.Down))
                    rect.Y += speed;


            };

            interfaccia.AddShape(color);
            interfaccia.AddShape(rect);

            interfaccia.Run();
        }
    }
}
