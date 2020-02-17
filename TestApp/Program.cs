using MagicalUIEngine.HoverUI;
using MagicalUIEngine.HoverUI.Shapes;
using MagicalUIEngine.HoverUI.Components;
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
using MagicalUIEngine.MagicalComponents;

namespace TestApp
{
    class Program
    {
        private static void CreateHoverUI()
        {
            HoverUI interfaccia = new HoverUI();

            var rect = new ShapeRectangle(0, 0, Color.OrangeRed, 50, 50);

            var color = new ShapeString(100, 100, Color.White, "Color: ");

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

        private static void CreateMagicalForm()
        {
            Form win = new Form();


            //RainbowSynchronizer synch = new RainbowSynchronizer();

            /*
            GradientPanel panel = new GradientPanel() { Dock = DockStyle.Fill, ColorFirst = Color.OrangeRed, ColorSecond = Color.Yellow };
            win.Controls.Add(panel);
            */

            /*
            GradientLabel lab = new GradientLabel() { Text = "Prova", Font = new Font("Calibri", 32f, FontStyle.Regular), ColorFirst = Color.Green, ColorSecond = Color.Turquoise, GradientDegree = 0, BackColor = Color.Transparent, Height = 100, Width = 300 };
            lab.EnableRainbow(synch);
            win.Controls.Add(lab);
            */
            win.Controls.Add(new RoundCornerButton() { Left = 100, Top = 100, Width = 100 });

            Syntax synt = new Syntax();
            synt.AddWord("ciao", Color.Blue, true, true);

            win.Controls.Add(new SyntaxHighlightingTextArea(synt) { Dock = DockStyle.Fill });

            win.Controls[0].Click += (s, e) => MessageBox.Show("Cliccato il bottone");

            Application.EnableVisualStyles();
            Application.Run(win);
        }

        static void Main(string[] args)
        {
            //CreateHoverUI();

            CreateMagicalForm();
        }
    }
}
