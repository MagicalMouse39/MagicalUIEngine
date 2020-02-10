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
    public class GradientLabel : Label
    {
        public Color ColorFirst { get; set; } = Color.Black;
        public Color ColorSecond { get; set; } = Color.White;
        public float GradientDegree { get; set; } = 90f;
        public bool IsRainbow { get; set; } = false;

        private int[] rgb = new[] { 255, 0, 0 };

        public GradientLabel()
        {
            this.Paint += (s, e) =>
            {
                if (this.IsRainbow)
                {
                    //Update RGB
                    if (this.rgb[0] == 255 && this.rgb[2] == 0)
                        this.rgb[1]++;
                    if (this.rgb[1] == 255 && this.rgb[2] == 0)
                        this.rgb[0]--;
                    if (this.rgb[0] == 0 && this.rgb[1] == 255)
                        this.rgb[2]++;
                    if (this.rgb[0] == 0 && this.rgb[2] == 255)
                        this.rgb[1]--;
                    if (this.rgb[1] == 0 && this.rgb[2] == 255)
                        this.rgb[0]++;
                    if (this.rgb[0] == 255 && this.rgb[1] == 0)
                        this.rgb[2]--;

                    if (this.rgb[0] == 255 && this.rgb[2] == 0)
                        this.rgb[1]++;
                    if (this.rgb[1] == 255 && this.rgb[2] == 0)
                        this.rgb[0]--;
                    if (this.rgb[0] == 0 && this.rgb[1] == 255)
                        this.rgb[2]++;
                    if (this.rgb[0] == 0 && this.rgb[2] == 255)
                        this.rgb[1]--;
                    if (this.rgb[1] == 0 && this.rgb[2] == 255)
                        this.rgb[0]++;
                    if (this.rgb[0] == 255 && this.rgb[1] == 0)
                        this.rgb[2]--;


                    //Set color
                    e.Graphics.DrawString(this.Text, this.Font, new LinearGradientBrush(this.ClientRectangle, Color.FromArgb(255, this.rgb[0], this.rgb[1], this.rgb[2]), Color.FromArgb(255, this.rgb2[0], this.rgb2[1], this.rgb2[2]), this.GradientDegree), this.Location);
                }
                if (!this.IsRainbow)
                    this.rgb = new[] { 255, 0, 0 };
            };
        }
    }
}
