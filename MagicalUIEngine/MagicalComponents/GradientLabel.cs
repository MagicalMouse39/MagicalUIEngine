using MagicalUIEngine.MagicalComponents;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestApp
{
    public class GradientLabel : Label
    {
        public Color ColorFirst { get; set; } = Color.Black;
        public Color ColorSecond { get; set; } = Color.White;
        public float GradientDegree { get; set; } = 90f;

        private bool isRainbow = false;
        private RainbowSynchronizer rainbowSynch = null;

        private int[] rgb = new[] { 255, 0, 0 };
        private int[] rgb2 = new[] { 255, 255, 0 };

        public void EnableRainbow(RainbowSynchronizer rs)
        {
            this.rainbowSynch = rs;
            this.isRainbow = true;
            this.Refresh();
        }

        public void DisableRainbow()
        {
            this.isRainbow = false;
            this.rainbowSynch = null;
        }

        public GradientLabel()
        {
            this.Paint += (s, e) =>
            {
                if (this.isRainbow)
                {
                    int R0 = this.rainbowSynch.R0;
                    int G0 = this.rainbowSynch.G0;
                    int B0 = this.rainbowSynch.B0;

                    int R1 = this.rainbowSynch.R1;
                    int G1 = this.rainbowSynch.G1;
                    int B1 = this.rainbowSynch.B1;
                    
                    //Set color
                    e.Graphics.DrawString(this.Text, this.Font, new LinearGradientBrush(this.ClientRectangle, Color.FromArgb(R0, G0, B0), Color.FromArgb(R1, G1, B1), this.GradientDegree), this.Location);
                    this.Invalidate();
                }
                if (!this.isRainbow)
                {
                    e.Graphics.DrawString(this.Text, this.Font, new LinearGradientBrush(this.ClientRectangle, this.ColorFirst, this.ColorSecond, this.GradientDegree), this.Location);
                }
            };
        }
    }
}
