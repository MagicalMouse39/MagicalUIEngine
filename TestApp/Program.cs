using MagicalUIEngine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            HoverUI ui = new HoverUI();

            int X = 0, Y = 0;

            ui.Render += (s, e) =>
            {
                Graphics g = e.Graphics;

                if (ui.GetBackgroundKeyDown(Keys.Right))
                    X++;

                if (ui.GetBackgroundKeyDown(Keys.Left))
                    X--;

                g.FillRectangle(Brushes.White, X, Y, 50, 50);
            };

            ui.Run();
        }
    }
}
