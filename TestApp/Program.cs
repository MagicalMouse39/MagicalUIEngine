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

            ui.AddShape(new MagicalUIEngine.Shapes.String(100, 100, Color.Blue, "Prova"));

            ui.AddShape(new MagicalUIEngine.Shapes.Rectangle(500, 50, Color.OrangeRed, 50, 50, 10) { BorderBrush = Brushes.Purple });

            ui.AddCustomImage(new Image());

            ui.Run();
        }
    }
}
