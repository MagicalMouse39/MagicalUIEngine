using MagicalUIEngine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
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

            ui.Render += (s, e) =>
            {
                Graphics g = e.Graphics;

                g.DrawString("Minecraft", new Font("Minecrafter", 32, FontStyle.Regular), Brushes.OrangeRed, 500, 500);
            };

            ui.FormClosing += (s, e) => e.Cancel = true;

            ui.Run();
        }
    }
}
