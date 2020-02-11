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
        private RainbowSynchronizer RainbowSynch = null;

        private int[] rgb = new[] { 255, 0, 0 };
        private int[] rgb2 = new[] { 255, 255, 0 };

        public void EnableRainbow(RainbowSynchronizer rs)
        {
            this.RainbowSynch = rs;
            this.isRainbow = true;
        }

        public void DisableRainbow()
        {
            this.isRainbow = false;
            this.RainbowSynch = null;
        }

        public GradientLabel()
        {
            this.Paint += (s, e) =>
            {
                if (this.isRainbow)
                {
                    //Update RGB
                    /*
                    if (this.rgb[0] == 255 && this.rgb[2] == 0 && this.rgb[1] < 255)
                        this.rgb[1]++;
                    if (this.rgb[1] == 255 && this.rgb[2] == 0 && this.rgb[0] > 0)
                        this.rgb[0]--;
                    if (this.rgb[0] == 0 && this.rgb[1] == 255 && this.rgb[2] < 255)
                        this.rgb[2]++;
                    if (this.rgb[0] == 0 && this.rgb[2] == 255 && this.rgb[1] > 0)
                        this.rgb[1]--;
                    if (this.rgb[1] == 0 && this.rgb[2] == 255 && this.rgb[0] < 255)
                        this.rgb[0]++;
                    if (this.rgb[0] == 255 && this.rgb[1] == 0 && this.rgb[2] > 0)
                        this.rgb[2]--;

                    if (this.rgb2[0] == 255 && this.rgb2[2] == 0 && this.rgb2[1] < 255)
                        this.rgb2[1]++;
                    if (this.rgb2[1] == 255 && this.rgb2[2] == 0 && this.rgb2[0] > 0)
                        this.rgb2[0]--;
                    if (this.rgb2[0] == 0 && this.rgb2[1] == 255 && this.rgb2[2] < 255)
                        this.rgb2[2]++;
                    if (this.rgb2[0] == 0 && this.rgb2[2] == 255 && this.rgb2[1] > 0)
                        this.rgb2[1]--;
                    if (this.rgb2[1] == 0 && this.rgb2[2] == 255 && this.rgb2[0] < 255)
                        this.rgb2[0]++;
                    if (this.rgb2[0] == 255 && this.rgb2[1] == 0 && this.rgb2[2] > 0)
                        this.rgb2[2]--;
                    */

                    int R0 = this.RainbowSynch.R0;
                    int G0 = this.RainbowSynch.G0;
                    int B0 = this.RainbowSynch.B0;

                    int R1 = this.RainbowSynch.R1;
                    int G1 = this.RainbowSynch.G1;
                    int B1 = this.RainbowSynch.B1;

                    //Debug.WriteLine($"R: {R0}, G: {G0}, B: {B0}");

                    //Set color
                    e.Graphics.DrawString(this.Text, this.Font, new LinearGradientBrush(this.ClientRectangle, Color.FromArgb(R0, G0, B0), Color.FromArgb(R1, G1, B1), this.GradientDegree), this.Location);
                }
                if (!this.isRainbow)
                {
                    e.Graphics.DrawString(this.Text, this.Font, new LinearGradientBrush(this.ClientRectangle, this.ColorFirst, this.ColorSecond, this.GradientDegree), this.Location);
                }
                this.Refresh();
            };
        }
    }
}
