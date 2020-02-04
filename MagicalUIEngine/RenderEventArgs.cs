using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalUIEngine
{
    public class RenderEventArgs : EventArgs
    {
        public Graphics Graphics;

        public RenderEventArgs(Graphics graphics) => this.Graphics = graphics;
    }
}
