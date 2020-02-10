using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MagicalUIEngine.MagicalComponents
{
    public class RainbowSynchronizer
    {
        public int R0 { get; set; } = 255;
        public int G0 { get; set; } = 0;
        public int B0 { get; set; } = 0;

        public int R1 { get; set; } = 255;
        public int G1 { get; set; } = 255;
        public int B1 { get; set; } = 0;

        private bool stopped = false;
        private bool paused = false;

        public void Stop() => this.stopped = true;

        public void Pause() => this.paused = true;
        public void Resume() => this.paused = false;

        private void sleep() => Thread.Sleep(this.Delay);

        /// <summary>
        /// Milliseconds delay between colour change
        /// </summary>
        public int Delay { get; set; } = 100;

        public RainbowSynchronizer()
        {
            Task.Factory.StartNew(() =>
            {
                while (!this.stopped)
                {
                    while (this.paused) ;
                    for (int i = 0; i < 255; i++)
                    {
                        G0 = i;
                        this.sleep();
                    }
                    for (int i = 255; i >= 0; i--)
                    {
                        R0 = i;
                        this.sleep();
                    }
                    for (int i = 0; i < 255; i++)
                    {
                        B0 = i;
                        this.sleep();
                    }
                    for (int i = 255; i >= 0; i--)
                    {
                        G0 = i;
                        this.sleep();
                    }
                    for (int i = 0; i < 255; i++)
                    {
                        R0 = i;
                        this.sleep();
                    }
                    for (int i = 255; i >= 0; i--)
                    {
                        B0 = i;
                        this.sleep();
                    }
                }
            });
            Task.Factory.StartNew(() =>
            {
                while (!this.stopped)
                {
                    while (this.paused) ;
                    for (int i = 0; i < 255; i++)
                    {
                        G1 = i;
                        this.sleep();
                    }
                    for (int i = 255; i >= 0; i--)
                    {
                        R1 = i;
                        this.sleep();
                    }
                    for (int i = 0; i < 255; i++)
                    {
                        B1 = i;
                        this.sleep();
                    }
                    for (int i = 255; i >= 0; i--)
                    {
                        G1 = i;
                        this.sleep();
                    }
                    for (int i = 0; i < 255; i++)
                    {
                        R1 = i;
                        this.sleep();
                    }
                    for (int i = 255; i >= 0; i--)
                    {
                        B1 = i;
                        this.sleep();
                    }
                }
            });
        }
    }
}
